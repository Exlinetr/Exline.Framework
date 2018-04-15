namespace Exline.Framework.Data.InMemory.Test
{
    public class ProductRepository
        : Repositories.BaseMemoryDBRepository<ProductDocument, int, MemoryDBContext>
    {
        public ProductRepository(IMemoryDBContext dbContext) 
            : base(dbContext)
        {
        }
    }
}