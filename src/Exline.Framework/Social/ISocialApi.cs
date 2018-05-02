using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exline.Framework.Social
{
    public interface ISocailApi
        : IDisposable
    {
        Task<SocailAccount> GetAccountAsync(string accessToken,IEnumerable<string> scops);
    }
}