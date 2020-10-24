using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Core;

namespace VerusDate.Server.Core.Interface
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> GetValue<T>(string sql, object param) where T : IComparable, IConvertible, IEquatable<T>;

        Task<V> Get<V>(object id) where V : ViewModelType;

        Task<V> Get<V>(string sql, object param) where V : ViewModelType;

        Task<IEnumerable<E>> Query<E>(string sql, object param, CancellationToken cancellationToken) where E : ViewModelType;

        Task<bool> Insert<V>(V vm) where V : ViewModelType;

        Task<bool> Update<V>(V vm) where V : ViewModelType;

        Task<bool> Delete<V>(V vm) where V : ViewModelType;

        Task<bool> Execute(string sql, object param, CancellationToken cancellationToken);

        Task<bool> BulkInsert<T>(IEnumerable<T> lst, CancellationToken cancellationToken) where T : ViewModelType;
    }
}