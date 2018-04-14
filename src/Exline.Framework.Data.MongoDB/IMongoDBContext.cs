using Exline.Framework.Data;
using MongoDB.Driver;

namespace Exline.Framework.Data.MongoDB
{
    public interface IMongoDBContext
    {
        IMongoClient Client{get;}
        IMongoDatabase Database{get;}

        IMongoCollection<TEntity> GetCollection<TEntity,TPrimaryKey>(string collectionName=null) 
             where TEntity:class,IDocument<TPrimaryKey>;

    }
}