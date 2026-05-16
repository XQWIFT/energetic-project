using EnergeticProjectX.Classes;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.RepositoriesAndServices
{
    internal class UserRepository(ApplicationContextDB db) : IUserRepository
    {
        public bool SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
        }

        public User? FindUserById(Guid userId)
        {
            var user = db.Users.FirstOrDefault(c => c.User_Id == userId);

            return user;
        }

        public Dictionary<Guid, User> GetUsersInDictionary()
        {
            var users = db.Users.ToDictionary(u => u.User_Id, u => u);

            return users;
        }

        public User? FindUserByLogin(string login)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == login);

            return user;
        }

        public List<string> FindAllLogins()
        {
            var logins = db.Users.Select(u => u.Login).ToList();

            return logins;
        }

        public Currency? GetCurrencyById(Guid id)
        {
            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == id);

            return currency;
        }

        public Currency? GetCurrency(string code)
        {
            var currency = db.Currencies.FirstOrDefault(u => u.Code == code);

            return currency;
        }

        public Currency? FindUserCurrency(User user)
        {
            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

            return currency;
        }

        public List<Currency> GetAllCurrencies()
        {
            var currencies = db.Currencies.ToList();

            return currencies;
        }

        public int GetAllUsersCount()
        {
            int count = db.Users.Count();

            return count;
        }

        public List<UserDisplayModel> DisplayUsers()
        {
            var usersModel = db.Users
                    .Select(u => new UserDisplayModel
                    {
                        Surname = u.Surname,
                        Name = u.Name,
                        Patronymic = u.Patronymic,
                        UserRole = EnumHandler.GetUserRole(u.UserRole)
                    })
                    .ToList();

            return usersModel;
        }
    }
}
