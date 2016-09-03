﻿using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.EntityFrameworkCore.Query;
//using Microsoft.Data.Entity.Query;
//using Microsoft.Data.Entity.Update.Internal;

namespace Star4Cast.Logging
{
    public class SqlLoggerProvider : ILoggerProvider
    {
        private static readonly string[] _whitelist = new string[]
        {
                typeof(BatchExecutor).FullName,
                typeof(QueryContextFactory).FullName
        };

        public ILogger CreateLogger(string name)
        {
            if(_whitelist.Contains(name))
            {
                return new SqlLogger();
            }

            return NullLogger.Instance;
        }

        public void Dispose()
        { }
    }
}
