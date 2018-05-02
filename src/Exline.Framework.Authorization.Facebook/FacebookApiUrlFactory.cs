using System.Collections.Generic;
using System.Text;
using System;

namespace Exline.Framework.Authorization.Facebook
{
    internal class FacebookApiUrlFactory
    {
        private readonly FacebookAuthorizationConfig _authConfig;
        private const string _me = "/me";

        public FacebookApiUrlFactory(FacebookAuthorizationConfig authConfig)
        {
            if (authConfig == null)
                throw new NullReferenceException(nameof(authConfig));

            _authConfig = authConfig;
        }

        public string Me(IEnumerable<string> scops)
        {
            StringBuilder link = new StringBuilder(CreateHost());
            link.Append(_me);
            link.Append(CreateScops(scops));
            return link.ToString();
        }

        public string CreateHost()
        {
            return $"{_authConfig.ApiHost}/{_authConfig.ApiVersion}";
        }

        private StringBuilder CreateScops(IEnumerable<string> scops)
        {
            StringBuilder scopBuilder = new StringBuilder();
            foreach (string scop in scops)
            {
                scopBuilder.Append($"{scop},");
            }
            return scopBuilder;
        }
    }
}