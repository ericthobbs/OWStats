using Microsoft.Extensions.Logging;

namespace ProfileImporter
{
    public class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory().AddConsole();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();

        public const int SettingsEvent = 1000;
        public const int ImportEvent = 2000;
    }
}
