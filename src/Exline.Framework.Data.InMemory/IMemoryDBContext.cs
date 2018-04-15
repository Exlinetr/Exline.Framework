using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Data.InMemory
{
    public interface IMemoryDBContext
        : IDBContext
    {
        
        IQueryable<TDocument> GetCollection<TDocument,TPrimaryKey>() 
             where TDocument:class,IDocument<TPrimaryKey>;
    }
}