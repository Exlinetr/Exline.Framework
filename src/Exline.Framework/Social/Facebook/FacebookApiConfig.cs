namespace Exline.Framework.Social.Facebook
{
    public class FacebookApiConfig
            : IApiConfig
    {
        public const string ApiHost = "https://graph.facebook.com";
        public const string ApiVersion = "v3.0";
        public FacebookApiConfig()
        {
            // ApiHost = "https://graph.facebook.com";
            // ApiVersion = "v3.0";
        }

        public FacebookApiConfig(string appId, string secretKey)
            : this()
        {
            this.AppId = appId;
            this.SecretKey = secretKey;
        }
        // internal string ApiHost { get; set; }
        // internal string ApiVersion { get; set; }
        public string AppId { get; set; }
        public string SecretKey { get; set; }
    }
}