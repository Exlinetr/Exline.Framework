using Exline.Framework.Data.MongoDB;
using Exline.Framework.Data.Repositories;

namespace Exline.Framework.Data.MongoDB.Test
{
    public interface ICategoryRepository
        : IRepository<CategoryDocument,string>
    {
        
    }
}