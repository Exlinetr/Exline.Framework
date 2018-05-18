using System;
using Microsoft.AspNetCore.Builder;
using Exline.Framework.Localization;

namespace Exline.Framework
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
        {
            return app
                .UseApplication();
        }

        public static IApplicationBuilder UseApplication(this IApplicationBuilder app, Action<ApplicationBuilderConfiguration> config)
        {
            ApplicationBuilderConfiguration appConfig = new ApplicationBuilderConfiguration();

            config(appConfig);
            
            if(appConfig.IsUseRequestLocalization){
                // app.UseLocalizationDictionary();
            }

            return app;
        }
    }
}