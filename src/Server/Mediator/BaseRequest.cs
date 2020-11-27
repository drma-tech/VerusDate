using Dapper.Contrib.Extensions;
using MediatR;

namespace VerusDate.Server.Mediator
{
    public class BaseCommandQuery<T> : IRequest<T>
    {
        /// <summary>
        /// Id do Usuário (Recuperado do Token)
        /// </summary>
        [Computed]
        public string IdUser { get; set; }
    }

    public interface IBaseCommand<out T> : IRequest<T>
    {
        /// <summary>
        /// Id com mesmo valor do IdUser (Recuperado do Token)
        /// </summary>
        public string Id { get; set; }
    }
}