using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Exline.Framework.Social.Google
{
    internal class GoogleApiUrlFactory
    {
        private readonly GoogleApiConfig _apiConfig;
        private const string _me = "/people/me";

        public GoogleApiUrlFactory(GoogleApiConfig apiConfig)
        {
            if (apiConfig == null)
                throw new NullReferenceException(nameof(apiConfig));

            _apiConfig = apiConfig;
        }

        public string Me(IEnumerable<string> scops)
        {
            StringBuilder link = new StringBuilder(CreateHost());
            link.Append(_me);
            link.Append($"?fields={CreateScops(scops)}");
            link.Append($"&key={_apiConfig.ClientId}");
            return link.ToString();
        }

        public string CreateHost()
        {
            return $"{GoogleApiConfig.ApiHost}/{GoogleApiConfig.ApiVersion}";
        }

        private string CreateScops(IEnumerable<string> scops)
        {
           return string.Join(",",scops);
        }
    }
}