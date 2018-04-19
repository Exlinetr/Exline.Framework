using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Exline.Framework.Data.Repositories;

namespace Exline.Framework.Data.MongoDB.Repositories
{
    public abstract class BaseMongoDBRepository<TDocument, Context>
        : BaseMongoDBRepository<TDocument, string, Context>
            where TDocument : class , IDocument<string>, new()
            where Context: IMongoDBContext
    {
        public BaseMongoDBRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {

        }
    }

    public abstract class BaseMongoDBRepository<TDocument,TPrimaryKey,Context>
        : IRepository<TDocument,TPrimaryKey> 
            where TDocument : class , IDocument<TPrimaryKey>, new()
            where TPrimaryKey : class
            where Context: IMongoDBContext
    {
        protected IMongoDBContext DBContext{get;private set;}
        public BaseMongoDBRepository(IMongoDBContext dbContext)
        {
            DBContext=(MongoDBContext)dbContext;
        }
        #region insert
        
        public virtual async Task<TDocument> AddOneAsync(TDocument model)
        {
           await DBContext.GetCollection<TDocument>()
            .InsertOneAsync(model);
           return model;
        }

        #endregion

        #region update
        
        public virtual async Task<bool> UpdateOneAsync(TDocument model)
        {
            return (await DBContext
                .GetCollection<TDocument>()
                .ReplaceOneAsync(x=>x.Id==model.Id,model)).ModifiedCount==1;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(TDocument model)
        {
            return int.Parse((await DBContext
                .GetCollection<TDocument>()
                .DeleteManyAsync(x=>x.Id==model.Id)).DeletedCount.ToString());
        }
        
        public Task<int> DeleteByIdAsync(TPrimaryKey id)
        {
            return DeleteAsync(new TDocument(){
                Id=id
            });
        }


        public virtual async Task<bool> ExistsAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return (await DBContext.GetCollection<TDocument>()
                .AsQueryable()
                    .AnyAsync(predicate));
        }
        public virtual async Task<int> CountAsync()
        {
            return (await DBContext.GetCollection<TDocument>()
                .AsQueryable()
                .CountAsync());
        }
        public virtual async Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return (await DBContext.GetCollection<TDocument>()
                .AsQueryable()
                .CountAsync(predicate));
        }
        public virtual async  Task<TDocument> GetByIdAsync(TPrimaryKey id)
        {
            var query = new global::MongoDB.Driver.FilterDefinitionBuilder<TDocument>()
                .Eq(x=>x.Id,id);
            return await DBContext
                .GetCollection<TDocument>()
                .FindAsync<TDocument>(query).Result.FirstOrDefaultAsync();
            
        }

        public virtual async Task TruncateAsync()
        {
            await DBContext.Database.DropCollectionAsync(((BaseDBContext)DBContext).GetCollectionName(typeof(TDocument),null));
        }
    }
}