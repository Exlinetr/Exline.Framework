using System.Threading.Tasks;

namespace Exline.Framework.Data
{
    public interface IDBContext
    {
        Task DropAsync();
        Task<bool> ExistsAsync<TDocument>(string collectionName=null)
            where TDocument:IDocument;
    }
}