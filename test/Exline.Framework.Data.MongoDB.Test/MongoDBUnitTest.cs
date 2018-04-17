using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Exline.Framework.Data.MongoDB.Test
{
     public class MongoDBUnitTest
    {
        private readonly IMongoDBContext _dbContext;
        public MongoDBUnitTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.UseMongoDB(contextConfig => {

                contextConfig.SetServerInfo("127.0.0.1","test-db");

                return contextConfig;
            });
            _dbContext=services.BuildServiceProvider().GetService<IMongoDBContext>();
        }

        [Fact]
        public void DependencyInjectionExtensionMethod()
        {   
            Assert.NotNull(_dbContext);
        }

        [Fact]
        public void Drop()
        {
            Task.Run(async()=>{

                await _dbContext.DropAsync();

            });
        }
    }
}