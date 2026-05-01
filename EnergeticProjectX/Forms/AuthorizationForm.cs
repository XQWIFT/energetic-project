using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для авторизации пользователя.
    /// </summary>
    public partial class AuthorizationForm : Form
    {
        private readonly ApplicationContextDB db = new();

        /// <summary>
        /// Конструктор для реализации формы авторизации пользователя.
        /// </summary>
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfInvolve.Enabled = !string.IsNullOrWhiteSpace(TextBoxForLogin.Text) &&
                                      !string.IsNullOrWhiteSpace(TextBoxOfPassword.Text);
        }

        /// <summary>
        /// Метод для авторизации и проверка роли пользователя.
        /// </summary>
        /// <param name="userLogin">Вводимый логин.</param>
        /// <param name="password">Вводимый пароль.</param>
        /// <param name="db">Контекст базы данных.</param>
        public void Authorization(string userLogin, string password, ApplicationContextDB db)
        {
            if (IsLoginAndPasswordValid(userLogin, password, db))
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

                if (user != null && user.UserRole == UserRole.Administrator)
                {
                    Hide();
                    var administratorPanel = new AdministratorPanel(user.Login);
                    administratorPanel.ShowDialog();
                    Close();
                }
                else if (user != null && user.UserRole == UserRole.Warehouseman)
                {
                    Hide();
                    var warehousemanPanel = new WarehousemanPanel(user.Login);
                    warehousemanPanel.ShowDialog();
                    Close();
                }
                else
                {
                    EH.ShowError(Resources.UserNotFound, true);
                }
            }
            else
            {
                EH.ShowError($"{Resources.IncorrectLoginOrPassword}.\n\n{Resources.TryAgain}");
            }

            TextBoxForLogin.Clear();
            TextBoxOfPassword.Clear();
            TextBoxForLogin.Focus();
        }

        /// <summary>
        /// Метод для сравнения логина и пароля с имеющимися в базе данных.
        /// </summary>
        /// <param name="login">Введённый пользователем логин.</param>
        /// <param name="password">Введённый пользователем пароль.</param>
        /// <param name="db">Контекст базы данных.</param>
        /// <returns>Подтверждение валидации.</returns>
        public static bool IsLoginAndPasswordValid(string login, string password, ApplicationContextDB db)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == login);

            if (user != null && BCryptRealization.CheckPassword(password, user.Password))
                return true;
            return false;
        }

        private void ButtonOfInvolve_Click(object sender, EventArgs e)
        {
            var login = TextBoxForLogin.Text.Trim();
            var password = TextBoxOfPassword.Text.Trim();

            Authorization(login, password, db);
        }

        private void LabelOfRegistration_Click(object sender, EventArgs e)
        {
            Hide();
            var registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            Close();
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
