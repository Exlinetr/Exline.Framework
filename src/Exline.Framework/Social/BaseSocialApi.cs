using System;
using Exline.Framework.Net;

namespace Exline.Framework.Social
{

    public abstract class BaseSocialApi
        : IDisposable
    {
        protected ExWebClient WebClient { get; }

        public BaseSocialApi()
        {
            WebClient = new ExWebClient();
        }

        public virtual void Dispose()
        {
            if (WebClient != null)
            {
                WebClient.Dispose();
            }
        }
    }
}