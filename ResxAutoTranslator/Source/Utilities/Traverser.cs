namespace ResxAutoTranslator.Source.Utilities
{
    using System;
    using System.Collections.Generic;

    public abstract class Traverser
    {
        public readonly string RootPath;

        public Traverser(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
            {
                throw new ArgumentNullException();
            }

            this.RootPath = rootPath;
        }

        public abstract List<string> GetResxFiles(string langPrefix);
    }
}