using System.Threading.Tasks;
using Exline.Framework.Data.Sql.Dapper.Repositories;

namespace Exline.Framework.Data.Sql.Dapper.Test
{
    public class BrandRepository
        : BaseSqlDBDapperRepository<BrandDocument>, IBrandRepository
    {
        public BrandRepository(ISqlDBDapperContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<int> DeleteByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BrandDocument> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}