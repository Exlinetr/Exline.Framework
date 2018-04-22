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

        public JSONDictionarySourceInfo()
        {

        }

    }
}