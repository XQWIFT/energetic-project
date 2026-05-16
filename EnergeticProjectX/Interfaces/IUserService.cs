using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.interfaces
{
    public interface IUserService
    {
        public bool SaveChanges();

        public bool DbSaveChangesErrorCheck();

        public User? EnsureUserActive(string userLogin);

        public void AddUser(User user);

        public User? FindUserById(Guid id);

        public User? FindByLogin(string login);

        public bool IsUserLoginFree(string login);

        public void ChangePassword(User user, string newPassword);

        public (bool, string?) IsAllPasswordsValid(User user, string oldPassword, string newPassword,
                                              string confirmationPassword);
        public bool IsNewPasswordSatisfyRequirements(string newPassword);

        public Dictionary<Guid, User> GetUsersInDictionary();

        public int GetAllUsersCount();

        public List<UserDisplayModel> DisplayUsers();

        public Currency? GetCurrencyById(Guid id);

        public Currency? GetCurrency(string code);

        public List<Currency> GetAllCurrencies();

        public Currency? FindUserChosenCurrency(User user);
    }
}
