using System.Collections.Generic;

namespace Exline.Framework.Localization.Dictionaries
{
    public interface IDictionarySource
        : IEnumerable<DictionaryContent>
    {
        LanguageInfo Language { get; }
        IDictionarySourceInfo DictionarySourceInfo {get;}
        
        string this[string key] { get; }
        string GetString(string key);
        string GetStringOrDefault(string key);
        string GetStringEmpty(string key);
        DictionaryContent GetDictionaryContent(string key);
        IReadOnlyList<DictionaryContent> GetAllStrings();
    }
}