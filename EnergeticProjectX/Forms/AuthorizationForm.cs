using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text.RegularExpressions;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для авторизации пользователя.
    /// </summary>
    public partial class AuthorizationForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        /// <summary>
        /// Конструктор для реализации формы авторизации пользователя.
        /// </summary>
        public AuthorizationForm(IUserService userservice, IProductService productService, IClientService clientService)
        {
            InitializeComponent();

            _userService = userservice;

            _clientService = clientService;

            _productService = productService;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfInvolve.Enabled = !string.IsNullOrWhiteSpace(TextBoxForLogin.Text) &&
                                      !string.IsNullOrWhiteSpace(TextBoxOfPassword.Text);
        }

        /// <summary>
        /// Метод для авторизации пользователя.
        /// </summary>
        /// <param name="user">Пользователь, соответствующий введённому логину.</param>
        /// <param name="password">Пароль без пробелов, введённый в текстовое поле.</param>
        public void Authorization(User user, string password)
        {
            if (IsLoginAndPasswordValid(user, password))
            {
                if (user.UserRole == UserRoles.Administrator)
                {
                    var administratorMainMenu = new AdministratorMainMenu(user.Login, _userService, _clientService, _productService);
                    FH.OpenForm(this, administratorMainMenu);
                }
                else if (user.UserRole == UserRoles.Warehouseman)
                {
                    var warehousemanMainMenu = new WarehousemanMainMenu(user.Login, _userService, _productService, _clientService);
                    FH.OpenForm(this, warehousemanMainMenu);
                }
                else
                    return;
            }
            else
            {
                EH.ShowError(Resources.IncorrectLoginOrPassword, true);
            }

            TextBoxForLogin.Clear();
            TextBoxOfPassword.Clear();
            TextBoxForLogin.Focus();
        }

        /// <summary>
        /// Метод для сравнения логина и пароля с имеющимися в базе данных.
        /// </summary>
        /// <param name="user">Пользователь системы по найденному логину..</param>
        /// <param name="password">Введённый пользователем пароль.</param>
        /// <returns>Подтверждение валидации.</returns>
        public static bool IsLoginAndPasswordValid(User user, string password)
        {
            if (BCryptRealization.CheckPassword(password, user.Password))
                return true;
            return false;
        }

        private void ButtonOfInvolve_Click(object sender, EventArgs e)
        {
            var userLogin = Regex.Replace(TextBoxForLogin.Text, @"\s", "");
            var password = Regex.Replace(TextBoxOfPassword.Text, @"\s", "");

            var user = _userService.FindByLogin(userLogin);

            if (user == null)
            {
                EH.ShowWarning(Resources.UserNotFound, true);

                return;
            }

            Authorization(user, password);
        }

        private void LabelOfRegistration_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(_userService, _productService, _clientService);
            FH.OpenForm(this, registrationForm);
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