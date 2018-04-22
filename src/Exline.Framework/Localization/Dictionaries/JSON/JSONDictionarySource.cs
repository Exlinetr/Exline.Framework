using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Localization.Dictionaries.JSON
{
    public sealed class JSONDicrionarySource
        : BaseDictionarySource, IDictionarySource
    {

        #region members

        private readonly LanguageInfo _languageInfo;
        private readonly JSONDictionarySourceInfo _jsonDictionarySourceInfo;

        #endregion


        public string this[string key] => GetStringEmpty(key);

        public LanguageInfo Language => _languageInfo;

        public IDictionarySourceInfo DictionarySourceInfo => _jsonDictionarySourceInfo;

        public IReadOnlyList<DictionaryContent> GetAllStrings()
        {
            return DictionaryContentCollection.ToList();
        }

        public DictionaryContent GetDictionaryContent(string key)
        {
            return DictionaryContentCollection[key];
        }

        public IEnumerator<DictionaryContent> GetEnumerator()
        {
            return DictionaryContentCollection.GetEnumerator();
        }

        public string GetString(string key)
        {
            DictionaryContent dictionaryContent = GetDictionaryContent(key);
            if (dictionaryContent == null)
                return null;
            return dictionaryContent.Value;
        }

        public string GetStringEmpty(string key)
        {
            string content = GetString(key);
            if (content == null)
                return string.Empty;
            return content;
        }

        public string GetStringOrDefault(string key)
        {
            string content=GetString(key);
            if(content==null)
                return _defaultValue;
            return content;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return DictionaryContentCollection.GetEnumerator();
        }
    }
}