using AdministratorPanelForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using WarehousemanPanelForm;

namespace UserChangePasswordForm
{
    /// <summary>
    /// Форма по изменению пароля пользователя
    /// </summary>
    public partial class UserChangePassword : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly BCryptRealization bc = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор изменения пароля
        /// </summary>
        public UserChangePassword(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            textBoxForOldPassword.TextChanged += IsTextChanged!;
            textBoxForNewPassword.TextChanged += IsTextChanged!;
            textBoxOfConfirmation.TextChanged += IsTextChanged!;
        }

        private void ButtonOfSaveInfo_Click(object sender, EventArgs e)
        {
            var oldPassword = textBoxForOldPassword.Text.Trim();
            var newPassword = textBoxForNewPassword.Text.Trim();
            var confirmationPassword = textBoxOfConfirmation.Text.Trim();

            ChangePassword(oldPassword, newPassword, confirmationPassword);
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            ReturnToTheMainMenu(userLogin);
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxForOldPassword.Text) &&
                                  !string.IsNullOrWhiteSpace(textBoxForNewPassword.Text) &&
                                  !string.IsNullOrEmpty(textBoxOfConfirmation.Text);

            ButtonOfSaveInfo.Enabled = allFieldsFilled;
        }

        private void ChangePassword(string oldPassword, string newPassword, string confirmationPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            (var loginAndPasswordValid, var messageOfError) = IsAllPasswordsValid(oldPassword,
                                                            newPassword, confirmationPassword, db, userLogin);

            if (loginAndPasswordValid)
            {
                user!.Password = BCryptRealization.PasswordHash(newPassword);

                if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                    return;

                MessageBox.Show(Resources.ChangePasswordEvent, Resources.TitleAlert,
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show($"{Resources.UserNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (messageOfError == Resources.IncorrectOldPassword)
            {
                MessageBox.Show(Resources.IncorrectOldPassword, Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxForOldPassword.Clear();
                textBoxForNewPassword.Clear();
                textBoxOfConfirmation.Clear();
                textBoxForOldPassword.Focus();
            }
            else if (messageOfError == Resources.UnmatchedNewPasswords)
            {
                MessageBox.Show($"{Resources.UnmatchedNewPasswords}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxForNewPassword.Clear();
                textBoxOfConfirmation.Clear();
                textBoxForNewPassword.Focus();
            }
            else if (messageOfError == Resources.TooSimpleNewPassword)
            {
                MessageBox.Show($"{Resources.TooSimpleNewPassword}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxForNewPassword.Clear();
                textBoxOfConfirmation.Clear();
                textBoxForNewPassword.Focus();
            }
            else if (messageOfError == Resources.OldAndNewPasswordsTheSame)
            {
                MessageBox.Show(Resources.OldAndNewPasswordsTheSame, Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxForNewPassword.Clear();
                textBoxOfConfirmation.Clear();
                textBoxForNewPassword.Focus();
            }
        }

        /// <summary>
        /// Проверка на авторизованного пользователя, на корректность ввода старого пароля, нового и повторного
        /// пароля, на совпадение старого и нового паролей.
        /// </summary>
        /// <param name="oldPassword">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <param name="confirmationPassword">Повтор нового пароля</param>
        /// <returns></returns>
        public (bool success, string? errorMessage) IsAllPasswordsValid(string oldPassword, string newPassword,
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
        /// <param name="newPassword">Новый пароль</param>
        /// <returns>Подтверждение соответствия требованиям</returns>
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

        private void ReturnToTheMainMenu(string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                MessageBox.Show($"{Resources.UserNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

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
    }
}