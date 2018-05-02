using System;
using System.Net;

namespace Exline.Framework.Authorization
{
    public abstract class BaseAuthorization
        : IDisposable
    {
        protected WebClient WebClient { get; }

        public BaseAuthorization()
        {
            WebClient = new WebClient();
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