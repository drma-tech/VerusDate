using System.Data;
using VerusDate.Server.Core.Interface;

namespace RealDate.Data.UnitOfWork
{
    public sealed class UnitOfWorkDapper : IUnitOfWork
    {
        private IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; private set; }

        internal UnitOfWorkDapper(IDbConnection connection)
        {
            Connection = connection;
        }

        public void BeginTransaction()
        {
            if (Connection.State != ConnectionState.Open) Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
                Transaction.Connection?.Close();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Transaction.Connection?.Close();
        }

        public void Dispose()
        {
            Connection?.Dispose();
            Transaction?.Dispose();
        }
    }
}