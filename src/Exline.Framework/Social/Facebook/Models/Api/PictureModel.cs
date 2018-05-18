using Newtonsoft.Json;

namespace Exline.Framework.Social.Facebook.Models.Api
{
    internal class Picture
    {
        [JsonProperty(PropertyName="picture")]
        public string Url { get; set; } 
        
        [JsonProperty(PropertyName="height")]
        public int Height { get; set; }
        
        [JsonProperty(PropertyName="width")]
        public int Witdh { get; set; }
        
        [JsonProperty(PropertyName="is_silhouette")]
        public string IsSilhouette { get; set; }
        
        [JsonProperty(PropertyName="cache_key")]
        public string CacheKey { get; set; }
    }
    internal class PictureModel
    {
        [JsonProperty(PropertyName="data")]
        public Picture Image { get; set; }
    }
}