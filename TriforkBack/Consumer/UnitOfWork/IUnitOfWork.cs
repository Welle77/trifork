using Consumer.Repository.Timestamps;
using System;

namespace Consumer
{
    public interface IUnitOfWork : IDisposable
    {
        ITimestampRepository Timestamps { get; }
        int CompleteTransaction();
    }
}
