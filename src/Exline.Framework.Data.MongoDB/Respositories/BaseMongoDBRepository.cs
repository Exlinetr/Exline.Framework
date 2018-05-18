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
        : IMongoDBRepository<TDocument, TPrimaryKey>
            where TDocument : class, IDocument<TPrimaryKey>, new()
            where TPrimaryKey : class
            where Context : IMongoDBContext
    {
        private readonly IMongoCollection<TDocument> _collection;
        protected Context DBContext { get; private set; }

        public IMongoCollection<TDocument> Collection
        {
            get
            {
                return _collection;
            }
        }

        public BaseMongoDBRepository(Context dbContext)
            : this()
        {
            DBContext = dbContext;
            _collection = dbContext.GetCollection<TDocument>();
        }

        public BaseMongoDBRepository()
        {
        }
        #region insert

        public virtual async Task<TDocument> AddOneAsync(TDocument model)
        {
            await Collection
             .InsertOneAsync(model);
            return model;
        }

        #endregion

        #region update

        public virtual async Task<bool> UpdateOneAsync(TDocument model)
        {
            return (await Collection
                .ReplaceOneAsync(x => x.Id == model.Id, model)).ModifiedCount == 1;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(TDocument model)
        {
            return int.Parse((await Collection
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
            return (await Collection
                .AsQueryable()
                    .AnyAsync(predicate));
        }
        public virtual async Task<int> CountAsync()
        {
            return (await Collection
                .AsQueryable()
                .CountAsync());
        }
        public virtual async Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return (await Collection
                .AsQueryable()
                .CountAsync(predicate));
        }
        public virtual async Task<TDocument> GetByIdAsync(TPrimaryKey id)
        {
            var query = new global::MongoDB.Driver.FilterDefinitionBuilder<TDocument>()
                .Eq(x => x.Id, id);
            return await Collection
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