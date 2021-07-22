using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreServer;
using Microsoft.Extensions.Logging;

namespace BookStore.Tests
{
  internal class LoggerMock<T> : ILogger<T>
  {
    public IDisposable BeginScope<TState>(TState state)
    {
      return state as IDisposable;
    }

    public bool IsEnabled(LogLevel loglevel)
    {
      return false;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {

    }
  }
}
