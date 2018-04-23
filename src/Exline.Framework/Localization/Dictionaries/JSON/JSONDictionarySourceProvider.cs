using System.Collections.Generic;

namespace Exline.Framework.Localization.Dictionaries.JSON
{
    public class JSONDictionarySourceProvider
        : IDictionarySourceProvider
    {
        private readonly string _name;
        private readonly IDictionaryReader _reader;
        private readonly IDictionarySource _defaultDictionarySource;
        private readonly IDictionary<string, IDictionarySource> _dictionaries;


        public string Name => _name;

        public IDictionary<string, IDictionarySource> Dictionaries => _dictionaries;

        public IDictionarySource DefaultDictionary
        {
            get
            {
                return _defaultDictionarySource;
            }
        }

        public JSONDictionarySourceProvider(string name, IDictionaryReader reader)
        {
            _reader = reader;
            _dictionaries = _reader.Initialize();
        }

        public string GetString(string key)
        {
            throw new System.NotImplementedException();
        }

        public string GetStringEmpty(string key)
        {
            throw new System.NotImplementedException();
        }

        public string GetStringOrDefault(string key)
        {
            throw new System.NotImplementedException();
        }

    }
}