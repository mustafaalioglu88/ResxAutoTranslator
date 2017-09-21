namespace ResxAutoTranslator.Source.Utilities
{
    using System;
    using System.Collections;
    using System.Resources;

    public class ResxTranslateManager
    {
        public readonly Translator Translator;

        public ResxTranslateManager(Translator translator)
        {
            if (translator == null)
            {
                throw new ArgumentNullException();
            }

            this.Translator = translator;
        }

        public Hashtable TranslateFile(string resxFile)
        {
            var resourceEntries = new Hashtable();
            ResXResourceReader reader;

            try
            {
                reader = new ResXResourceReader(resxFile);
            }
            catch (Exception ex)
            {
                return resourceEntries;
            }

            foreach (DictionaryEntry d in reader)
            {
                if (d.Value == null)
                {
                    resourceEntries.Add(d.Key.ToString(), string.Empty);
                }
                else if (!(d.Value is string))
                {
                    resourceEntries.Add(d.Key.ToString(), string.Empty);
                }
                else if (string.IsNullOrWhiteSpace(d.Value.ToString()))
                {
                    resourceEntries.Add(d.Key.ToString(), string.Empty);
                }
                else
                {
                    resourceEntries.Add(d.Key.ToString(), this.Translator.Translate(d.Value.ToString()));
                }
            }

            reader.Close();

            return resourceEntries;
        }

        public int GetCharCountOfFile(string resxFile)
        {
            int count = 0;
            ResXResourceReader reader;

            try
            {
                reader = new ResXResourceReader(resxFile);
            }
            catch (Exception ex)
            {
                return count;
            }

            foreach (DictionaryEntry d in reader)
            {
                var value = d.Value as string;
                if (value != null)
                {
                    count += d.Value.ToString().Length;
                }
            }

            reader.Close();

            return count;
        }

        public void WriteResxWithCultureName(string filePath, Hashtable translatedHashTable)
        {
            var path = filePath;
            if (filePath.Contains("aspx.resx"))
            {
                path = filePath.Insert(
                    filePath.LastIndexOf("aspx.", StringComparison.Ordinal) + "aspx.".Length,
                    this.Translator.DestinationLanguage.Value + ".");
            }
            else if (filePath.Contains("aspx." + this.Translator.SourceLanguage.Value + ".resx"))
            {
                path = filePath.Replace("aspx." + this.Translator.SourceLanguage.Value + ".resx", "aspx." + this.Translator.DestinationLanguage.Value + ".resx");
            }

            var resourceWriter = new ResXResourceWriter(path);
            foreach (string key in translatedHashTable.Keys)
            {
                resourceWriter.AddResource(key, translatedHashTable[key]);
            }

            resourceWriter.Generate();
            resourceWriter.Close();
        }
    }
}