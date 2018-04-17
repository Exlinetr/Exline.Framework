using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Exline.Framework.Data.InMemory.Repositories
{
      public abstract class BaseMemoryDBRepository<TDocument, Context>
        : BaseMemoryDBRepository<TDocument, int, Context>
            where TDocument : class , IDocument<int>, new()
            where Context: IMemoryDBContext
    {
        public BaseMemoryDBRepository(IMemoryDBContext dbContext) 
            : base(dbContext)
        {

        }
    }

    public abstract class BaseMemoryDBRepository<TDocument,TPrimaryKey,Context>
        : IMemoryDBRepository<TDocument,TPrimaryKey> 
            where TDocument : class , IDocument<TPrimaryKey>, new()
            where Context: IMemoryDBContext
    {
        protected IMemoryDBContext DBContext{get;private set;}
        public BaseMemoryDBRepository(IMemoryDBContext dbContext)
        {
            DBContext=(MemoryDBContext)dbContext;
        }
        #region insert
        
        public virtual async Task<TDocument> AddOneAsync(TDocument model)
        {
            DBContext
                .GetCollection<TDocument,TPrimaryKey>()
                .Add(model);
           return model;
        }

        #endregion

        #region update
        
        public virtual async Task<bool> UpdateOneAsync(TDocument model)
        {
            await DeleteAsync(model);
            DBContext
                .GetCollection<TDocument,TPrimaryKey>()
                .Add(model);
            return true;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(TDocument model)
        {
            int index=DBContext.GetCollection<TDocument,TPrimaryKey>()
                .IndexOf(model);
            DBContext.GetCollection<TDocument,TPrimaryKey>()
                .RemoveAt(index);
            return 1;
        }
        
        public Task<int> DeleteByIdAsync(TPrimaryKey id)
        {
            return DeleteAsync(new TDocument(){
                Id=id
            });
        }


        public virtual async Task<bool> ExistsAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return DBContext.GetCollection<TDocument,TPrimaryKey>()
                .AsQueryable()
                .Any(predicate);
        }
        public virtual async Task<int> CountAsync()
        {
            return DBContext.GetCollection<TDocument,TPrimaryKey>()
                .AsQueryable()
                .Count();
        }
        public virtual async Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return DBContext.GetCollection<TDocument,TPrimaryKey>()
                .AsQueryable()
                .Count(predicate);
        }
        public virtual async  Task<TDocument> GetByIdAsync(TPrimaryKey id)
        {
            return DBContext.GetCollection<TDocument,TPrimaryKey>()
                .AsQueryable()
                .FirstOrDefault(x=>x.Id.ToString()==id.ToString());
        }
    }
}