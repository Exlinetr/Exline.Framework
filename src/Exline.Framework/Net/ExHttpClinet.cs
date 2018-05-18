using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Exline.Framework.Serialization;

namespace Exline.Framework.Net
{
    public class ExHttpClient
        : HttpClient
    {
        public ExHttpClient()
            : base()
        {

        }

        public static ExHttpClient Create()
        {
            return new ExHttpClient();
        }

        // public async Task<TObject> DownloadAsync<TObject>(string uri, ITextSerializer textSerializer)
        // {
        //     return textSerializer.Desrialize<TObject>(await this.DownloadStringTaskAsync(uri));
        // }

    }
}