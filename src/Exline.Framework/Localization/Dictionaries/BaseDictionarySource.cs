namespace Exline.Framework.Localization.Dictionaries
{
    public abstract class BaseDictionarySource
    {
        protected readonly string _defaultValue;
        private readonly DictionaryContentCollection _dictionaryContentCollection;
        internal DictionaryContentCollection DictionaryContentCollection
        {
            get
            {
                return _dictionaryContentCollection;
            }
        }
    }
}