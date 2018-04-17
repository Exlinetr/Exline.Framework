using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Exline.Framework.Data.InMemory.Test
{
    public class BaseRepositoryUnitTest
    {
        private readonly IProductRepository _productRepository;
        public BaseRepositoryUnitTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.UseInMemoryDB();
            services.AddSingleton<IProductRepository,ProductRepository>();

            _productRepository = services
                                .BuildServiceProvider()
                                .GetService<IProductRepository>();
        }

        [Fact]
        public void AddOneAsync()
        {
            Task.Run(async()=>{
                ProductDocument product=new ProductDocument(){
                    Id=1,
                    Price=5,
                    Title="1Core 1GB VPS"
                };
                await _productRepository.AddOneAsync(product);
                ProductDocument dbProduct = await _productRepository.GetByIdAsync(product.Id);

                Assert.NotNull(dbProduct);
                Assert.Equal(product,dbProduct);
                Assert.Equal(product.Id,dbProduct.Id);
                Assert.Equal(product.Price,dbProduct.Price);
                Assert.Equal(product.Title,dbProduct.Title);
            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void DeleteAsync()
        {
            Task.Run(async()=>{
                ProductDocument product=new ProductDocument(){
                    Id=1,
                    Price=5,
                    Title="1Core 1GB VPS"
                };
                await _productRepository.AddOneAsync(product);
                await _productRepository.DeleteAsync(product);

                ProductDocument dbProduct = await _productRepository.GetByIdAsync(product.Id);
                Assert.Null(dbProduct);
            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void DeleteByIdAsync()
        {
            Task.Run(async()=>{
                ProductDocument product=new ProductDocument(){
                    Id=1,
                    Price=5,
                    Title="1Core 1GB VPS"
                };
                await _productRepository.AddOneAsync(product);
                await _productRepository.DeleteByIdAsync(product.Id);

                ProductDocument dbProduct = await _productRepository.GetByIdAsync(product.Id);
                Assert.Null(dbProduct);
            }).GetAwaiter().GetResult();
        }

        
    }
}
