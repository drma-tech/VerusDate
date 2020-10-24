using System;
using System.Data;

namespace VerusDate.Server.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction Transaction { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}