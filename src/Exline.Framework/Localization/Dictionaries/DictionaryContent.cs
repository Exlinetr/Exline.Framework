namespace Exline.Framework.Localization.Dictionaries
{
    public class DictionaryContent
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public DictionaryContent(string key,string val)
        {
            this.Key=key;
            this.Value=val;
        }
    }
}