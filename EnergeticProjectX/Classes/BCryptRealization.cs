using BC = BCrypt.Net.BCrypt;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для реализации шифрования/расшифрования пароля
    /// </summary>
    public class BCryptRealization
    {
        /// <summary>
        /// Метод позволяющий зашифровать пароль
        /// </summary>
        public string PasswordHash(string password)
        {
            var passwordHash = BC.HashPassword(password);
            return passwordHash;
        }

        /// <summary>
        /// Метод позволяющий расшифровать пароль
        /// </summary>
        public bool CheckPassword(string password, string passwordHash)
        {
            var isChecked = BC.Verify(password, passwordHash);
            return passwordHash != null ? isChecked: false;
        }
    }
}
