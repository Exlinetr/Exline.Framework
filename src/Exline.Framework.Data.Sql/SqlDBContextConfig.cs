using System.Threading.Tasks;

namespace Exline.Framework.Data.Sql
{
    public class SqlDBContextConfig
        : ISqlDBContextConfig
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

        public SqlDBContextConfig()
        {
            Host = "127.0.0.1";
            Port = 1433;
        }

        public string ToConnectionString()
        {
            if (string.IsNullOrEmpty(Username))
                return $"Server={Host};Database={DatabaseName};Trusted_Connection=True;";

            return $"Server={Host},{Port};Database={DatabaseName};User Id={Username};Password={Password};";
        }

        public void SetServerInfo(string host, int port, string dbName)
        {
            Host = host;
            Port = port;
            DatabaseName = dbName;
        }
        public void SetServerInfo(string host, string dbName)
        {
            SetServerInfo(host, 1433, dbName);
        }

        public void SetCredential(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}