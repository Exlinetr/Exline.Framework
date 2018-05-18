using Newtonsoft.Json;

namespace Exline.Framework.Social.Google.Models.Api
{
    internal class MailModel
    {
        [JsonProperty(PropertyName="value")]
        public string Mail { get; set; }
        
        [JsonProperty(PropertyName="type")]
        public string Type { get; set; }
    }
}