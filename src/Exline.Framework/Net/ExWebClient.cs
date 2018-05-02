using System;
using System.Net;
using System.Threading.Tasks;
using Exline.Framework.Serialization;

namespace Exline.Framework.Net
{
    public class ExWebClient
        : WebClient
    {
        public ExWebClient()
            : base()
        {

        }

        public async Task<TObject> DownloadAsync<TObject>(Uri uri, ITextSerializer textSerializer)
        {
            return textSerializer.Desrialize<TObject>(await this.DownloadStringTaskAsync(uri));
        }

    }
}