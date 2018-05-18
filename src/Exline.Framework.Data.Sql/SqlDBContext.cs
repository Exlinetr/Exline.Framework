using System.Threading.Tasks;

namespace Exline.Framework.Data.Sql
{
    public class SqlDBContext
        : BaseDBContext, ISqlDBContext
    {
        protected SqlDBContext()
        {
            
        }

        public override void Dispose()
        {
        }

        public override Task DropAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}