using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Exline.Framework.Data.Repositories
{
    public interface IRepository<TDocument>
        :IRepository<TDocument,int>
        where TDocument:class, IDocument<int>, new()
    {
        
    }
    
    public interface IRepository<TDocument,TPrimaryKey>
        where TDocument:class, IDocument<TPrimaryKey>, new()
            
    {
        Task<TDocument> AddOneAsync(TDocument model);
        Task<bool> ExistsAsync(Expression<Func<TDocument, bool>> predicate);
        Task<bool> UpdateOneAsync(TDocument model);
        Task<int> DeleteAsync(TDocument model);
        Task<int> DeleteByIdAsync(TPrimaryKey id);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TDocument, bool>> predicate);
        Task<IEnumerable<TDocument>> WhereAsync(Expression<Func<TDocument, bool>> predicate);
        Task<TDocument> FirstAsync(Expression<Func<TDocument, bool>> predicate);
        Task<TDocument> GetByIdAsync(TPrimaryKey id);
        Task TruncateAsync();
    }
}