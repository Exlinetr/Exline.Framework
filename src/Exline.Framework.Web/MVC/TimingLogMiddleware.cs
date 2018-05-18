using System.Threading.Tasks;
using Exline.Framework.Log;
using Microsoft.AspNetCore.Http;

namespace Exline.Framework.Web.MVC
{
    public class TimingLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        public TimingLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }
        public async Task Invoke(HttpContext context)
        {
            TimingLog timingLog=new TimingLog($"Request Method Name: {context.Request.Method}");
            await _next(context);
            timingLog.End();
            await _loggerFactory.WriteAsync(timingLog);
        }
    }
}