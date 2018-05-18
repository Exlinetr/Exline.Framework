using Exline.Framework.Localization.Dictionaries;

namespace Exline.Framework.Localization
{
    public class DefaultLocalizationManager
        : ILocalizationManager
    {
        private readonly IDictionarySourceProvider _dictionarySourceProvider;
        public IDictionarySourceProvider DictionarySourceProvider
        {
            get
            {
                return _dictionarySourceProvider;
            }
        }

        public DefaultLocalizationManager(IDictionarySourceProvider dictionarySourceProvider)
        {
            _dictionarySourceProvider = dictionarySourceProvider;
        }
    }
}