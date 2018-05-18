using Newtonsoft.Json;

namespace Exline.Framework.Social.Facebook.Models.Api
{
    internal class ErrorModel
    {

        [JsonProperty(PropertyName="message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName="type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName="code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName="fbtrace_id")]
        public int FbTraceId { get; set; }
    }
}