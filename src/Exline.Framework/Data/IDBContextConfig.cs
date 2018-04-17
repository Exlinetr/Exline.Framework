namespace Exline.Framework.Data
{
    public interface IDBContextConfig
    {   
        string Host { get; set; }
        string DatabaseName { get; set; }
        string Username{get;set;}
        string Password{get;set;}
        int Port{get;set;}

        string ToConnectionString();
        void SetServerInfo(string host,int port,string dbName);
        void SetServerInfo(string host,string dbName);
        void SetCredential(string username,string password);
    }
}