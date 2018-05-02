using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exline.Framework.Data.Sql.Dapper
{
    public sealed class SqlDBDapperContext
       : BaseDBContext, ISqlDBDapperContext
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _dbTransaction;
        private readonly ISqlDBContextConfig _contextConfig;
        public SqlDBDapperContext(ISqlDBContextConfig contextConfig)
        {
            if (contextConfig is null)
                throw new ArgumentNullException(nameof(contextConfig));

            _contextConfig = contextConfig;
            _dbConnection = new SqlConnection(_contextConfig.ToConnectionString());
            _dbConnection.Open();
            _dbTransaction = _dbConnection.BeginTransaction();
        }

        public IDbTransaction DbTransaction => _dbTransaction;

        public IDbConnection DbConnection => _dbConnection;

        public override async Task DropAsync()
        {
            
        }
    }
}