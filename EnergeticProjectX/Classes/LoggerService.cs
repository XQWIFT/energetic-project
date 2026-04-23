using Microsoft.Extensions.Logging;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Сервис для логирования событий приложения
    /// </summary>
    public class LoggerService
    {
        private static ILoggerFactory? _factory;
        private static ILogger? _logger;

        /// <summary>
        /// Получение логгера для указанного типа
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
        /// Логирование информации (Information level)
        /// </summary>
        public static void Info(string message) =>
            GetLogger<LoggerService>().LogInformation("{Message}", message);

        /// <summary>
        /// Логирование ошибки (Error level)
        /// </summary>
        public static void Error(string message, Exception? ex = null) =>
            GetLogger<LoggerService>().LogError(ex, "{Message}", message);

        /// <summary>
        /// Логирование отладочной информации (Debug level)
        /// </summary>
        public static void Debug(string message) =>
            GetLogger<LoggerService>().LogDebug("{Message}", message);

        /// <summary>
        /// Логирование предупреждения (Warning level)
        /// </summary>
        public static void Warning(string message) =>
            GetLogger<LoggerService>().LogWarning("{Message}", message);

        /// <summary>
        /// Логирование критической ошибки (Critical level)
        /// </summary>
        public static void Fatal(string message, Exception? ex = null) =>
            GetLogger<LoggerService>().LogCritical(ex, "{Message}", message);

        /// <summary>
        /// Логирование трассировки (Trace level)
        /// </summary>
        public static void Trace(string message) =>
            GetLogger<LoggerService>().LogTrace("{Message}", message);
    }
}
