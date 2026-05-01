namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для работы с локальным временем конкретного пользователя и временем UTC.
    /// </summary>
    public class TimeHandler
    {
        /// <summary>
        /// Метод, который переводит время UTC в местное время.
        /// </summary>
        /// <param name="utcDateTime">Время в UTC.</param>
        /// <returns>Местное время.</returns>
        public static DateTime UtcToLocalDateTime(DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Метод, который переводит дату UTC в местную дату.
        /// </summary>
        /// <param name="utcDateOnly">Дата в UTC.</param>
        /// <returns>Дата в местном времени.</returns>
        public static DateOnly UtcDateToLocalDateOnly(DateOnly utcDateOnly)
        {
            var utcDateTime = utcDateOnly.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);

            var localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Local);

            return DateOnly.FromDateTime(localDateTime);
        }

        /// <summary>
        /// Метод, который получает дату назначения скидки в UTC.
        /// </summary>
        /// <returns>Дата скидки в UTC.</returns>
        public static DateOnly GetDiscountUtcDate()
        {
            return DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(2);
        }

        /// <summary>
        /// Метод, который переводит дату с местного времени в дату UTC.
        /// </summary>
        /// <param name="localDateOnly">Дата в местном времени.</param>
        /// <returns>Дата в UTC.</returns>
        public static DateOnly LocalDateOnlyToUtcDate(DateOnly localDateOnly)
        {
            var localDateTime = localDateOnly.ToDateTime(TimeOnly.MinValue, DateTimeKind.Local);

            var utcDateTime = localDateTime.ToUniversalTime();

            return DateOnly.FromDateTime(utcDateTime);
        }
    }
}
