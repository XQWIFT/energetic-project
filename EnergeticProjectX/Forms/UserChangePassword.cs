using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для изменения пароля пользователя.
    /// </summary>
    public partial class UserChangePassword : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы изменения пароля.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public UserChangePassword(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfSaveInfo.Enabled = !string.IsNullOrWhiteSpace(TextBoxForOldPassword.Text) &&
                                       !string.IsNullOrWhiteSpace(TextBoxForNewPassword.Text) &&
                                       !string.IsNullOrEmpty(TextBoxOfConfirmation.Text);
        }

        private void ButtonOfSaveInfo_Click(object sender, EventArgs e)
        {
            var oldPassword = TextBoxForOldPassword.Text.Trim();
            var newPassword = TextBoxForNewPassword.Text.Trim();
            var confirmationPassword = TextBoxOfConfirmation.Text.Trim();

            ChangePassword(oldPassword, newPassword, confirmationPassword);
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            OpenMainMenu(userLogin);
        }

        private void ChangePassword(string oldPassword, string newPassword, string confirmationPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }

            (var loginAndPasswordValid, var messageOfError) = IsAllPasswordsValid(oldPassword, newPassword, confirmationPassword, db, userLogin);

            if (loginAndPasswordValid)
            {
                user.Password = BCryptRealization.PasswordHash(newPassword);

                if (EH.DBSaveChangesUniversalErrorCheck(db))
                    return;

                EH.ShowInformation(Resources.ChangePasswordEvent);

                if (user.UserRole == UserRole.Administrator)
                {
                    Hide();
                    var administratorPanel = new AdministratorPanel(userLogin);
                    administratorPanel.ShowDialog();
                    Close();
                }
                else if (user.UserRole == UserRole.Warehouseman)
                {
                    Hide();
                    var warehousemanPanel = new WarehousemanPanel(userLogin);
                    warehousemanPanel.ShowDialog();
                    Close();
                }
            }
            else if (messageOfError == Resources.UserNotFound)
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }
            else if (messageOfError == Resources.IncorrectOldPassword)
            {
                EH.ShowWarning(Resources.IncorrectOldPassword, true);

                TextBoxForOldPassword.Clear();
                TextBoxForNewPassword.Clear();
                TextBoxOfConfirmation.Clear();
                TextBoxForOldPassword.Focus();
            }
            else if (messageOfError == Resources.UnmatchedNewPasswords)
            {
                EH.ShowWarning(Resources.UnmatchedNewPasswords, true);

                TextBoxForNewPassword.Clear();
                TextBoxOfConfirmation.Clear();
                TextBoxForNewPassword.Focus();
            }
            else if (messageOfError == Resources.TooSimpleNewPassword)
            {
                EH.ShowWarning(Resources.TooSimpleNewPassword, true);

                TextBoxForNewPassword.Clear();
                TextBoxOfConfirmation.Clear();
                TextBoxForNewPassword.Focus();
            }
            else if (messageOfError == Resources.OldAndNewPasswordsTheSame)
            {
                EH.ShowWarning(Resources.OldAndNewPasswordsTheSame);

                TextBoxForNewPassword.Clear();
                TextBoxOfConfirmation.Clear();
                TextBoxForNewPassword.Focus();
            }
        }

        /// <summary>
        /// Проверка на авторизованного пользователя, на корректность ввода старого пароля, нового и повторного
        /// пароля, на совпадение старого и нового паролей.
        /// </summary>
        /// <param name="oldPassword">Старый пароль.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <param name="confirmationPassword">Повтор нового пароля.</param>
        /// <returns>Подтверждение валидации и сообщение об ошибке при наличии.</returns>
        public static (bool success, string? errorMessage) IsAllPasswordsValid(string oldPassword, string newPassword,
                                                string confirmationPassword, ApplicationContextDB db, string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
                return (false, Resources.UserNotFound);

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
            foreach (char symbol in  symbolsInOldPassword)
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

        private void OpenMainMenu(string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }

            else if (user.UserRole == UserRole.Warehouseman)
            {
                Hide();
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
                Close();
            }
            else if (user.UserRole == UserRole.Administrator)
            {
                Hide();
                var administratorPanel = new AdministratorPanel(userLogin);
                administratorPanel.ShowDialog();
                Close();
            }
        }

        private void TabSelection_Enter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.LightSteelBlue;
            }
        }

        private void TabSelection_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Transparent;
            }
        }
    }
}