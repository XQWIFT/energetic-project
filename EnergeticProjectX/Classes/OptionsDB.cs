namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для описания структуры JSON файла с данными для подключения к базе данных.
    /// </summary>
    public class OptionsDB
    {
        /// <summary>
        /// Хост для подключения.
        /// </summary>
        public required string Host { get; set; }

        /// <summary>
        /// Порт для подключения.
        /// </summary>
        public required string Port { get; set; }

        /// <summary>
        /// Название базы данных.
        /// </summary>
        public required string Database { get; set; }
        
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public required string Password { get; set; }
    }
}
