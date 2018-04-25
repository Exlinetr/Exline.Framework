using System.Threading.Tasks;
using Exline.Framework.Localization.Dictionaries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Exline.Framework.Localization.Helpers
{
    internal class DefaultRequestCultureProvider
        : RequestCultureProvider
    {
        public DefaultRequestCultureProvider()
        {

        }

        public async override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            ProviderCultureResult providerCultureResult = null;
            providerCultureResult=await new HeaderRequestCultureProvider()
                .DetermineProviderCultureResult(httpContext)??await new QueryStringRequestCultureProvider()
                .DetermineProviderCultureResult(httpContext)??await new RouteRequestCultureProvider()
                .DetermineProviderCultureResult(httpContext);
                
            return providerCultureResult;
        }
    }
}