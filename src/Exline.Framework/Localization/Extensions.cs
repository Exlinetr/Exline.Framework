using System.Collections.Generic;
using Exline.Framework.Localization.Dictionaries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace Exline.Framework.Localization
{
    public static class Extensions
    {
        public static IApplicationBuilder UseLocalization(this IApplicationBuilder app, ILocalizationManager localizationManager)
        {
            return app
                .UseLocalizationDictionary(localizationManager.DictionarySourceProvider);
        }

        public static IApplicationBuilder UseLocalizationDictionary(this IApplicationBuilder app, IDictionarySourceProvider dictionarySourceProvider)
        {
            RequestLocalizationOptions requestLocalizationOptions = new RequestLocalizationOptions();
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new Helpers.DefaultRequestCultureProvider()
                },
                DefaultRequestCulture = new RequestCulture(dictionarySourceProvider.DefaultDictionary.Language.Acronym, dictionarySourceProvider.DefaultDictionary.Language.Acronym)
            });
            return app;
        }

        public static IServiceCollection UseLocalizationDictionary(this IServiceCollection services, IDictionarySourceProvider dictionarySourceProvider)
        {
            services.AddSingleton<IDictionarySourceProvider>(dictionarySourceProvider);
            return services;
        }

        public static IServiceCollection UseLocalization(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationManager, DefaultLocalizationManager>();
            return services;
        }
    }
}