using System;
using System.Collections.Generic;
using System.IO;

namespace Exline.Framework.Localization.Dictionaries.JSON
{
    public class JSONDictionaryReader
        : IJSONDictionaryReader
    {
        private readonly string _directoryPath;
        public JSONDictionaryReader(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public IDictionary<string, IDictionarySource> Initialize()
        {
            IDictionary<string, IDictionarySource> sources = new Dictionary<string, IDictionarySource>();

            string[] fileNames = Directory.GetFiles(_directoryPath, "*.json", SearchOption.TopDirectoryOnly);
            if (fileNames == null)
            {
                throw new Exception("");
            }

            foreach (string file in fileNames)
            {
                IDictionarySource source = JSONDicrionarySource.FromFile(file);
                if (sources.ContainsKey(source.Language.Acronym))
                {
                    throw new Exception("");
                }
                sources.Add(source.Language.Acronym, source);
            }

            return sources;
        }
    }
}