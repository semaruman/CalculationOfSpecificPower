using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationOfSpecificPowerConsole.Common
{
    public static class LoggingFactory
    {
        private static readonly ILoggerFactory _factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });

        public static ILogger CreateLogger(string s) => _factory.CreateLogger(s);
    }
}
