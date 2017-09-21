// Translating text with Azure cognitive services
// http://www.cyotek.com/blog/translating-text-with-azure-cognitive-services

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.
namespace ResxAutoTranslator.Source.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Text;

    public class MicrosoftTranslator : Translator
    {
        public MicrosoftTranslator(Language sourceLanguage, Language destinationLanguage)
            : base(sourceLanguage, destinationLanguage)
        {
            this._timestampWhenTokenExpires = DateTime.MinValue;
        }

        public override string Translate(string stringToTranslate)
        {
            return this.TranslateWithMicrosoft(
                stringToTranslate,
                this.SourceLanguage.Value,
                this.DestinationLanguage.Value);
        }

        // https://www.cyotek.com/blog/translating-text-with-azure-cognitive-services
        #region Copied Code

        private const string _apiBaseUri = "https://api.microsofttranslator.com/v2/http.svc/";

        private const string _getLanguageNamesUri = _apiBaseUri + "GetLanguageNames";

        private const string _getLanguagesForTranslateUri = _apiBaseUri + "GetLanguagesForTranslate";

        private const string _issueTokenUri = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";

        private const int _minutesUntilTokenExpires = 8;

        private const string _translateUri = _apiBaseUri + "Translate";

        private static readonly DataContractSerializer _stringArrayDataContractSerializer =
            new DataContractSerializer(typeof(string[]));

        private static readonly DataContractSerializer _stringDataContractSerializer =
            new DataContractSerializer(typeof(string));

        private static readonly DataContractSerializer _stringListDataContractSerializer =
            new DataContractSerializer(typeof(List<string>));

        private string _authorizationKey;

        private string _authorizationToken;

        private DateTime _timestampWhenTokenExpires;

        public string AuthorizationKey
        {
            get
            {
                return this._authorizationKey;
            }

            set
            {
                if (!string.Equals(this._authorizationKey, value))
                {
                    this._authorizationKey = value;
                    this._timestampWhenTokenExpires = DateTime.MinValue;
                }
            }
        }

        public string[] GetLanguages()
        {
            string[] results;

            // https://docs.microsofttranslator.com/text-translate.html#!/default/get_GetLanguagesForTranslate
            results = null;

            this.CheckToken();

            this.ExecuteRequest(
                _getLanguagesForTranslateUri, 
                null, 
                null, 
                response =>
                    {
                        results = this.ReadObject<List<string>>(response, _stringListDataContractSerializer).ToArray();
                    });

            return results;
        }

        public string GetLocalizedLanguageName(string locale, string language)
        {
            return this.GetLocalizedLanguageNames(locale, new[] { language })[0];
        }

        public string[] GetLocalizedLanguageNames(string locale, string[] languages)
        {
            string[] results;

            // https://docs.microsofttranslator.com/text-translate.html#!/default/post_GetLanguageNames
            results = null;

            this.CheckToken();

            this.ExecuteRequest(
                _getLanguageNamesUri, 
                "locale=" + locale, 
                request =>
                    {
                        request.Method = WebRequestMethods.Http.Post;

                        this.WriteObject(request, _stringArrayDataContractSerializer, languages);
                    }, 
                response => { results = this.ReadObject<string[]>(response, _stringArrayDataContractSerializer); });

            return results;
        }

        public string TranslateWithMicrosoft(string text, string from, string to)
        {
            string result;
            string queryString;

            // https://docs.microsofttranslator.com/text-translate.html#!/default/get_Translate
            result = null;

            this.CheckToken();

            queryString = string.Concat("text=", Uri.EscapeDataString(text), "&from=", from, "&to=", to);

            this.ExecuteRequest(
                _translateUri, 
                queryString, 
                null, 
                response => { result = this.ReadObject<string>(response, _stringDataContractSerializer); });

            return result;
        }

        private void CheckToken()
        {
            if (DateTime.UtcNow > this._timestampWhenTokenExpires)
            {
                this.RefreshToken();
            }
        }

        private HttpWebRequest CreateRequest(string uri, string query)
        {
            HttpWebRequest request;

            if (!string.IsNullOrEmpty(query))
            {
                if (query[0] == '?')
                {
                    uri += query;
                }
                else
                {
                    uri += "?" + query;
                }
            }

            request = WebRequest.CreateHttp(uri);
            request.Headers.Add("Authorization", "Bearer " + this._authorizationToken);
            request.Accept = "application/xml";
            request.ContentType = "application/xml";

            return request;
        }

        private void ExecuteRequest(
            string uri, 
            string query, 
            Action<HttpWebRequest> init, 
            Action<HttpWebResponse> action)
        {
            HttpWebRequest request;

            request = this.CreateRequest(uri, query);

            try
            {
                if (init != null)
                {
                    init.Invoke(request);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        action(response);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected response code.");
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response;

                response = (HttpWebResponse)ex.Response;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        throw new SecurityException("Invalid authorization key.", ex);
                    case HttpStatusCode.ServiceUnavailable:
                        throw new InvalidOperationException("Quota exceeded.", ex);
                    default:
                        throw;
                }
            }
        }

        private string GetResponseString(HttpWebResponse response)
        {
            Encoding encoding;
            string result;

            // ReSharper disable once AssignNullToNotNullAttribute
            encoding = !string.IsNullOrEmpty(response.CharacterSet)
                           ? Encoding.UTF8
                           : Encoding.GetEncoding(response.CharacterSet);

            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }

        private T ReadObject<T>(HttpWebResponse response, DataContractSerializer dataContractSerializer)
        {
            using (var stream = response.GetResponseStream())
            {
                return (T)dataContractSerializer.ReadObject(stream);
            }
        }

        private void RefreshToken()
        {
            // https://docs.microsofttranslator.com/oauth-token.html
            if (string.IsNullOrEmpty(this._authorizationKey))
            {
                throw new InvalidOperationException("Authorization key not set.");
            }

            this.ExecuteRequest(
                _issueTokenUri, 
                null, 
                request =>
                    {
                        request.Method = WebRequestMethods.Http.Post;
                        request.Headers.Add("Ocp-Apim-Subscription-Key", this._authorizationKey);
                        request.ContentLength = 0; // Must be set to avoid 411 response
                    }, 
                response =>
                    {
                        this._authorizationToken = this.GetResponseString(response);
                        this._timestampWhenTokenExpires = DateTime.UtcNow.AddMinutes(_minutesUntilTokenExpires);
                    });
        }

        private void WriteObject(HttpWebRequest request, DataContractSerializer dataContractSerializer, object value)
        {
            using (var stream = request.GetRequestStream())
            {
                dataContractSerializer.WriteObject(stream, value);
            }
        }

        #endregion
    }
}