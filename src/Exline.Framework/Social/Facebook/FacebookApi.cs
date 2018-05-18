using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Exline.Framework.Net;
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
            using (ExHttpClient httpClient = ExHttpClient.Create())
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(_urlFactory.Me(accessToken, scops)))
                {
                    if (responseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        return new SocailAccount((await responseMessage.Content.ReadAsStringAsync()).ToObject<Models.Api.MeResponseModel>());
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}