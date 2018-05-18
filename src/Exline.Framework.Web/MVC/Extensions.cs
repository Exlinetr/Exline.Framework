using System;
using Exline.Framework.Log;
using Microsoft.AspNetCore.Builder;

namespace Exline.Framework.Web.MVC
{
    public static class ServiceCollectionExtensions
    {
        public static void UseRequetsTimingLog(this IApplicationBuilder app)
        {
            app.UseMiddleware<TimingLogMiddleware>();
        }
        public static void UseRequetsTimingLog(this IApplicationBuilder app, Action<LoggerFactoryOptions> action)
        {
            LoggerFactoryOptions loggerFactoryOptions = new LoggerFactoryOptions();
            action(loggerFactoryOptions);
            ILoggerFactory loggerFactory = new LoggerFactory(loggerFactoryOptions);
            app.UseMiddleware<TimingLogMiddleware>(loggerFactory);
        }

          public static void UseRequetsExceptionHandleLog(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleLogMiddleware>();
        }
        public static void UseRequetsExceptionHandleLog(this IApplicationBuilder app, Action<LoggerFactoryOptions> action)
        {
            LoggerFactoryOptions loggerFactoryOptions = new LoggerFactoryOptions();
            action(loggerFactoryOptions);
            ILoggerFactory loggerFactory = new LoggerFactory(loggerFactoryOptions);
            app.UseMiddleware<ExceptionHandleLogMiddleware>(loggerFactory);
        }
    }
}