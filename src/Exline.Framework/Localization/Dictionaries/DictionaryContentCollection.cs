using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Localization.Dictionaries
{
    internal class DictionaryContentCollection
        : IEnumerable<DictionaryContent>
    {
        //private readonly IList<DictionaryContent> _dictionaryContents;
        private readonly IDictionary<string, string> _dictionaryContents;

        public int Count => _dictionaryContents.Count;

        public bool IsReadOnly => _dictionaryContents.IsReadOnly;

        public DictionaryContent this[string key]
        {
            get
            {
                DictionaryContent dictionaryContent=null;
                if(_dictionaryContents.ContainsKey(key))
                    dictionaryContent=new DictionaryContent(key,_dictionaryContents[key]);
                return dictionaryContent;
            }
        }


        public DictionaryContentCollection()
        {

        }

        public DictionaryContentCollection(IList<DictionaryContent> dictionaryContents)
            : this(dictionaryContents.ToDictionary(x => x.Key, x => x.Value))
        {
        }
        public DictionaryContentCollection(IDictionary<string, string> dictionaryContents)
            : this()
        {
            _dictionaryContents = dictionaryContents;
        }

        public void Add(DictionaryContent item)
        {
            if (_dictionaryContents.ContainsKey(item.Key))
                _dictionaryContents[item.Key] = item.Value;
            else
                _dictionaryContents.Add(item.Key, item.Value);
        }

        public void Add(string key, string val)
        {
            Add(new DictionaryContent(key, val));
        }

        public void Clear()
        {
            _dictionaryContents.Clear();
        }

        public bool Contains(DictionaryContent item)
        {
            return _dictionaryContents.ContainsKey(item.Key);
        }

        public void CopyTo(DictionaryContent[] array, int arrayIndex)
        {
            _dictionaryContents.CopyTo(array.Select(x => new KeyValuePair<string, string>(x.Key, x.Value)).ToArray(), arrayIndex);
        }

        public IEnumerator<DictionaryContent> GetEnumerator()
        {
            return _dictionaryContents.Select(x => new DictionaryContent(x.Key, x.Value)).GetEnumerator();
        }

        public bool Remove(DictionaryContent item)
        {
            return _dictionaryContents.Remove(new KeyValuePair<string, string>(item.Key, item.Value));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionaryContents.GetEnumerator();
        }
    }
}