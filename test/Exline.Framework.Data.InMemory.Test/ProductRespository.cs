using Exline.Framework.Data.InMemory.Repositories;

namespace Exline.Framework.Data.InMemory.Test
{
    public class ProductRepository
        : BaseMemoryDBRepository<ProductDocument, MemoryDBContext>,IProductRepository
    {
        public ProductRepository(IMemoryDBContext dbContext) 
            : base(dbContext)
        {

        }
    }
}