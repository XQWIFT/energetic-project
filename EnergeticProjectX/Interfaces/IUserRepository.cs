using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public interface IUserRepository
    {
        public bool SaveChanges();

        public void AddUser(User user);

        public User? FindUserById(Guid userId);

        public Dictionary<Guid, User> GetUsersInDictionary();

        public User? FindUserByLogin(string login);

        public List<string> FindAllLogins();

        public Currency? GetCurrencyById(Guid currencyId);

        public Currency? GetCurrency(string code);

        public Currency? FindUserCurrency(User user);

        public List<Currency> GetAllCurrencies();

        public int GetAllUsersCount();

        public List<UserDisplayModel> DisplayUsers();
    }
}