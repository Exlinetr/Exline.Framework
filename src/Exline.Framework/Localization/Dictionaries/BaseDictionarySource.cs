using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Localization.Dictionaries
{
    public abstract class BaseDictionarySource
        : IDictionarySource
    {
        #region members

        private readonly string _defaultValue;
        private readonly LanguageInfo _languageInfo;

        private readonly DictionaryContentCollection _dictionaryContentCollection;
        private readonly IDictionaryReader _dictionaryReader;
        private readonly IDictionarySourceInfo _dictionarySourceInfo;

        #endregion



        public string this[string key] => GetStringEmpty(key);

        public LanguageInfo Language => _languageInfo;

        public IDictionarySourceInfo DictionarySourceInfo => _dictionarySourceInfo;

        internal BaseDictionarySource()
        {

        }
        internal BaseDictionarySource(string defaultValue, LanguageInfo languageInfo, IList<DictionaryContent> contents)
            : this(defaultValue, languageInfo, new DictionaryContentCollection(contents))
        {

        }
        internal BaseDictionarySource(string defaultValue, LanguageInfo languageInfo, DictionaryContentCollection dictionaryContentCollection)
        {
            _defaultValue=defaultValue;
            _languageInfo = languageInfo;
            _dictionaryContentCollection = dictionaryContentCollection;
        }
 
        public IReadOnlyList<DictionaryContent> GetAllStrings()
        {
            return _dictionaryContentCollection.ToList();
        }

        public DictionaryContent GetDictionaryContent(string key)
        {
            return _dictionaryContentCollection[key];
        }

        public IEnumerator<DictionaryContent> GetEnumerator()
        {
            return _dictionaryContentCollection.GetEnumerator();
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
            string content = GetString(key);
            if (content == null)
                return _defaultValue;
            return content;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionaryContentCollection.GetEnumerator();
        }
    }
}