using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Core;

namespace VerusDate.Server.Core.Interface
{
    public interface IRepository
    {
        #region TRANSACTIONS

        /// <summary>
        /// Inicia uma nova transação
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Confirma todas as operações no banco de dados
        /// </summary>
        void Commit();

        /// <summary>
        /// Desfaz todas as operações no banco de dados
        /// </summary>
        void Rollback();

        #endregion TRANSACTIONS

        #region QUERIES

        /// <summary>
        /// Retorna um único valor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sb"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<T> GetValue<T>(StringBuilder sb, object param = null) where T : IComparable, IConvertible, IEquatable<T>;

        /// <summary>
        /// Retorna um único objeto (campo chave única)
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<V> Get<V>(object id) where V : ViewModelType;

        /// <summary>
        /// Retorna um único objeto
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="sb"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<V> Get<V>(StringBuilder sb, object param = null) where V : ViewModelType;

        /// <summary>
        /// Retorna uma lista de objetos
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="sb"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<E>> Query<E>(StringBuilder sb, object param = null, CancellationToken cancellationToken = default) where E : ViewModelType;

        #endregion QUERIES

        #region COMMANDS

        /// <summary>
        /// Insere um registro na tabela
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="vm"></param>
        /// <returns></returns>
        Task<bool> Insert<V>(V vm) where V : ViewModelType;

        /// <summary>
        /// Atualiza um registro na tabela
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="vm"></param>
        /// <returns></returns>
        Task<bool> Update<V>(V vm) where V : ViewModelType;

        /// <summary>
        /// Deleta um registro na tabela
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="vm"></param>
        /// <returns></returns>
        Task<bool> Delete<V>(V vm) where V : ViewModelType;

        /// <summary>
        /// Executa um comando/script no banco de dados
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> Execute(StringBuilder sb, object param = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Insere vários registros na tabela. (Não é seguro para trabalhar com dados vindos diretamente do usuário)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> BulkInsert<T>(IEnumerable<T> lst, CancellationToken cancellationToken = default) where T : ViewModelType;

        #endregion COMMANDS
    }
}