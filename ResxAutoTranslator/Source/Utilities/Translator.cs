namespace ResxAutoTranslator.Source.Utilities
{
    using System;

    public abstract class Translator
    {
        public readonly Language DestinationLanguage;
        public readonly Language SourceLanguage;

        public Translator(Language sourceLanguage, Language destinationLanguage)
        {
            if (sourceLanguage == null || destinationLanguage == null)
            {
                throw new ArgumentNullException();
            }

            this.SourceLanguage = sourceLanguage;
            this.DestinationLanguage = destinationLanguage;
        }

        public abstract string Translate(string stringToTranslate);
    }
}