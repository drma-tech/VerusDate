using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using VerusDate.Api.Repository;

namespace VerusDate.Api.Core
{
    public class LoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
    }

    public class CosmosLogger : ILogger
    {
        private readonly string _name;
        private readonly LoggerConfiguration _config;
        private readonly CosmosLogRepository _log;

        public CosmosLogger(string name, LoggerConfiguration config, CosmosLogRepository log)
        {
            _name = name;
            _config = config;
            _log = log;
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _config.LogLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
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
        private readonly LoggerConfiguration _config;
        private readonly CosmosLogRepository _log;
        private readonly ConcurrentDictionary<string, CosmosLogger> _loggers = new ConcurrentDictionary<string, CosmosLogger>();

        public CosmosLoggerProvider(LoggerConfiguration config, CosmosLogRepository log)
        {
            _config = config;
            _log = log;
        }

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new CosmosLogger(name, _config, _log));

        public void Dispose() => _loggers.Clear();
    }
}