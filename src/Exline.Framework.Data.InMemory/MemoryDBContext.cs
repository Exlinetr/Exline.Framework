using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public override async Task DropAsync()
        {
            _database.Drop();
        }

        public IList<TDocument> GetCollection<TDocument, TPrimaryKey>()
            where TDocument:class,IDocument<TPrimaryKey>
        {
            return _database.Set<TDocument>();
        }
    }
}