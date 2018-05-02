using Exline.Framework.Data.Repositories;
using Exline.Framework.Data.Sql.Repositories;

namespace Exline.Framework.Data.Sql.Dapper.Repositories
{
    public interface ISqlDBDapperRepository<TDocument>
        : ISqlDBDapperRepository<TDocument, int>
        where TDocument : class, IDocument<int>, new()
    {

    }
    public interface ISqlDBDapperRepository<TDocument, TPrimaryKey>
       : ISqlDBRepository<TDocument, TPrimaryKey>
       where TDocument : class, IDocument<TPrimaryKey>, new()
    {

    }

}