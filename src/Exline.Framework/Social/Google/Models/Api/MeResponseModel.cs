using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exline.Framework.Social.Google.Models.Api
{
    internal class MeResponseModel
    {
        
        [JsonProperty(PropertyName="birthday")]
        public string Birthday { get; set; }
        
        [JsonProperty(PropertyName="gender")]
        public string Gender { get; set; }
        
        [JsonProperty(PropertyName="emails")]
        public List<MailModel> Emails { get; set; }
        
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName="displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName="name")]
        public NameModel Name { get; set; }

        [JsonProperty(PropertyName="url")]
        public NameModel Url { get; set; }

        [JsonProperty(PropertyName="image")]
        public ImageModel Image { get; set; } 
    }
}