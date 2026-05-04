using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для изменения пароля пользователя.
    /// </summary>
    public partial class ChangePasswordForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы изменения пароля.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public ChangePasswordForm(string userLogin)
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
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

            if (user == null)
                return;

            var oldPassword = TextBoxForOldPassword.Text.Trim();
            var newPassword = TextBoxForNewPassword.Text.Trim();
            var confirmationPassword = TextBoxOfConfirmation.Text.Trim();

            ChangePassword(user, oldPassword, newPassword, confirmationPassword);
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

            if (user == null)
                return;

            OpenMainMenu(user);
        }

        private void ChangePassword(User user, string oldPassword, string newPassword, string confirmationPassword)
        {
            (var loginAndPasswordValid, var messageOfError) = UIHelper.IsAllPasswordsValid(user, oldPassword, newPassword, confirmationPassword);

            if (loginAndPasswordValid)
            {
                user.Password = BCryptRealization.PasswordHash(newPassword);

                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;

                EH.ShowInformation(Resources.ChangePasswordEvent);

                OpenMainMenu(user);
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

        private void OpenMainMenu(User user)
        {
            if (user.UserRole == UserRoles.Administrator)
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin);
                FH.OpenForm(this, administratorMainMenu);
            }
            else if (user.UserRole == UserRoles.Warehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin);
                FH.OpenForm(this, warehousemanMainMenu);
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