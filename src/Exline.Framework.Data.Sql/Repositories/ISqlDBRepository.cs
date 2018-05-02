using System.Linq;
using Exline.Framework.Data.Repositories;

namespace Exline.Framework.Data.Sql.Repositories
{
    public interface ISqlDBRepository<TDocument>
        : ISqlDBRepository<TDocument, int>
        where TDocument : class, IDocument<int>, new()
    {

    }

    public interface ISqlDBRepository<TDocument, TPrimaryKey>
        : IRepository<TDocument, TPrimaryKey>
        where TDocument : class, IDocument<TPrimaryKey>, new()
    {
        // IQueryable<TDocument> QueryAsync(string query,);
    }
}