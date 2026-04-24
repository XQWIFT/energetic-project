using AdministratorPanelForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using Registration;
using WarehousemanPanelForm;

namespace EnergeticProjectX
{
    /// <summary>
    /// Форма авторизации - открывается при запуске программы
    /// </summary>
    public partial class AuthorizationForm : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly BCryptRealization bc = new();

        /// <summary>
        /// Конструктор формы авторизации
        /// </summary>
        public AuthorizationForm()
        {
            InitializeComponent();

            TextBoxForLogin.TextChanged += TextBox_TextChanged!;
            TextBoxOfPassword.TextChanged += TextBox_TextChanged!;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxForLogin.Text) &&
                                  !string.IsNullOrWhiteSpace(TextBoxOfPassword.Text);

            ButtonOfInvolve.Enabled = allFieldsFilled;
        }

        /// <summary>
        /// Процесс авторизации и проверка роли пользователя
        /// </summary>
        /// <param name="login">Вводимый логин</param>
        /// <param name="password">Вводимый пароль</param>
        /// <param name="db">Контекст базы данных</param>
        public void Authorization(string login, string password, ApplicationContextDB db)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == login);

            if (IsLoginAndPasswordValid(login, password, db))
            {
                Hide();

                if (user != null && user.UserRole == UserRole.Administrator)
                {
                    var administratorPanel = new AdministratorPanel(TextBoxForLogin.Text);
                    administratorPanel.ShowDialog();
                    Close();
                }
                else if (user != null && user.UserRole == UserRole.Warehouseman)
                {
                    var warehousemanPanel = new WarehousemanPanel(TextBoxForLogin.Text);
                    warehousemanPanel.ShowDialog();
                    Close();
                }
            }
            else
            {
                MessageBox.Show($"{Resources.IncorrectLoginOrPassword}\n{Resources.TryAgain}", Resources.TitleError,
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            TextBoxForLogin.Clear();
            TextBoxOfPassword.Clear();
            TextBoxForLogin.Focus();
        }

        /// <summary>
        /// Сравнение пароля с имеющимся в базе данных
        /// </summary>
        /// <param name="login">Введённый пользователем логин</param>
        /// <param name="password">Введённый пользователем пароль</param>
        /// <param name="db">Контекст базы данных</param>
        /// <returns>Подтверждение валидации</returns>
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
    }
}
