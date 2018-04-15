using Exline.Framework.Data.InMemory.Repositories;
using Exline.Framework.Data.Repositories;

namespace Exline.Framework.Data.InMemory.Repositories 
{
    public interface IMemoryDBRepository<TDocument,TPrimaryKey>
        : IRepository<TDocument,TPrimaryKey>
        where TDocument:class, IDocument<TPrimaryKey>, new()
    {
        
    }

    public interface IMemoryDBRepository<TDocument>
        : IRepository<TDocument>
        where TDocument:class, IDocument<int>, new()
    {

    }
}