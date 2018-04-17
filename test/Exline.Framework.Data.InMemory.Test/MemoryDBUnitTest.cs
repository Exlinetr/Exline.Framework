using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Exline.Framework.Data.InMemory.Test
{
     public class MemoryDBUnitTest
    {
        public MemoryDBUnitTest()
        {
           

        }

        [Fact]
        public void DependencyInjectionExtensionMethod()
        {   
            IServiceCollection services = new ServiceCollection();
            services.UseInMemoryDB();
            MemoryDBContext dBContext=(MemoryDBContext)services.BuildServiceProvider().GetService<IMemoryDBContext>();
            Assert.NotNull(dBContext);
        }
    }
}