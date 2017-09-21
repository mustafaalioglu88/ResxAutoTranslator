namespace ResxAutoTranslator.Source
{
    using System;
    using System.Collections.Generic;
    using ResxAutoTranslator.Source.Utilities;

    public class ResxTranslator
    {
        public List<string> ResxFileList { get; private set; }
        public readonly ResxTranslateManager ResxOperator;
        private readonly FileTraverser traverser;

        public ResxTranslator(string rootPath, Translator translator)
        {
            if (string.IsNullOrWhiteSpace(rootPath) || translator == null)
            {
                throw new ArgumentNullException();
            }

            this.ResxFileList = new List<string>();
            this.traverser = new FileTraverser(rootPath);
            this.ResxOperator = new ResxTranslateManager(translator);
        }

        public void Start(bool useFallbackResx = true)
        {
            this.ResxFileList =
                this.traverser.GetResxFiles(
                    useFallbackResx ? string.Empty : this.ResxOperator.Translator.SourceLanguage.Value);

            // var totalChar = 0;
            foreach (var resxFile in this.ResxFileList)
            {
                // totalChar += this.resxOperator.GetCharCountOfFile(resxFile);
                var translatedHashTable = this.ResxOperator.TranslateFile(resxFile);
                this.ResxOperator.WriteResxWithCultureName(resxFile, translatedHashTable);
            }
        }
    }
}