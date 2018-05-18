using System;
using Exline.Framework.Net;

namespace Exline.Framework.Social
{

    public abstract class BaseSocialApi
        : IDisposable
    {
        // protected ExHttpClient HttpClient { get; }

        public BaseSocialApi()
        {
        }

        public virtual void Dispose()
        {
            // if (HttpClient != null)
            // {
            //     HttpClient.Dispose();
            // }
        }
    }
}