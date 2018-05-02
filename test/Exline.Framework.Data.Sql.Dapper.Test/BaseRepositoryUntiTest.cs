using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Exline.Framework.Data.Sql.Dapper.Test
{
    public class BaseRepositoryUnitTest
    {
        private readonly IBrandRepository _brandRepository;

        public BaseRepositoryUnitTest()
        {
            _brandRepository = new BrandRepository(new SqlDBDapperContext(new SqlDBContextConfig()
            {
                Host = "127.0.0.1",
                Username = "sa",
                Password = "satest123.",
                DatabaseName = "test"
            }));
        }

        [Fact]
        public void AddOneAsync()
        {
            Task.Run(async () =>
            {

                BrandDocument brand = new BrandDocument()
                {
                    Id = 1,
                    Name = "Machine Learning"
                };
                await _brandRepository.AddOneAsync(brand);
                BrandDocument dbBrand = await _brandRepository.GetByIdAsync(brand.Id);

                Assert.NotNull(dbBrand);
                Assert.Equal(brand.Id, dbBrand.Id);
                Assert.Equal(brand.Name, dbBrand.Name);

            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void UpdateOneAsync()
        {
            Task.Run(async () =>
            {
                BrandDocument brand = new BrandDocument()
                {
                    Id = 1,
                    Name = "Machine Learning"
                };

                BrandDocument modifiedbrand = new BrandDocument()
                {
                    Id = 1,
                    Name = "Algorithm"
                };

                await _brandRepository.AddOneAsync(brand);
                await _brandRepository.UpdateOneAsync(modifiedbrand);

                BrandDocument dbBrand = await _brandRepository.GetByIdAsync(brand.Id);

                Assert.NotNull(dbBrand);
                Assert.Equal(modifiedbrand.Id, dbBrand.Id);
                Assert.Equal(modifiedbrand.Name, dbBrand.Name);

            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void DeleteAsync()
        {
            Task.Run(async () =>
            {
                BrandDocument brand = new BrandDocument()
                {
                    Id = 1,
                    Name = "Machine Learning"
                };

                await _brandRepository.AddOneAsync(brand);
                await _brandRepository.DeleteAsync(brand);

                BrandDocument dbBrand = await _brandRepository.GetByIdAsync(brand.Id);

                Assert.Null(dbBrand);

            }).GetAwaiter().GetResult();
        }

        // [Fact]
        // public void DeleteByIdAsync()
        // {
        //     Task.Run(async () =>
        //     {

        //         BrandDocument brand = new BrandDocument()
        //         {
        //             Id = 2,
        //             Name = "Machine Learning"
        //         };

        //         await _brandRepository.AddOneAsync(brand);
        //         await _brandRepository.DeleteByIdAsync(brand.Id);

        //         BrandDocument dbBrand = await _brandRepository.GetByIdAsync(brand.Id);

        //         Assert.Null(dbBrand);

        //     }).GetAwaiter().GetResult();
        // }

        public void Dispose()
        {
            _brandRepository.TruncateAsync();
        }
    }
}