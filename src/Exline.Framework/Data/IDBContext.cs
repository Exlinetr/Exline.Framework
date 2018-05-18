using System.Threading.Tasks;
using System;

namespace Exline.Framework.Data
{
    public interface IDBContext
        : IDisposable
    {
        Task DropAsync();
    }
}