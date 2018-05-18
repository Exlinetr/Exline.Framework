namespace Exline.Framework.Social.Google
{
    public class GoogleApiConfig
            : IApiConfig
    {
        public const string ApiHost = " https://www.googleapis.com/plus";
        public const string ApiVersion = "v1";
        public GoogleApiConfig()
        {
        }

        public GoogleApiConfig(string clientId, string clientSecret)
            : this()
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}