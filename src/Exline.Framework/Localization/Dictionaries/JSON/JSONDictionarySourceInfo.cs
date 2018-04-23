namespace Exline.Framework.Localization.Dictionaries.JSON
{
    public class JSONDictionarySourceInfo
        : IDictionarySourceInfo
    {
        #region members

        private readonly string _path, _name;
        private readonly bool _isReaded;

        #endregion

        public string Path => _path;

        public bool IsReaded => _isReaded;

        public string Name => _name;

        public JSONDictionarySourceInfo(string path)
            : this(string.Empty,path,false)
        {
        }
           public JSONDictionarySourceInfo(string name,string path,bool isReaded)
            : this()
        {
            _path = path;
            _name=name;
            _isReaded=isReaded;
        }
        public JSONDictionarySourceInfo(IDictionarySourceInfo info)
            : this(info.Path)
        {
            _name=info.Name;
            _isReaded=info.IsReaded;
        }

        public JSONDictionarySourceInfo()
        {

        }

    }
}