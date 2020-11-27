using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;

namespace VerusDate.Server.Mediator.Behavior
{
    public class UserSessionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly HttpContext httpContext;

        public UserSessionBehavior(IHttpContextAccessor accessor)
        {
            httpContext = accessor.HttpContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is BaseCommandQuery<TResponse> bq)
            {
                bq.IdUser = httpContext.GetUserId();
            }

            if (request is IBaseCommand<TResponse> bc)
            {
                bc.Id = httpContext.GetUserId();
            }

            return await next();
        }
    }
}