using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Data.InMemory
{
    public interface IMemoryDBContext
        : IDBContext
    {
        
        IList<TDocument> GetCollection<TDocument>() 
             where TDocument:class,IDocument;
    }
}