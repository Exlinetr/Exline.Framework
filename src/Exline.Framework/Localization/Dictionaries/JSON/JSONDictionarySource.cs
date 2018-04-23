using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exline.Framework.Localization.Dictionaries.JSON
{
    public sealed class JSONDicrionarySource
        : BaseDictionarySource
    {

        // #region members
        // private readonly JSONDictionarySourceInfo _jsonDictionarySourceInfo;
        // private readonly IJSONDictionaryReader _jsonDictionaryReader;
        // #endregion

        // public JSONDicrionarySource()
        // {

        // }
        // public JSONDicrionarySource(string path)
        //     : this(new JSONDictionarySourceInfo(path))
        // {

        // }

        // public JSONDicrionarySource(IDictionarySourceInfo info)
        //     : this(new JSONDictionarySourceInfo(info))
        // {

        // }

        // public JSONDicrionarySource(JSONDictionarySourceInfo info)
        //     : this(info.Path, new JSONDictionaryReader())
        // {
        //     _jsonDictionarySourceInfo = info;
        // }

        // public JSONDicrionarySource(string path, IJSONDictionaryReader jsondDictionaryReader)
        //     : base(jsondDictionaryReader)
        // {
        //     _jsonDictionaryReader = jsondDictionaryReader;
        // }

        private JSONDicrionarySource(string defaultValue, LanguageInfo languageInfo, IList<DictionaryContent> contents)
            : base(defaultValue, languageInfo, contents)
        {

        }

        private JSONDicrionarySource(JSONDictionaryFile file)
            : this(file.DefaultValue, file.Language, file.Contents)
        {

        }


        public static JSONDicrionarySource FromFile(string path)
        {
            return LoadJSON(File.ReadAllText(path));
        }

        public static JSONDicrionarySource LoadJSON(string json)
        {
            JSONDictionaryFile dictionaryFile = Newtonsoft.Json.JsonConvert.DeserializeObject<JSONDictionaryFile>(json);
            return new JSONDicrionarySource(dictionaryFile);
        }

    }
}