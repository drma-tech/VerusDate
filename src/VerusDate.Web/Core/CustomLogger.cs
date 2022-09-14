using System.Collections.Concurrent;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Core
{
    public class LogContainer
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }

    public class CustomLogger : ILogger
    {
        private readonly string _name;

        public CustomLogger(string name)
        {
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (exception is NotificationException)
            {
                return;
            }

            var storage = ComponenteUtils.Storage;
            var list = new List<LogContainer>();

            if (storage != null && storage.ContainKey("LogErrosVD"))
            {
                list = storage.GetItem<List<LogContainer>>("LogErrosVD");
            }

            list.Add(new LogContainer()
            {
                Name = _name,
                State = formatter(state, exception),
                Message = exception?.Message,
                StackTrace = exception?.StackTrace
            });

            storage?.SetItem("LogErrosVD", list);
        }
    }

    public sealed class CosmosLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new();

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new CustomLogger(name));

        public void Dispose() => _loggers.Clear();
    }
}