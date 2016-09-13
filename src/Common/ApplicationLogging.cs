using Microsoft.Extensions.Logging;

namespace Common
{
    public class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();

        public const int SettingsEvent = 1000;
        public const int ImportEvent = 2000;

        // 3000 level errors are errors that occur during Html Parsing
        public const int SnapShowParseError = 3001;
    }
}
