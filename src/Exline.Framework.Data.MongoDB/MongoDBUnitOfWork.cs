using System;
using System.Threading.Tasks;

namespace Exline.Framework.Data.MongoDB
{
    public class MongoDBUnitOfWork
        : IMongoDBUnitOfWork
    {
        private readonly IMongoDBContextConfig _dbContextConfig;
        private IMongoDBContext _dbContext;

        public IMongoDBContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public event EventHandler Completed;
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;
        public event EventHandler Disposed;

        public MongoDBUnitOfWork(IMongoDBContextConfig dbContextConfig)
        {
            _dbContextConfig=dbContextConfig;
        }

        public void Begin()
        {
            _dbContext=new MongoDBContext(_dbContextConfig);
        }

        public async Task SaveChangesAsync()
        {

        }
    }
}