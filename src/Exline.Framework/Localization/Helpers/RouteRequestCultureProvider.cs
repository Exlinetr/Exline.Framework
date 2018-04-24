using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
// using Microsoft.AspNetCore.Routing;

namespace Exline.Framework.Localization.Helpers
{
    internal class RouteRequestCultureProvider
        : Microsoft.AspNetCore.Localization.RequestCultureProvider
    {
        private static readonly string _preferix = "language";
        // private static readonly string _uıCulturePreferix = "";
        public RouteRequestCultureProvider()
        {

        }

        public async override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return null;
            }
            string culture = httpContext.GetRouteValue(_preferix).ToString();
            if (!string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture, culture);

            return null;
        }
    }
}