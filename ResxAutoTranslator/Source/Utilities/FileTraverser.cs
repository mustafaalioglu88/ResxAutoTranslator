namespace ResxAutoTranslator.Source.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileTraverser : Traverser
    {
        public FileTraverser(string rootPath)
            : base(rootPath)
        {
        }

        public override List<string> GetResxFiles(string langPrefix)
        {
            if (!string.IsNullOrWhiteSpace(langPrefix))
            {
                langPrefix = "." + langPrefix;
            }

            if (langPrefix == null)
            {
                langPrefix = string.Empty;
            }

            try
            {
                return
                    Directory.GetFiles(this.RootPath, "*.aspx" + langPrefix + ".resx", SearchOption.AllDirectories)
                        .ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
    }
}