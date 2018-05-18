using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exline.Framework.Net;
using Exline.Framework.Serialization;
using Exline.Framework.Serialization.JSON;

namespace Exline.Framework.Social.Google
{
    public class GoogleApi
        : BaseSocialApi, IGoogleApi
    {
        private readonly GoogleApiConfig _apiConfig;
        private readonly GoogleApiUrlFactory _urlFactory;
        private readonly ITextSerializer _serializer;

        public GoogleApi()
        {
            _serializer = new JSONSerializer();
        }

        public GoogleApi(GoogleApiConfig apiConfig)
            : this()
        {
            _apiConfig = apiConfig;
            _urlFactory = new GoogleApiUrlFactory(_apiConfig);
        }

        public async Task<SocailAccount> GetAccountAsync(string accessToken, IEnumerable<string> scops)
        {
            using (ExHttpClient httpClient = ExHttpClient.Create())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(_urlFactory.Me(scops)))
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