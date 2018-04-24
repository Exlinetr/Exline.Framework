namespace Exline.Framework.Localization.Dictionaries
{
    public class DictionaryConfiguration
    {
        public static DictionaryConfiguration Default;

        public DictionaryLocalizationType UseType { get; set; }
        public string Keyword { get; set; }

        static DictionaryConfiguration()
        {
            Default = new DictionaryConfiguration()
            {
                UseType = DictionaryLocalizationType.HEADER,
                Keyword = "accept-language"
            };
        }
    }
}