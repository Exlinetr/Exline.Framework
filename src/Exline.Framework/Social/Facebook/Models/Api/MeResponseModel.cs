using Newtonsoft.Json;

namespace Exline.Framework.Social.Facebook.Models.Api
{
    internal class MeResponseModel
    {
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName="name")]        
        public string Name { get; set; }
        
        [JsonProperty(PropertyName="email")]     
        public string Email { get; set; }

        [JsonProperty(PropertyName="first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName="last_name")]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName="birthday")]
        public string Birthday { get; set; }
        
        [JsonProperty(PropertyName="age_range")]
        public AgeRange AgeRange { get; set; }

        [JsonProperty(PropertyName="picture")]
        public PictureModel Picture { get; set; }

    }
}