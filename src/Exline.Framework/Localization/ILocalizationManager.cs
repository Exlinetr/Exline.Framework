using Exline.Framework.Localization.Dictionaries;

namespace Exline.Framework.Localization
{
    public interface ILocalizationManager
    {
        IDictionarySourceProvider DictionarySourceProvider { get; }
    }
}