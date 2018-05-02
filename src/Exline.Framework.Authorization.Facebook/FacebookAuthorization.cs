namespace Exline.Framework.Authorization.Facebook
{
    public class FacebookAuthorization
        : BaseAuthorization, IFacebookAuthorization
    {
        private readonly FacebookAuthorizationConfig _config;
        private readonly FacebookApiUrlFactory _apiUrlFactory;
        public FacebookAuthorization(FacebookAuthorizationConfig config)
        {
            _config = config;
            _apiUrlFactory = new FacebookApiUrlFactory(_config);
        }

        public AuthUser GetUserInfo(string accessToken)
        {
            AuthUser user = new FacebookAuthUser();
            

            return user;
        }
    }
}