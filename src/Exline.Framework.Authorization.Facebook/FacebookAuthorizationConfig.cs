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
            : this()
        {
            this.AppId = appId;
            this.SecretKey = secretKey;
        }
        internal string ApiHost { get; set; }
        internal string ApiVersion { get; set; }
        public string AppId { get; set; }
        public string SecretKey { get; set; }
    }
}