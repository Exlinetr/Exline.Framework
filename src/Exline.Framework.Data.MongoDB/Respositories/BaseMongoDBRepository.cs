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
    public abstract class BaseMongoDBRepository<TDocument>
        : BaseMongoDBRepository<TDocument, string, IMongoDBContext>
            where TDocument : class, IDocument<string>, new()
    {
        public BaseMongoDBRepository(IMongoDBContext dbContext)
            : base(dbContext)
        {

        }
    }

    public abstract class BaseMongoDBRepository<TDocument, Context>
        : BaseMongoDBRepository<TDocument, string, Context>
            where TDocument : class, IDocument<string>, new()
            where Context : IMongoDBContext
    {
        public BaseMongoDBRepository(Context dbContext)
            : base(dbContext)
        {

        }
    }

    public abstract class BaseMongoDBRepository<TDocument, TPrimaryKey, Context>
        : IRepository<TDocument, TPrimaryKey>
            where TDocument : class, IDocument<TPrimaryKey>, new()
            where TPrimaryKey : class
            where Context : IMongoDBContext
    {
        protected Context DBContext { get; private set; }
        public BaseMongoDBRepository(Context dbContext)
        {
            DBContext = dbContext;
        }
        #region insert

        public virtual async Task<TDocument> AddOneAsync(TDocument model)
        {
            await DBContext.GetCollection<TDocument, TPrimaryKey>()
             .InsertOneAsync(model);
            return model;
        }

        #endregion

        #region update

        public virtual async Task<bool> UpdateOneAsync(TDocument model)
        {
            return (await DBContext
                .GetCollection<TDocument, TPrimaryKey>()
                .ReplaceOneAsync(x => x.Id == model.Id, model)).ModifiedCount == 1;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(TDocument model)
        {
            return int.Parse((await DBContext
                .GetCollection<TDocument, TPrimaryKey>()
                .DeleteManyAsync(x => x.Id == model.Id)).DeletedCount.ToString());
        }

        public Task<int> DeleteByIdAsync(TPrimaryKey id)
        {
            return DeleteAsync(new TDocument()
            {
                Id = id
            });
        }


        public virtual async Task<bool> ExistsAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return (await DBContext.GetCollection<TDocument, TPrimaryKey>()
                .AsQueryable()
                    .AnyAsync(predicate));
        }
        public virtual async Task<int> CountAsync()
        {
            return (await DBContext.GetCollection<TDocument, TPrimaryKey>()
                .AsQueryable()
                .CountAsync());
        }
        public virtual async Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return (await DBContext.GetCollection<TDocument, TPrimaryKey>()
                .AsQueryable()
                .CountAsync(predicate));
        }
        public virtual async Task<TDocument> GetByIdAsync(TPrimaryKey id)
        {
            var query = new global::MongoDB.Driver.FilterDefinitionBuilder<TDocument>()
                .Eq(x => x.Id, id);
            return await DBContext
                .GetCollection<TDocument, TPrimaryKey>()
                .FindAsync<TDocument>(query).Result.FirstOrDefaultAsync();

        }

        public virtual async Task TruncateAsync()
        {
            BaseDBContext baseDBContext = DBContext as BaseDBContext;
            if (baseDBContext is null)
                throw new Exception("");
            await DBContext.Database.DropCollectionAsync((baseDBContext.GetCollectionName(typeof(TDocument), null)));
        }
    }
}