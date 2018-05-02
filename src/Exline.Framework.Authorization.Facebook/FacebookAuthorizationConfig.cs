namespace Exline.Framework.Authorization.Facebook
{
    public class FacebookAuthorizationConfig
        : IAuthorizationConfig
    {
        public FacebookAuthorizationConfig()
        {
            ApiHost = "https://graph.facebook.com";
            ApiVersion = "v3.0";
        }

        public FacebookAuthorizationConfig(string appId, string secretKey)
            : base()
        {
            this.AppId = appId;
            this.SecretKey = secretKey;
        }
        public string ApiHost { get; set; }
        public string ApiVersion { get; set; }
        public string AppId { get; set; }
        public string SecretKey { get; set; }
    }
}