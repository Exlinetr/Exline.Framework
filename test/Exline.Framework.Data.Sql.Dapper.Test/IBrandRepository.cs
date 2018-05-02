using Exline.Framework.Data.Sql.Dapper.Repositories;

namespace Exline.Framework.Data.Sql.Dapper.Test
{
    public interface IBrandRepository
        : ISqlDBDapperRepository<BrandDocument>
    {
    }
}