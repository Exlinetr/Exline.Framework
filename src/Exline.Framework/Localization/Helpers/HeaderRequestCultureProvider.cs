using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Exline.Framework.Localization.Helpers
{
    internal class HeaderRequestCultureProvider
        : Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider
    {
        private static readonly string _preferix = "Accept-Language";
        private static readonly string _uiCulturePreferix = "";
        public HeaderRequestCultureProvider()
        {
        }

        public async override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return null;
            }
            string culture = httpContext.Request.Headers[_preferix].ToString();
            string uiCulture = httpContext.Request.Headers[_uiCulturePreferix].ToString();
            
            if (!string.IsNullOrEmpty(uiCulture) && !string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture, uiCulture);
            else if (!string.IsNullOrEmpty(culture))
                return new ProviderCultureResult(culture, culture);

            return null;
        }
    }
}