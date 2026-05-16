using EnergeticProjectX.Enums;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text.RegularExpressions;
using EH = EnergeticProjectX.Classes.ErrorHandler;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс с реализацией методов для взаимодействия с пользовательским интерфейсом.
    /// </summary>
    public static class UIHelper
    {
        /// <summary>
        /// Проверка указанных личных данных на соответствие: отсутствие цифр.
        /// </summary>
        /// <param name="inputData">Входные данные.</param>
        /// <returns>При успешной проверке выводится строка с заглавным первым элементом и
        /// строчными остальными, иначе - null.</returns>
        public static string? IsUserPersonalDataRelevant(string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData))
                return null;

            var charInputDataArray = Regex.Replace(inputData, @"\s", "").ToCharArray();

            foreach (char symbol in charInputDataArray)
            {
                if (!char.IsLetter(symbol))
                    return null;
            }

            return char.ToUpper(inputData[0]) + inputData[1..].ToLower();
        }

        /// <summary>
        /// Проверка указанных данных на соответствие: пароль соответствует требованиям безопасности -
        /// минимум 8 символов, наличие заглавной латинской буквы и цифры и совпадает с паролем для
        /// подтверждения - повторным вводом пароля.
        /// </summary>
        /// <param name="password">Пароль от пользователя.</param>
        /// <param name="passwordConfirmation">Повторный ввод пароля от пользователя.</param>
        /// <returns>Подтверждение соответствия паролей и соответствие требования безопасности.</returns>
        public static (bool, bool) IsPasswordRelevant(string password, string passwordConfirmation)
        {
            var charPasswordArray = Regex.Replace(password, @"\s", "").ToCharArray();

            var hasDigit = false;
            var hasCapitalLetter = false;

            foreach (char symbol in charPasswordArray)
            {
                if (char.IsDigit(symbol))
                    hasDigit = true;
                else if (char.IsLetter(symbol) && char.IsUpper(symbol))
                    hasCapitalLetter = true;

                if (hasDigit && hasCapitalLetter)
                    break;
            }

            return (Regex.Replace(password, @"\s", "") == Regex.Replace(passwordConfirmation, @"\s", ""),
                   hasDigit && hasCapitalLetter && charPasswordArray.Length >= 8);
        }

        /// <summary>
        /// Метод, который получает значение символа выбранного курса валюты авторизованного пользователя.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <returns>Значение символа выбранного курса валюты или пустая строка.</returns>
        public static string GetCurrencySymbol(IUserService userService, string userLogin)
        {
            var user = userService.FindByLogin(userLogin);

            if (user == null)
            {
                EH.ShowWarning(Resources.ErrorUserDataUpload);

                return string.Empty;
            }

            var currency = userService.FindUserChosenCurrency(user);

            if (currency == null)
            {
                EH.ShowError(Resources.UserCurrencyNotFound, true);

                return string.Empty;
            }

            return currency?.CurrencySymbol ?? string.Empty;
        }

        /// <summary>
        /// Проверка на авторизованного пользователя, на корректность ввода старого пароля, нового и повторного
        /// пароля, на совпадение старого и нового паролей.
        /// </summary>
        /// <param name="user">Авторизованный пользователь.</param>
        /// <param name="oldPassword">Старый пароль.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <param name="confirmationPassword">Повтор нового пароля.</param>
        /// <returns>Подтверждение валидации и сообщение об ошибке при наличии.</returns>
        public static (bool, string?) IsAllPasswordsValid(User user, string oldPassword, string newPassword,
                                                string confirmationPassword)
        {
            if (!BCryptRealization.CheckPassword(oldPassword, user.Password))
                return (false, Resources.IncorrectOldPassword);

            if (newPassword != confirmationPassword)
                return (false, Resources.UnmatchedNewPasswords);

            if (!IsNewPasswordSatisfyRequirements(newPassword))
                return (false, Resources.TooSimpleNewPassword);

            if (oldPassword == newPassword)
                return (false, Resources.OldAndNewPasswordsTheSame);

            return (true, null);
        }

        /// <summary>
        /// Проверка пароля на соответствие требованиям безопасности: минимум 8 символов, хотя бы одна цифра
        /// и одна заглавная латинская буква.
        /// </summary>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>Подтверждение соответствия требованиям.</returns>
        public static bool IsNewPasswordSatisfyRequirements(string newPassword)
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

        /// <summary>
        /// Валидация вводимого пользователем ИНН в зависимости от заданного контрагента.
        /// Юр. лицо - комбинация из 10 цифр, Физ. лицо или ИП - комбинация из 12 цифр.
        /// </summary>
        /// <param name="iNN">Идентификационный номер нового клиента.</param>
        /// <param name="contractorType">Контрагент.</param>
        /// <returns>Подтверждение валидации.</returns>
        public static bool ValidateINN(string iNN, string contractorTypeString)
        {
            if (string.IsNullOrWhiteSpace(iNN)) return false;

            iNN = iNN.Replace(" ", "");

            if (!Regex.IsMatch(iNN, @"^\d+$")) return false;

            var contractorType = EnumHandler.SetContractorType(contractorTypeString);

            return contractorType switch
            {
                Contractors.LegalEntity => iNN.Length == 10,
                Contractors.PhysicalPerson or Contractors.IndividualEntrepreneur => iNN.Length == 12,
                _ => false
            };
        }

        /// <summary>
        /// Получение ошибки, связанной с валидацией ИНН.
        /// Юр. лицо - комбинация из 10 цифр, Физ. лицо или ИП - комбинация из 12 цифр.
        /// </summary>
        /// <param name="contractorTypeString">Тип контрагента в строком представлении.</param>
        /// <returns>Сообщение об ошибке.</returns>
        public static string GetINNErrorMessage(string contractorTypeString)
        {
            var contractorType = EnumHandler.SetContractorType(contractorTypeString);
            if (contractorType == Contractors.LegalEntity)
                return Resources.INNRequirementsTenDigits;
            else if (contractorType == Contractors.PhysicalPerson || contractorType == Contractors.IndividualEntrepreneur)
                return Resources.INNRequirementsTwelveDigits;
            else
                return Resources.INNFormatError;
        }
    }
}
