using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using VerusDate.Api.Repository;
using VerusDate.Shared.Helper;

namespace VerusDate.Api.Core
{
    public class CustomLogger : ILogger
    {
        private readonly string _name;
        private readonly CosmosLogRepository _log;

        public CustomLogger(string name, CosmosLogRepository log)
        {
            _name = name;
            _log = log;
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (exception is NotificationException)
            {
                return;
            }

            _ = _log.Add(new LogContainer()
            {
                Name = _name,
                State = formatter(state, exception),
                Message = exception?.Message,
                StackTrace = exception?.StackTrace
            });
        }
    }

    public sealed class CosmosLoggerProvider : ILoggerProvider
    {
        private readonly CosmosLogRepository _log;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CosmosLoggerProvider(CosmosLogRepository log)
        {
            _log = log;
        }

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _log));

        public void Dispose() => _loggers.Clear();
    }
}