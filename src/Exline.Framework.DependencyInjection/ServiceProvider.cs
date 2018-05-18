using System;

namespace Exline.Framework.DependencyInjection
{
    public sealed class ServiceProvider
        : IServiceProvider, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}