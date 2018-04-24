using Exline.Framework.Localization.Dictionaries;
using Exline.Framework.Localization.Dictionaries.JSON;
using Xunit;

namespace Exline.Framework.Test.Localization.JSON
{
    public class JSONDictionarySourceProviderTest
    {
        private readonly JSONDictionarySourceProvider _dictionarySourceProvider;
        public JSONDictionarySourceProviderTest()
        {
            _dictionarySourceProvider = new JSONDictionarySourceProvider("taks_app", new JSONDictionaryReader("../../../Localization/Dictionary/JSON/Resources/"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("en-US")]
        [InlineData("tr-TR")]
        public void GetString(string culture)
        {
            string val = _dictionarySourceProvider.GetString("$hello", new LanguageInfo("", "", culture));
            if (culture == "en-US")
                Assert.Equal(val, "Hello");
            else if (culture == "tr-TR")
                Assert.Equal(val, "Merhaba");
            else if (string.IsNullOrEmpty(culture))
                Assert.Equal(val, "Merhaba");
        }

        [Theory]
        [InlineData("")]
        [InlineData("en-US")]
        [InlineData("tr-TR")]
        public void GetStringEmpty(string culture)
        {
            string val = _dictionarySourceProvider.GetStringEmpty("$hello", new LanguageInfo("", "", culture));
            if (culture == "en-US")
                Assert.Equal(val, "Hello");
            else if (culture == "tr-TR")
                Assert.Equal(val, "Merhaba");
            else if (string.IsNullOrEmpty(culture))
                Assert.Equal(val, "Merhaba");
        }

        [Theory]
        [InlineData("")]
        [InlineData("en-US")]
        [InlineData("tr-TR")]
        public void GetStringOrDefault(string culture)
        {
            string val = _dictionarySourceProvider.GetStringOrDefault("$hello", new LanguageInfo("", "", culture));
            if (culture == "en-US")
                Assert.Equal(val, "Hello");
            else if (culture == "tr-TR")
                Assert.Equal(val, "Merhaba");
            else if (string.IsNullOrEmpty(culture))
                Assert.Equal(val, "Merhaba");
        }
    }
}