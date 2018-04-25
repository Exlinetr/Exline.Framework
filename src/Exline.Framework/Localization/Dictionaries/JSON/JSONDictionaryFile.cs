using System.Collections.Generic;

namespace Exline.Framework.Localization.Dictionaries.JSON
{
    internal class JSONDictionaryFile
    {
        public string DefaultValue { get; set; }
        public string Name { get; set; }
        public LanguageInfo Language { get; set; }
        public IList<DictionaryContent> Contents { get; set; }
        
        public JSONDictionaryFile()
        {

        }
    } 
}