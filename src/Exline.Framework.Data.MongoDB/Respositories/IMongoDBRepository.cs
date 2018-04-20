using Exline.Framework.Data.Repositories;

namespace Exline.Framework.Data.MongoDB.Repositories
{
      public interface IMongoDBRepository<TDocument,TPrimaryKey>
        : IRepository<TDocument,TPrimaryKey>
        where TDocument:class, IDocument<TPrimaryKey>, new()
    {
        
    }
    public interface IMongoDBRepository<TDocument>
        : IMongoDBRepository<TDocument,string>
        where TDocument:class, IDocument<string>, new()
    {

    }
}