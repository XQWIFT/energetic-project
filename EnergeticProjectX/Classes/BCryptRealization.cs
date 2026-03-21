using BC = BCrypt.Net.BCrypt;

namespace BCrypt
{
    public class BCryptRealization
    {
        public string PasswordHash(string password)
        {
            var passwordHash = BC.HashPassword(password);
            return passwordHash;
        }

        public bool CheckPassword(string password, string passwordHash)
        {
            var isChecked = BC.Verify(password, passwordHash);
            return passwordHash != null ? isChecked: false;
        }
    }
}
