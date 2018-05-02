using System.Collections.Generic;
using System.Threading.Tasks;
using Exline.Framework.Serialization;
using Exline.Framework.Serialization.JSON;

namespace Exline.Framework.Social.Facebook
{
    public class FacebookApi
        : BaseSocialApi, IFacebookApi
    {
        private readonly FacebookApiConfig _apiConfig;
        private readonly FacebookApiUrlFactory _urlFactory;
        private readonly ITextSerializer _serializer;

        public FacebookApi()
        {
            _serializer = new JSONSerializer();
        }

        public FacebookApi(FacebookApiConfig apiConfig)
            : this()
        {
            _apiConfig = apiConfig;
            _urlFactory = new FacebookApiUrlFactory(_apiConfig);
        }

        public async Task<SocailAccount> GetAccountAsync(string accessToken, IEnumerable<string> scops)
        {
            Models.Api.MeResponseModel me = await WebClient.DownloadAsync<Models.Api.MeResponseModel>(_urlFactory.Me(accessToken, scops), _serializer);
            SocailAccount account = new SocailAccount();
            return account;
        }
        
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}