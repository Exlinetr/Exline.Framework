using System.Data;

namespace Exline.Framework.Data.Sql.Dapper
{
    public interface ISqlDBDapperContext
        : ISqlDBContext
    {
        IDbTransaction DbTransaction { get; }
        IDbConnection DbConnection { get; }
        void Open();
        void OpenTranscation();
        void CommitTranscation();
    }
}
