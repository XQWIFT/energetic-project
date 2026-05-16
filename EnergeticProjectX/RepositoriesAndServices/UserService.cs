using EnergeticProjectX.Classes;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.RepositoriesAndServices
{
    public class UserService(IUserRepository repository) : IUserService
    {
        public bool SaveChanges()
        {
            return repository.SaveChanges();
        }

        public bool DbSaveChangesErrorCheck()
        {
            try
            {
                repository.SaveChanges();
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }

        public User? EnsureUserActive(string userLogin)
        {
            var user = FindByLogin(userLogin);

            return user;
        }

        public void AddUser(User user)
        {
            repository.AddUser(user);
        }

        public User? FindUserById(Guid id)
        {
            var user = repository.FindUserById(id);

            return user;
        }

        public User? FindByLogin(string login)
        {
            var user = repository.FindUserByLogin(login);

            return user;
        }

        public bool IsUserLoginFree(string login)
        {
            var logins = repository.FindAllLogins();

            return !logins.Contains(login);
        }

        public void ChangePassword(User user, string newPassword)
        {
            user.Password = BCryptRealization.PasswordHash(newPassword);
            SaveChanges();
        }

        public (bool, string?) IsAllPasswordsValid(User user, string oldPassword, string newPassword,
                                               string confirmationPassword)
        {
            if (!BCryptRealization.CheckPassword(oldPassword, user.Password))
                return (false, Resources.IncorrectOldPassword);

            if (newPassword != confirmationPassword)
                return (false, Resources.UnmatchedNewPasswords);

            if (IsNewPasswordSatisfyRequirements(newPassword))
                return (false, Resources.TooSimpleNewPassword);

            if (oldPassword == newPassword)
                return (false, Resources.OldAndNewPasswordsTheSame);

            return (true, null);
        }

        public bool IsNewPasswordSatisfyRequirements(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 8)
                return false;

            char[] symbolsInOldPassword = newPassword.ToCharArray();
            var hasDigit = false;
            var hasCapitalLetter = false;
            foreach (char symbol in symbolsInOldPassword)
            {
                if (char.IsDigit(symbol))
                    hasDigit = true;
                if (char.IsLetter(symbol))
                    if (char.IsUpper(symbol))
                        hasCapitalLetter = true;
            }

            var hasAtLeastEightSymbols = symbolsInOldPassword.Length >= 8;

            return hasDigit && hasCapitalLetter && hasAtLeastEightSymbols;
        }

        public Dictionary<Guid, User> GetUsersInDictionary()
        {
            var users = repository.GetUsersInDictionary();

            return users;
        }


        public int GetAllUsersCount()
        {
            var count = repository.GetAllUsersCount();

            return count;
        }

        public List<UserDisplayModel> DisplayUsers()
        {
            var usersModel = repository.DisplayUsers();

            return usersModel;
        }

        public Currency? GetCurrencyById(Guid id)
        {
            var currency = repository.GetCurrencyById(id);

            return currency;
        }

        public Currency? GetCurrency(string code)
        {
            var currency = repository.GetCurrency(code);

            return currency;
        }

        public List<Currency> GetAllCurrencies()
        {
            var currencies = repository.GetAllCurrencies();
            return currencies;
        }

        public Currency? FindUserChosenCurrency(User user)
        {
            var currency = repository.FindUserCurrency(user);

            return currency;
        }
    }
}
