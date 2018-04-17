using System;
using Microsoft.Extensions.DependencyInjection;

namespace Exline.Framework.Data.MongoDB
{
    public static class Extensions
    {
        public static IServiceCollection UseMongoDB(this IServiceCollection services,Func<IMongoDBContextConfig,IMongoDBContextConfig> action)
        {
            IMongoDBContextConfig contextConfig=new MongoDBContextConfig();
            contextConfig = action(contextConfig);

            MongoDBContext context=new MongoDBContext(contextConfig);

            services.AddSingleton<IMongoDBContext>(context);
            
            return services;
        }
    }
}