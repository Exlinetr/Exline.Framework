using System;
using System.Linq;
using MongoDB.Driver;

namespace Exline.Framework.Data.MongoDB
{
    public sealed class MongoDBContext
        : BaseDBContext,IMongoDBContext
    {
        private readonly IMongoDBContextConfig _contextConfig;
        public MongoDBContext(IMongoDBContextConfig contextConfig)
        {
            if(contextConfig is null)
                throw new ArgumentNullException(nameof(contextConfig));

            _contextConfig=contextConfig;
            Client=new MongoClient(contextConfig.ToConnectionString());
            Database=Client.GetDatabase(contextConfig.DatabaseName);
        }
        public IMongoClient Client {get;}

        public IMongoDatabase Database {get;}

        public IMongoCollection<TDocument> GetCollection<TDocument,TPrimaryKey>(string collectionName=null)
            where TDocument:class,IDocument<TPrimaryKey>
        {
            if(Database is null)
                throw new NullReferenceException(nameof(Database));
            return Database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument),collectionName));
        }
    }
}