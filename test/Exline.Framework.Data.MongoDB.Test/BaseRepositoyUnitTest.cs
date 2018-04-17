using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Exline.Framework.Data.MongoDB.Test
{
    public class BaseRepositoyUnitTest
        : IDisposable
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICategoryRepository _categoryRepository;

        public BaseRepositoyUnitTest()
        {
            _services=new ServiceCollection(); 

            _services.UseMongoDB(contextConfig => {

                contextConfig.SetServerInfo("127.0.0.1","test-db");

                return contextConfig;
            });

            _services.AddSingleton<ICategoryRepository,CategoryRepository>();

            _serviceProvider=_services.BuildServiceProvider();

            _categoryRepository=_serviceProvider
                .GetService<ICategoryRepository>();
        }

        [Fact]
        public void AddOneAsync()
        {
            Task.Run(async()=>{

                CategoryDocument category=new CategoryDocument(){
                    Id=Guid.NewGuid().ToString(),
                    Name="Machine Learning"
                };
                await _categoryRepository.AddOneAsync(category);
                CategoryDocument dbCategory = await _categoryRepository.GetByIdAsync(category.Id);

                Assert.NotNull(dbCategory);
                Assert.Equal(category.Id,dbCategory.Id);
                Assert.Equal(category.Name,dbCategory.Name);

            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void UpdateOneAsync()
        {
            Task.Run(async()=>{

                CategoryDocument category=new CategoryDocument(){
                    Id=Guid.NewGuid().ToString(),
                    Name="Machine Learning"
                };

                CategoryDocument modifiedCategory=new CategoryDocument(){
                    Id=category.Id,
                    Name="Algorithm"
                };

                await _categoryRepository.AddOneAsync(category);
                await _categoryRepository.UpdateOneAsync(modifiedCategory);

                CategoryDocument dbCategory = await _categoryRepository.GetByIdAsync(category.Id);

                Assert.NotNull(dbCategory);
                Assert.Equal(modifiedCategory.Id,dbCategory.Id);
                Assert.Equal(modifiedCategory.Name,dbCategory.Name);

            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void DeleteAsync()
        {
            Task.Run(async()=>{

                CategoryDocument category=new CategoryDocument(){
                    Id=Guid.NewGuid().ToString(),
                    Name="Machine Learning"
                };
              
                await _categoryRepository.AddOneAsync(category);
                await _categoryRepository.DeleteAsync(category);

                CategoryDocument dbCategory = await _categoryRepository.GetByIdAsync(category.Id);

                Assert.Null(dbCategory);

            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void DeleteByIdAsync()
        {
            Task.Run(async()=>{

                CategoryDocument category=new CategoryDocument(){
                    Id=Guid.NewGuid().ToString(),
                    Name="Machine Learning"
                };
              
                await _categoryRepository.AddOneAsync(category);
                await _categoryRepository.DeleteByIdAsync(category.Id);

                CategoryDocument dbCategory = await _categoryRepository.GetByIdAsync(category.Id);

                Assert.Null(dbCategory);

            }).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            _categoryRepository.TruncateAsync();
            _serviceProvider.GetService<IMongoDBContext>().DropAsync();
        }
    }
}
