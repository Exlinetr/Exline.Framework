using System.Collections.Generic;

namespace Exline.Framework.Localization.Dictionaries
{
    public interface IDictionarySourceProvider
    {
        string Name { get; }
        IDictionary<string, IDictionarySource> Dictionaries { get; }
        IDictionarySource DefaultDictionary { get; }
        // void Initialize(string path);
        string GetString(string key);
        string GetStringEmpty(string key);
        string GetStringOrDefault(string key);
        
        string GetString(string key,LanguageInfo languageInfo);
        string GetStringEmpty(string key,LanguageInfo languageInfo);
        string GetStringOrDefault(string key,LanguageInfo languageInfo);
    }
}