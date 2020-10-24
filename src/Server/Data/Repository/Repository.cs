using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RealDate.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Core;

namespace VerusDate.Server.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _conn;
        public IUnitOfWork UnitOfWork { get; }

        public Repository(IConfiguration configuration)
        {
            _conn = new SqlConnection(configuration.GetConnectionString("SQL"));
            UnitOfWork = new UnitOfWorkDapper(_conn);
        }

        public async Task<T> GetValue<T>(string sql, object param) where T : IComparable, IConvertible, IEquatable<T>
        {
            return await _conn.ExecuteScalarAsync<T>(sql, param, UnitOfWork.Transaction);
        }

        public async Task<T> Get<T>(object id) where T : ViewModelType
        {
            return await _conn.GetAsync<T>(id, UnitOfWork.Transaction);
        }

        public async Task<T> Get<T>(string sql, object param) where T : ViewModelType
        {
            return await _conn.QuerySingleOrDefaultAsync<T>(sql, param, UnitOfWork.Transaction);
        }

        public async Task<IEnumerable<T>> Query<T>(string sql, object param, CancellationToken cancellationToken) where T : ViewModelType
        {
            return await _conn.QueryAsync<T>(new CommandDefinition(sql, param, UnitOfWork.Transaction, cancellationToken: cancellationToken));
        }

        public async Task<bool> Insert<E>(E vm) where E : ViewModelType
        {
            await _conn.InsertAsync(vm, UnitOfWork.Transaction);
            return true;
        }

        public async Task<bool> Update<E>(E vm) where E : ViewModelType
        {
            return await _conn.UpdateAsync(vm, UnitOfWork.Transaction);
        }

        public async Task<bool> Delete<E>(E vm) where E : ViewModelType
        {
            return await _conn.DeleteAsync(vm, UnitOfWork.Transaction);
        }

        public async Task<bool> Execute(string sql, object param, CancellationToken cancellationToken)
        {
            await _conn.ExecuteAsync(new CommandDefinition(sql, null, UnitOfWork.Transaction, cancellationToken: cancellationToken));
            return true;
        }

        public async Task<bool> BulkInsert<T>(IEnumerable<T> lst, CancellationToken cancellationToken) where T : ViewModelType
        {
            var sqls = new DapperExtensions().GetDynamicQuery(lst);

            foreach (var sql in sqls)
            {
                await _conn.ExecuteAsync(new CommandDefinition(sql, null, UnitOfWork.Transaction, cancellationToken: cancellationToken));
            }

            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _conn?.Dispose();
            UnitOfWork?.Dispose();
        }
    }
}