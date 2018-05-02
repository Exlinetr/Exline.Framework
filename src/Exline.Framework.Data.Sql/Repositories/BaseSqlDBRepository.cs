using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Exline.Framework.Data.Repositories;

namespace Exline.Framework.Data.Sql.Repositories
{
    public abstract class BaseSqlDBRepository<TDocument>
       : BaseSqlDBRepository<TDocument, string, ISqlDBContext>
           where TDocument : class, IDocument<string>, new()
    {
        public BaseSqlDBRepository(ISqlDBContext dbContext)
            : base(dbContext)
        {

        }
    }
    public abstract class BaseSqlDBRepository<TDocument, Context>
       : BaseSqlDBRepository<TDocument, string, Context>
           where TDocument : class, IDocument<string>, new()
           where Context : ISqlDBContext
    {
        public BaseSqlDBRepository(Context dbContext)
            : base(dbContext)
        {

        }
    }

    public abstract class BaseSqlDBRepository<TDocument, TPrimaryKey, Context>
        : ISqlDBRepository<TDocument, TPrimaryKey>
            where TDocument : class, IDocument<TPrimaryKey>, new()
            where TPrimaryKey : class
            where Context : ISqlDBContext
    {
        protected Context DBContext { get; private set; }
        public BaseSqlDBRepository(Context dbContext)
        {
            DBContext = dbContext;
        }
        #region insert

        public abstract Task<TDocument> AddOneAsync(TDocument model);

        #endregion

        #region update

        public abstract Task<bool> UpdateOneAsync(TDocument model);

        #endregion

        public abstract Task<int> DeleteAsync(TDocument model);

        public virtual Task<int> DeleteByIdAsync(TPrimaryKey id)
        {
            return DeleteAsync(new TDocument()
            {
                Id = id
            });
        }


        public abstract Task<bool> ExistsAsync(Expression<Func<TDocument, bool>> predicate);
        public abstract Task<int> CountAsync();
        public abstract Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate);
        public abstract Task<TDocument> GetByIdAsync(TPrimaryKey id);
        public abstract Task TruncateAsync();
    }
}