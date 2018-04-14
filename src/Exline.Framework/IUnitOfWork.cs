
using System;
using System.Threading.Tasks;

public interface IUnitOfWork
{
    event EventHandler Completed;
    event EventHandler<UnitOfWorkFailedEventArgs> Failed;
    event EventHandler Disposed;

    Task SaveChangesAsync();
    void Begin();
}