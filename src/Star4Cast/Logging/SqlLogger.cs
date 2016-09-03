﻿using Microsoft.Extensions.Logging;
using System;
using System.IO;


namespace Star4Cast.Logging
{
    public class SqlLogger :ILogger
    {
        private static readonly string _logFilePath = @"C:\temp\DatabaseLog.sql";

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var message = string.Format(
                "\n\n--{0}\n{1}",
                DateTime.Now,
                formatter(state, exception));//.Replace(", [", ",\n  ["));

            File.AppendAllText(_logFilePath, message);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return null;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = string.Format(
                "\n\n--{0}\n{1}",
                DateTime.Now,
                formatter(state, exception));//.Replace(", [", ",\n  ["));

            File.AppendAllText(_logFilePath, message);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
