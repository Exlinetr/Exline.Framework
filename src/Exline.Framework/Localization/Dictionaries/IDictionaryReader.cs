using System.Collections.Generic;

namespace Exline.Framework.Localization.Dictionaries
{
    public interface IDictionaryReader
    {

        // IDictionarySource Read(string path);
        // IDictionary<string,IDictionarySource> Read(params string[] paths);
        IDictionary<string,IDictionarySource> Initialize();

    }
}