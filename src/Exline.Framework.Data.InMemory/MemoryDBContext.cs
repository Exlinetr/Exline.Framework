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

        public override async Task<bool> ExistsAsync<TDocument>(string collectionName=null)
        {
            return _database.Exists<TDocument>(collectionName);
        }

        public IList<TDocument> GetCollection<TDocument>()
            where TDocument:class,IDocument        {
            return _database.Set<TDocument>();
        }
    }
}