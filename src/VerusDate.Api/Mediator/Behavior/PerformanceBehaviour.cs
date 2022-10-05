using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Behavior
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _log;

        public PerformanceBehaviour(ILogger<TRequest> log)
        {
            _timer = new Stopwatch();
            _log = log;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;

            try
            {
                _timer.Start();

                response = await next();
            }
            finally
            {
                _timer.Stop();

                if (_timer.ElapsedMilliseconds > 500)
                {
                    _log.LogWarning($"Processing time: {_timer.ElapsedMilliseconds} milliseconds", typeof(TRequest).Name, request);
                }
            }

            return response;
        }
    }
}