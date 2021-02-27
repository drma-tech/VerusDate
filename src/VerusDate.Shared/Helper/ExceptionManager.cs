using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace VerusDate.Shared.Helper
{
    [Serializable]
    public class NotificationException : Exception
    {
        public NotificationException() : base()
        {
        }

        public NotificationException(string message) : base(message)
        {
        }

        public NotificationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotificationException(HttpResponseMessage response) : base(response?.Content.ReadAsStringAsync().Result)
        {
        }

        protected NotificationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}