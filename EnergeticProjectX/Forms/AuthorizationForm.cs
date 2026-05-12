using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using System.Text.RegularExpressions;
using EnergeticProjectX.interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для авторизации пользователя.
    /// </summary>
    public partial class AuthorizationForm : Form
    {
        private readonly IUserService _userService;       
        /// <summary>
        /// Конструктор для реализации формы авторизации пользователя.
        /// </summary>
        public AuthorizationForm(IUserService userservice)
        {
            InitializeComponent();
            _userService = userservice;
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
                    var administratorMainMenu = new AdministratorMainMenu(user.Login);
                    FH.OpenForm(this, administratorMainMenu);
                }
                else if (user.UserRole == UserRoles.Warehouseman)
                {
                    var warehousemanMainMenu = new WarehousemanMainMenu(user.Login);
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
            var registrationForm = new RegistrationForm();
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