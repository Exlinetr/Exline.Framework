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
    public abstract class BaseMongoDBRepository<TEntity, Context>
        : BaseMongoDBRepository<TEntity, string, Context>
            where TEntity : class , IDocument<string>, new()
            where Context: IMongoDBContext
    {
        public BaseMongoDBRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {

        }
    }

    public abstract class BaseMongoDBRepository<TEntity,TPrimaryKey,Context>
        : IRepository<TEntity,TPrimaryKey> 
            where TEntity : class , IDocument<TPrimaryKey>, new()
            where Context: IMongoDBContext
    {
        protected IMongoDBContext DBContext{get;private set;}
        public BaseMongoDBRepository(IMongoDBContext dbContext)
        {
            DBContext=(MongoDBContext)dbContext;
        }
        #region insert
        
        public virtual async Task<TEntity> AddOneAsync(TEntity model)
        {
           await DBContext.GetCollection<TEntity,TPrimaryKey>()
            .InsertOneAsync(model);
           return model;
        }

        #endregion

        #region update
        
        public virtual async Task<bool> UpdateOneAsync(TEntity model)
        {
            return (await DBContext
                .GetCollection<TEntity,TPrimaryKey>()
                .ReplaceOneAsync(x=>x.Id.ToString()==model.Id.ToString(),model)).ModifiedCount==1;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(TEntity model)
        {
            return int.Parse((await DBContext
                .GetCollection<TEntity,TPrimaryKey>()
                .DeleteManyAsync(x=>x.Id.ToString()==model.Id.ToString())).DeletedCount.ToString());
        }
        
        public Task<int> DeleteByIdAsync(TPrimaryKey id)
        {
            return DeleteAsync(new TEntity(){
                Id=id
            });
        }


        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await DBContext.GetCollection<TEntity,TPrimaryKey>()
                .AsQueryable()
                    .AnyAsync(predicate));
        }
        public virtual async Task<int> CountAsync()
        {
            return (await DBContext.GetCollection<TEntity,TPrimaryKey>()
                .AsQueryable()
                .CountAsync());
        }
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await DBContext.GetCollection<TEntity,TPrimaryKey>()
                .AsQueryable()
                .CountAsync(predicate));
        }
        public virtual async  Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            var query = new global::MongoDB.Driver.FilterDefinitionBuilder<TEntity>()
                .Eq(x=>x.Id,id);
            return await DBContext
                .GetCollection<TEntity,TPrimaryKey>()
                .FindAsync<TEntity>(query).Result.FirstOrDefaultAsync();
            
        }
    }
}