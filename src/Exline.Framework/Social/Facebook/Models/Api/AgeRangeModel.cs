using Newtonsoft.Json;

namespace Exline.Framework.Social.Facebook.Models.Api
{
    internal class AgeRange
    {

        [JsonProperty(PropertyName="min")]        
        public int Min { get; set; }
        public int Max { get; set; }
    }
}