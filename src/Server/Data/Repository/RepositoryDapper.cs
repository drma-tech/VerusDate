using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Core;
using VerusDate.Shared.Handles;

namespace VerusDate.Server.Data.Repository
{
    public sealed class RepositoryDapper : IRepository, IDisposable
    {
        private readonly IDbConnection _conn;
        private IDbTransaction _trans;

        public RepositoryDapper(IConfiguration config)
        {
            SqlMapper.AddTypeHandler(new IntentTypeHandler());
            SqlMapper.AddTypeHandler(new StringTypeHandler());

            _conn = new SqlConnection(config.GetConnectionString("SQL"));
        }

        #region TRANSACTIONS

        public void BeginTransaction()
        {
            if (_conn.State != ConnectionState.Open) _conn.Open();
            _trans = _conn.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _trans?.Commit();
                _trans?.Connection?.Close();
            }
            catch
            {
                _trans?.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _trans?.Rollback();
            _trans?.Connection?.Close();
        }

        #endregion TRANSACTIONS

        #region QUERIES

        public async Task<T> GetValue<T>(StringBuilder sb, object param = null) where T : IComparable, IConvertible, IEquatable<T>
        {
            return await _conn.ExecuteScalarAsync<T>(sb.ToString(), param, _trans);
        }

        public async Task<T> Get<T>(object id) where T : ViewModelType
        {
            return await _conn.GetAsync<T>(id, _trans);
        }

        public async Task<T> Get<T>(StringBuilder sb, object param = null) where T : ViewModelType
        {
            return await _conn.QuerySingleOrDefaultAsync<T>(sb.ToString(), param, _trans);
        }

        public async Task<IEnumerable<T>> Query<T>(StringBuilder sb, object param = null, CancellationToken cancellationToken = default) where T : ViewModelType
        {
            return await _conn.QueryAsync<T>(new CommandDefinition(sb.ToString(), param, _trans, cancellationToken: cancellationToken));
        }

        #endregion QUERIES

        #region COMMANDS

        public async Task<bool> Insert<E>(E vm) where E : ViewModelType
        {
            await _conn.InsertAsync(vm, _trans);
            return true;
        }

        public async Task<bool> Update<E>(E vm) where E : ViewModelType
        {
            return await _conn.UpdateAsync(vm, _trans);
        }

        public async Task<bool> Delete<E>(E vm) where E : ViewModelType
        {
            return await _conn.DeleteAsync(vm, _trans);
        }

        public async Task<int> Execute(StringBuilder sb, object param = null, CancellationToken cancellationToken = default)
        {
            return await _conn.ExecuteAsync(new CommandDefinition(sb.ToString(), param, _trans, cancellationToken: cancellationToken));
        }

        public async Task<int> BulkInsert<T>(IEnumerable<T> lst, CancellationToken cancellationToken = default) where T : ViewModelType
        {
            var sqls = new DapperExtensions().GetDynamicQuery(lst);
            int total = 0;

            foreach (var sql in sqls)
            {
                total += await _conn.ExecuteAsync(new CommandDefinition(sql, null, _trans, cancellationToken: cancellationToken));
            }

            return total;
        }

        #endregion COMMANDS

        public void Dispose()
        {
            _conn?.Dispose();
            _trans?.Dispose();
        }
    }
}