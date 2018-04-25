using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Primitives;

namespace Exline.Framework.Localization.Helpers
{
    internal class QueryStringRequestCultureProvider
        : Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider
    {
        private static readonly string _preferix = "language";
        private static readonly string _uıCulturePreferix = "ui-language";
        public QueryStringRequestCultureProvider()
        {

        }

        public async override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return null;
            }
            StringValues culture = StringValues.Empty;
            StringValues uiCulture = StringValues.Empty;
            httpContext.Request.Query.TryGetValue(_preferix, out culture);
            httpContext.Request.Query.TryGetValue(_preferix, out culture);

            if (!string.IsNullOrEmpty(uiCulture) && !string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture.ToString(), uiCulture.ToString());
            else if (!string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture.ToString(), culture.ToString());

            return null;
        }
    }
}