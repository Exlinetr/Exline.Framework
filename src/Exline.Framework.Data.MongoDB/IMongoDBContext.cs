using Exline.Framework.Data;
using MongoDB.Driver;

namespace Exline.Framework.Data.MongoDB
{
    public interface IMongoDBContext
        : IDBContext
    {
        IMongoClient Client{get;}
        IMongoDatabase Database{get;}

        IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName=null) 
             where TDocument:class,IDocument;

    }
}