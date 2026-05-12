using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationContextDB _db;

        public UserRepository(ApplicationContextDB db)
        {
            _db = db;
        }
        public User FindUserByLogin(string login)
        {
            var user = _db.Users.FirstOrDefault(u => u.Login == login);
            return user;
        }
    }
}
