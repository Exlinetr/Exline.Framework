using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Exline.Framework.Data.Repositories
{
    public interface IRepository<TEntity>
        :IRepository<TEntity,int>
        where TEntity:class, IDocument<int>, new()
    {
        
    }
    
    public interface IRepository<TEntity,TPrimaryKey>
        where TEntity:class, IDocument<TPrimaryKey>, new()
            
    {
        Task<TEntity> AddOneAsync(TEntity model);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> UpdateOneAsync(TEntity model);
        Task<int> DeleteAsync(TEntity model);
        Task<int> DeleteByIdAsync(TPrimaryKey id);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(TPrimaryKey id);
    }
}