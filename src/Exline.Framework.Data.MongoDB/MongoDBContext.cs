using System;
using System.Linq;
using System.Threading.Tasks;
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

        public override async Task DropAsync()
        {
            if(Database is null)
                throw new NullReferenceException(nameof(Database));
            await Client.DropDatabaseAsync(_contextConfig.DatabaseName);
        }

        public override async Task<bool> ExistsAsync<TDocument>(string collectionName = null)
            //where TDocument:class,IDocument
        {
            if(Database is null)
                throw new NullReferenceException(nameof(Database));
            // (GetCollection<TDocument>(collectionName).Exists());
            return true; 
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName=null)
            where TDocument:class,IDocument
        {
            if(Database is null)
                throw new NullReferenceException(nameof(Database));
            return Database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument),collectionName));
        }
    }
}