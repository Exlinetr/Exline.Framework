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
    }
}