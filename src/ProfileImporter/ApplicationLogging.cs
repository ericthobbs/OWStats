using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ProfileImporter
{
    public class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory().AddConsole();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();

        public const int SettingsEvent = 1000;
    }
}
