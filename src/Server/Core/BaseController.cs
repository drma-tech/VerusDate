using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VerusDate.Server.Core
{
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        private ILogger<T> _logger;
        private IMediator _mediator;

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}