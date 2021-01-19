using MediatR;
using Microsoft.AspNetCore.Http;
using VerusDate.Shared.Core;

namespace VerusDate.Api.Mediator
{
    public abstract class MediatorQuery<T> : IRequest<T>
    {
        protected MediatorQuery(CosmosType Type)
        {
            this.Type = Type;
        }

        public string Id { get; private set; }

        /// <summary>
        /// Id do usuário logado
        /// </summary>
        public string IdLoggedUser { get; private set; }

        /// <summary>
        /// Tipo da estrutura (geralmente o nome da classe)
        /// </summary>
        public CosmosType Type { get; private set; }

        public void SetIds(string IdLoggedUser)
        {
            Id = Type + ":" + IdLoggedUser;
            this.IdLoggedUser = IdLoggedUser;
        }

        public abstract void SetParameters(IQueryCollection query);
    }
}