using System;
using System.Threading.Tasks;
using Exline.Framework.Log;
using Microsoft.AspNetCore.Http;

namespace Exline.Framework.Web.MVC
{
    public class ExceptionHandleLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        public ExceptionHandleLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await _loggerFactory.WriteAsync(ex.Message);
            }
        }
    }
}