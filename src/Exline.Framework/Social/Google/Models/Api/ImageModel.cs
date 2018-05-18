using Newtonsoft.Json;

namespace Exline.Framework.Social.Google.Models.Api
{
    internal class ImageModel
    {
        [JsonProperty(PropertyName="url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName="isDefautl")]
        public bool IsDefault { get; set; }
    }
}