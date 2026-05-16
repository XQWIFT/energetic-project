using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для изменения пароля пользователя.
    /// </summary>
    public partial class ChangePasswordForm : Form
    {
        private readonly string userLogin;

        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IClientService _clientService;

        /// <summary>
        /// Конструктор для реализации формы изменения пароля.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public ChangePasswordForm(string userLogin, IUserService userService, IClientService clientService, IProductService productService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _clientService = clientService;

            _productService = productService;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfSaveInfo.Enabled = !string.IsNullOrWhiteSpace(TextBoxForOldPassword.Text) &&
                                       !string.IsNullOrWhiteSpace(TextBoxForNewPassword.Text) &&
                                       !string.IsNullOrEmpty(TextBoxOfConfirmation.Text);
        }

        private void ButtonOfSaveInfo_Click(object sender, EventArgs e)
        {
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            var oldPassword = TextBoxForOldPassword.Text.Trim();
            var newPassword = TextBoxForNewPassword.Text.Trim();
            var confirmationPassword = TextBoxOfConfirmation.Text.Trim();

            ChangePassword(user, oldPassword, newPassword, confirmationPassword);
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            OpenMainMenu(user);
        }

        private void ChangePassword(User user, string oldPassword, string newPassword, string confirmationPassword)
        {
            (var loginAndPasswordValid, var messageOfError) = _userService.IsAllPasswordsValid(user, oldPassword, newPassword, confirmationPassword);

            if (loginAndPasswordValid)
            {
                try
                {
                    _userService.ChangePassword(user, newPassword);
                    EH.ShowInformation(Resources.ChangePasswordEvent);

                    OpenMainMenu(user);
                }
                catch
                {
                    EH.ShowError(Resources.UniversalErrorDatabase, true);
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

        private void OpenMainMenu(User user)
        {
            if (user.UserRole == UserRoles.Administrator)
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin, _userService, _clientService, _productService);
                FH.OpenForm(this, administratorMainMenu);
            }
            else if (user.UserRole == UserRoles.Warehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin, _userService, _productService, _clientService);
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