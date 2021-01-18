using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerusDate.Api.Mediator
{
    public abstract class MediatorQuery<T> : IRequest<T>
    {
        public string IdLoggedUser { get; private set; }

        public void SetIds(string IdLoggedUser)
        {
            this.IdLoggedUser = IdLoggedUser;
        }

        public abstract void SetParameters(IQueryCollection query);
    }
}