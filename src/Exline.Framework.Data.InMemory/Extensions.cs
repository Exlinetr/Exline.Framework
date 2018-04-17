using Microsoft.Extensions.DependencyInjection;

namespace Exline.Framework.Data.InMemory
{
    public static class Extensions
    {
        public static IServiceCollection UseInMemoryDB(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryDBContext,MemoryDBContext>();
            return services;
        }
    }
}