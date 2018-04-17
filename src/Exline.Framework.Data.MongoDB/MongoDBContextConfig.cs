namespace Exline.Framework.Data.MongoDB
{
    public class MongoDBContextConfig
        : IMongoDBContextConfig
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

        public MongoDBContextConfig()
        {
            Port=27017;
        }

        public string ToConnectionString()
        {
            if(string.IsNullOrEmpty(Username))
                return $"mongodb://{Host}:{Port}";

            return $"mongodb://{Username}:{Password}@{Host}:{Port}/{DatabaseName}";
        }

        public void SetServerInfo(string host, int port, string dbName)
        {
            Host=host;
            Port=port;
            DatabaseName=dbName;
        }
        public void SetServerInfo(string host, string dbName)
        {
            SetServerInfo(host,27017,dbName);
        }

        public void SetCredential(string username, string password)
        {
            Username=username;
            Password=password;
        }
    }
}