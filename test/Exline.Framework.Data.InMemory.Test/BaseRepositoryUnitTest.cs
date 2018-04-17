using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Exline.Framework.Data.InMemory.Test
{
    public class BaseRepositoryUnitTest : IDisposable
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductRepository _productRepository;
        public BaseRepositoryUnitTest()
        {
            _services= new ServiceCollection();

            _services.UseInMemoryDB();

            _services.AddSingleton<IProductRepository,ProductRepository>();

            _serviceProvider=_services.BuildServiceProvider();

            _productRepository = _serviceProvider
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
        public void UpdateOneAsync()
        {
            Task.Run(async()=>{

                ProductDocument product=new ProductDocument(){
                    Id=1,
                    Price=5,
                    Title="1Core 1GB VPS"
                };

                ProductDocument modifiedProduct=new ProductDocument(){
                    Id=1,
                    Price=10,
                    Title="2Core 1GB VPS"
                };

                await _productRepository.AddOneAsync(product);
                await _productRepository.UpdateOneAsync(modifiedProduct);

                ProductDocument dbProduct = await _productRepository.GetByIdAsync(product.Id);

                Assert.NotNull(dbProduct);
                Assert.Equal(modifiedProduct,dbProduct);
                Assert.Equal(modifiedProduct.Id,dbProduct.Id);
                Assert.Equal(modifiedProduct.Price,dbProduct.Price);
                Assert.Equal(modifiedProduct.Title,dbProduct.Title);

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

        public void Dispose()
        {
            _productRepository.TruncateAsync();
            _serviceProvider.GetService<IMemoryDBContext>().DropAsync();
        }
    }
}
