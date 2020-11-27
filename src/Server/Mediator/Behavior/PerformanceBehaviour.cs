using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Server.Mediator.Behavior
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _log;

        public PerformanceBehaviour(ILogger<TRequest> log)
        {
            _timer = new Stopwatch();
            _log = log;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
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
                    _log.LogInformation($"Processing time: {_timer.ElapsedMilliseconds} milliseconds", typeof(TRequest).Name, request);
                }
            }

            return response;
        }
    }
}