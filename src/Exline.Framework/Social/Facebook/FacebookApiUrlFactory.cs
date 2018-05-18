using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Exline.Framework.Social.Facebook
{
    internal class FacebookApiUrlFactory
    {
        private readonly FacebookApiConfig _apiConfig;
        private const string _me = "/me";

        public FacebookApiUrlFactory(FacebookApiConfig apiConfig)
        {
            if (apiConfig == null)
                throw new NullReferenceException(nameof(apiConfig));

            _apiConfig = apiConfig;
        }

        public string Me(string token, IEnumerable<string> scops)
        {
            StringBuilder link = new StringBuilder(CreateHost());
            link.Append(_me);
            link.Append($"?fields={CreateScops(scops)}");
            link.Append($"&access_token={token}");
            return link.ToString();
        }

        public string CreateHost()
        {
            return $"{FacebookApiConfig.ApiHost}/{FacebookApiConfig.ApiVersion}";
        }

        private string CreateScops(IEnumerable<string> scops)
        {
           return string.Join(",",scops);
        }
    }
}