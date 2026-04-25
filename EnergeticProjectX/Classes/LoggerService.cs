using Microsoft.Extensions.Logging;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Сервис для логирования событий приложения.
    /// </summary>
    public class LoggerService
    {
        private static ILoggerFactory? _factory;
        private static ILogger? _logger;

        /// <summary>
        /// Получение логгера для указанного типа через обобщение.
        /// </summary>
        private static ILogger<T> GetLogger<T>()
        {
            _factory ??= LoggerFactory.Create(builder =>
                {
                    builder
                        .AddFile("logs/app.log", LogLevel.Debug)
                        .SetMinimumLevel(LogLevel.Debug);
                });

            _logger ??= _factory.CreateLogger<T>();
            return (ILogger<T>)_logger;
        }

        /// <summary>
        /// Information: Логирование информации.
        /// </summary>
        public static void Info(string message) =>
            GetLogger<LoggerService>().LogInformation("{Message}", message);

        /// <summary>
        /// Error: Логирование ошибки.
        /// </summary>
        public static void Error(string message, Exception? ex = null) =>
            GetLogger<LoggerService>().LogError(ex, "{Message}", message);

        /// <summary>
        /// Debug: Логирование отладочной информации.
        /// </summary>
        public static void Debug(string message) =>
            GetLogger<LoggerService>().LogDebug("{Message}", message);

        /// <summary>
        /// Warning: Логирование предупреждения.
        /// </summary>
        public static void Warning(string message) =>
            GetLogger<LoggerService>().LogWarning("{Message}", message);

        /// <summary>
        /// Critical: Логирование критической ошибки.
        /// </summary>
        public static void Fatal(string message, Exception? ex = null) =>
            GetLogger<LoggerService>().LogCritical(ex, "{Message}", message);

        /// <summary>
        /// Trace: Логирование трассировки.
        /// </summary>
        public static void Trace(string message) =>
            GetLogger<LoggerService>().LogTrace("{Message}", message);
    }
}
