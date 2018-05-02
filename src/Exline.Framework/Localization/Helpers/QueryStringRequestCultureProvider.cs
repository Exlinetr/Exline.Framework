using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Primitives;

namespace Exline.Framework.Localization.Helpers
{
    internal class QueryStringRequestCultureProvider
        : Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider
    {
        private static readonly string _prefix = "language";
        private static readonly string _uiCulturePrefix = "ui-language";
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
            httpContext.Request.Query.TryGetValue(_prefix, out culture);
            httpContext.Request.Query.TryGetValue(_uiCulturePrefix, out uiCulture);

            if (!string.IsNullOrEmpty(uiCulture) && !string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture.ToString(), uiCulture.ToString());
            else if (!string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture.ToString(), culture.ToString());

            return null;
        }
    }
}