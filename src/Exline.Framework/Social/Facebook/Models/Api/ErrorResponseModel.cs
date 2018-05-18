using Newtonsoft.Json;

namespace Exline.Framework.Social.Facebook.Models.Api
{
    internal class ErrorResponseModel
    {

        [JsonProperty(PropertyName="error")]        
        public ErrorModel Error { get; set; }
    }
}