using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Localization.Dictionaries.JSON
{
    public class JSONDictionarySourceProvider
        : IDictionarySourceProvider
    {
        private readonly string _name;
        private readonly IDictionaryReader _reader;
        private readonly IDictionarySource _defaultDictionarySource;
        private readonly IDictionary<string, IDictionarySource> _dictionaries;
        private readonly DictionaryConfiguration _dictionaryConfiguration;


        public string Name => _name;

        public IDictionary<string, IDictionarySource> Dictionaries => _dictionaries;

        public IDictionarySource DefaultDictionary
        {
            get
            {
                return _defaultDictionarySource;
            }
        }

        public JSONDictionarySourceProvider(string name, IDictionaryReader reader, DictionaryConfiguration configuration = null)
        {
            _reader = reader;
            if (configuration == null)
                configuration = DictionaryConfiguration.Default;
            _dictionaryConfiguration = configuration;
            _dictionaries = _reader.Initialize();
            // var _default = _dictionaries.FirstOrDefault(x => x.Value.Language.IsDefault == true);
            _defaultDictionarySource = _dictionaries.FirstOrDefault(x => x.Value.Language.IsDefault == true).Value; //_default != null ? _default.Value : null;
        }

        public string GetString(string key)
        {
            return GetString(key, LanguageInfo.Current);
        }

        public string GetStringEmpty(string key)
        {
            return GetStringEmpty(key, LanguageInfo.Current);
        }

        public string GetStringOrDefault(string key)
        {
            return GetStringOrDefault(key, LanguageInfo.Current);
        }

        public string GetString(string key, LanguageInfo languageInfo)
        {
            return GetDictionarySource(languageInfo)
                .GetString(key);
        }

        public string GetStringEmpty(string key, LanguageInfo languageInfo)
        {

            return GetDictionarySource(languageInfo)
                .GetStringEmpty(key);
        }

        public string GetStringOrDefault(string key, LanguageInfo languageInfo)
        {
            return GetDictionarySource(languageInfo)
                .GetStringOrDefault(key);
        }

        private IDictionarySource GetDictionarySource(LanguageInfo languageInfo)
        {
            IDictionarySource dictionarySource = _defaultDictionarySource;
            if (_dictionaries.ContainsKey(languageInfo.Acronym))
                dictionarySource = _dictionaries[languageInfo.Acronym];
            return dictionarySource;
        }
    }
}