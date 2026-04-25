using BC = BCrypt.Net.BCrypt;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для реализации хеширования пароля пользователя.
    /// </summary>
    public class BCryptRealization
    {
        /// <summary>
        /// Метод для хеширования пароля.
        /// </summary>
        public static string PasswordHash(string password)
        {
            var passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        /// <summary>
        /// Метод для сравнения заданного пароля с хешем.
        /// </summary>
        public static bool CheckPassword(string password, string passwordHash)
        {
            var isChecked = BC.Verify(password, passwordHash);

            return passwordHash != null && isChecked;
        }
    }
}
