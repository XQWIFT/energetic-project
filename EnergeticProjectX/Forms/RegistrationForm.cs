using EnergeticProjectX.Classes;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для регистрации нового пользователя.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        /// <summary>
        /// Конструктор для реализации формы регистрации.
        /// </summary>
        public RegistrationForm(IUserService userservice,IProductService productService, IClientService clientService)
        {
            InitializeComponent();

            _userService = userservice;

            _clientService = clientService;

            _productService = productService;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfRegistration.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfSurname.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfLogin.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfPassword.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfPasswordConfirmation.Text);
        }

        private void ButtonOfRegistration_Click(object sender, EventArgs e)
        {
            var firstname = UIHelper.IsUserPersonalDataRelevant(TextBoxOfName.Text);
            var surname = UIHelper.IsUserPersonalDataRelevant(TextBoxOfSurname.Text);
            var patronymic = UIHelper.IsUserPersonalDataRelevant(TextBoxOfPatronymic.Text);

            if (firstname == null || surname == null)
            {
                EH.ShowWarning(Resources.PersonalDataIsIrrelevant, true);

                if (firstname == null && surname == null)
                {
                    TextBoxOfName.Clear();
                    TextBoxOfSurname.Clear();
                    TextBoxOfName.Focus();
                }
                else if (firstname == null)
                {
                    TextBoxOfName.Clear();
                    TextBoxOfName.Focus();
                }
                else if (surname == null)
                {
                    TextBoxOfSurname.Clear();
                    TextBoxOfSurname.Focus();
                }

                return;
            }

            var password = Regex.Replace(TextBoxOfPassword.Text, @"\s+", "");
            var login = Regex.Replace(TextBoxOfLogin.Text, @"\s+", "");
            var passwordConfirmation = Regex.Replace(TextBoxOfPasswordConfirmation.Text, @"\s+", "");

            var userLoginFree = _userService.IsUserLoginFree(login);
            var (passwordsMatch, passwordSatisfyRequirements) = UIHelper.IsPasswordRelevant(password, passwordConfirmation);

            if (userLoginFree && passwordsMatch && passwordSatisfyRequirements)
            {
                var currencyByDefault = _userService.GetCurrency("RUB");

                if (currencyByDefault == null)
                {
                    EH.ShowError(Resources.ErrorDefaultCurrencyUpload, true);

                    return;
                }

                var user = new User
                {
                    Surname = surname,
                    Name = firstname,
                    Patronymic = patronymic ?? null,
                    Login = login,
                    Password = BCryptRealization.PasswordHash(password),
                    CurrencyId = currencyByDefault.Currency_Id
                };

                try
                {
                    _userService.AddUser(user);
                }
                catch (Exception)
                {
                    EH.ShowError(Resources.UniversalErrorDatabase, true);
                }

                var warehousemanMainMenu = new WarehousemanMainMenu(user.Login, _userService, _productService, _clientService);
                FH.OpenForm(this, warehousemanMainMenu);
            }
            else if (!userLoginFree)
            {
                EH.ShowError(Resources.UserLoginAlreadyExists);

                TextBoxOfLogin.Clear();
                TextBoxOfLogin.Focus();
            }
            else if (!passwordSatisfyRequirements)
            {
                EH.ShowWarning(Resources.TooSimplePassword, true);

                TextBoxOfPassword.Clear();
                TextBoxOfPasswordConfirmation.Clear();
                TextBoxOfPassword.Focus();
            }
            else if (!passwordsMatch)
            {
                EH.ShowWarning(Resources.UnmatchedPasswords, true);

                TextBoxOfPassword.Clear();
                TextBoxOfPasswordConfirmation.Clear();
                TextBoxOfPassword.Focus();
            }
        }

        private void LabelOfAuthorization_Click(object sender, EventArgs e)
        {
            var authorizationForm = Program.ServiceProvider.GetRequiredService<AuthorizationForm>();
            FH.OpenForm(this, authorizationForm);
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