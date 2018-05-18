using Newtonsoft.Json;

namespace Exline.Framework.Social.Google.Models.Api
{
    internal class NameModel
    {
        [JsonProperty(PropertyName="givenName")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName="middleName")]
        public string MiddleName { get; set; }
        
        [JsonProperty(PropertyName="familyName")]
        public string Surname { get; set; }

    }
}