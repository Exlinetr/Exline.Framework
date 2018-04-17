using System.Threading.Tasks;

namespace Exline.Framework.Data
{
    public interface IDBContext
    {
        Task DropAsync();
    }
}