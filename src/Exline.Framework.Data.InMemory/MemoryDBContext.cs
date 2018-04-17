using System.Collections.Generic;
using System.Linq;

namespace Exline.Framework.Data.InMemory
{
    public sealed class MemoryDBContext
        : BaseDBContext,IMemoryDBContext
    {
        private readonly MemoryDatabase _database;

        public MemoryDBContext()
        {
            _database=new MemoryDatabase();
        }

        public IList<TDocument> GetCollection<TDocument, TPrimaryKey>()
            where TDocument:class,IDocument<TPrimaryKey>
        {
            return _database.Set<TDocument>();
        }
    }
}