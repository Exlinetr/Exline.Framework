using Exline.Framework.Localization.Dictionaries.JSON;
using Xunit;

namespace Exline.Framework.Test.Localization.JSON
{
    public class JSONDictionarySourceTest
    {
        private readonly JSONDicrionarySource _dictionarySource;
        public JSONDictionarySourceTest()
        {
            _dictionarySource = JSONDicrionarySource.FromFile("../../../Localization/Dictionary/JSON/Resources/resource.en-US.json");
        }

        [Fact]
        public void GetString()
        {
            Assert.Equal(_dictionarySource.GetString("$hello"), "Hello");
            Assert.Equal(_dictionarySource.GetString("$hello2"), null);
        }

        [Fact]
        public void GetStringEmpty()
        {
            Assert.Equal(_dictionarySource.GetStringEmpty("$hello"), "Hello");
            Assert.Equal(_dictionarySource.GetStringEmpty("$hello2"), string.Empty);
        }

        [Fact]
        public void GetStringOrDefault()
        {
            Assert.Equal(_dictionarySource.GetStringOrDefault("$hello"), "Hello");
            Assert.Equal(_dictionarySource.GetStringOrDefault("$hello2"), "none");
        }
    }
}