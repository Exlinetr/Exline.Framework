using System;
public class UnitOfWorkFailedEventArgs : EventArgs
{
    public Exception Exception {get;set;}
    public UnitOfWorkFailedEventArgs(Exception exception)
    {
        Exception=exception;
    }
}