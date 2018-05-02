using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using Exline.Framework;
using Exline.Framework.Data;
using Dapper.Contrib.Extensions;
using Dapper.Extensions;
using Dapper.Extensions.Linq;
using Dapper.Extensions.Linq.Builder;
using Dapper.Extensions.Linq.Extensions;

namespace Exline.Framework.Data.Sql.Dapper.Repositories
{
    public abstract class BaseSqlDBDapperRepository<TDocument>
      : BaseSqlDBDapperRepository<TDocument, int, SqlDBDapperContext>
          where TDocument : class, IDocument<int>, new()
    {
        public BaseSqlDBDapperRepository(ISqlDBDapperContext dbContext)
            : base(dbContext)
        {

        }
    }

    public abstract class BaseSqlDBDapperRepository<TDocument, Context>
       : BaseSqlDBDapperRepository<TDocument, int, Context>
           where TDocument : class, IDocument<int>, new()
           where Context : ISqlDBDapperContext
    {
        public BaseSqlDBDapperRepository(ISqlDBDapperContext dbContext)
            : base(dbContext)
        {

        }
    }

    public abstract class BaseSqlDBDapperRepository<TDocument, TPrimaryKey, Context>
        : ISqlDBDapperRepository<TDocument, TPrimaryKey>
            where TDocument : class, IDocument<TPrimaryKey>, new()
            where TPrimaryKey : struct
            where Context : ISqlDBDapperContext
    {
        protected ISqlDBDapperContext DBContext { get; private set; }
        public BaseSqlDBDapperRepository(ISqlDBDapperContext dbContext)
        {
            DBContext = dbContext;
        }
        #region insert

        public virtual async Task<TDocument> AddOneAsync(TDocument model)
        {
            await DBContext.DbConnection.InsertAsync(model, DBContext.DbTransaction);
            return model;
        }

        #endregion

        #region update

        public virtual async Task<bool> UpdateOneAsync(TDocument model)
        {
            return (await DBContext.DbConnection.UpdateAsync(model, DBContext.DbTransaction));
        }

        #endregion

        public virtual async Task<int> DeleteAsync(TDocument model)
        {
            bool isOk = (await DBContext.DbConnection.DeleteAsync(model, DBContext.DbTransaction));
            return 1;
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
            return (await DBContext.DbConnection.QuerySingleOrDefaultAsync(predicate.ToSql()) != null);
        }
        public virtual async Task<int> CountAsync()
        {

            throw new NotImplementedException();
        }
        public virtual async Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<TDocument> GetByIdAsync(TPrimaryKey id)
        {
            Expression<Func<TDocument, bool>> predicate = (x => x.Id.ToString() == id.ToString());
            return (await DBContext.DbConnection.QuerySingleOrDefaultAsync(predicate.ToSql()));
        }

        public virtual async Task TruncateAsync()
        {
            throw new NotImplementedException();
        }
    }
}