using Exline.Framework.Data.MongoDB.Repositories;

namespace Exline.Framework.Data.MongoDB.Test
{
    public class CategoryRepository
        : BaseMongoDBRepository<CategoryDocument, MongoDBContext>, ICategoryRepository
    {
        public CategoryRepository(MongoDBContext dbContext) 
            : base(dbContext)
        {
            
        }
    }
}