using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Core;

namespace VerusDate.Api.Mediator.Behavior
{
    public class UserSessionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var idUser = "b9a10c8be2f244c0a625b78f05e30812";

            if (request is MediatorQuery<TResponse> query)
            {
                query.IdLoggedUser = idUser;
            }

            if (request is CosmosBase baseCommand)
            {
                baseCommand.SetIds(idUser);
            }

            return await next();
        }
    }
}