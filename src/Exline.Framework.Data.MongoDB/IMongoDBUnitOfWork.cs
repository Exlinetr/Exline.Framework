namespace Exline.Framework.Data.MongoDB
{
    public interface IMongoDBUnitOfWork
        : IUnitOfWork
    {
        IMongoDBContext DbContext {get;}
    }
}