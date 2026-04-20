using AdministratorPanelForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
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

            textBoxForLogin.TextChanged += TextBox_TextChanged!;
            textBoxOfPassword.TextChanged += TextBox_TextChanged!;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxForLogin.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPassword.Text);

            ButtonOfInvolve.Enabled = allFieldsFilled;
        }

        private void ButtonOfInvolve_Click(object sender, EventArgs e)
        {
            var login = textBoxForLogin.Text.Trim();
            var password = textBoxOfPassword.Text.Trim();

            Authorization(login, password, db);
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

                if (user != null && user.UserRole == Resources.UserRoleAdminEng)
                {
                    var administratorPanel = new AdministratorPanel(textBoxForLogin.Text);
                    administratorPanel.ShowDialog();
                    Close();
                }
                else if (user != null && user.UserRole == Resources.UserRoleWarehousemanEng)
                {
                    var warehousemanPanel = new WarehousemanPanel(textBoxForLogin.Text);
                    warehousemanPanel.ShowDialog();
                    Close();
                }
            }
            else
            {
                MessageBox.Show($"{Resources.IncorrectLoginOrPassword}\n{Resources.TryAgain}", Resources.TitleError,
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBoxForLogin.Clear();
            textBoxOfPassword.Clear();
            textBoxForLogin.Focus();
        }

        /// <summary>
        /// Сравнение пароля с имеющимся в базе данных
        /// </summary>
        /// <param name="login">Введённый пользователем логин</param>
        /// <param name="password">Введённый пользователем пароль</param>
        /// <param name="db">Контекст базы данных</param>
        /// <returns>Подтверждение валидации</returns>
        public bool IsLoginAndPasswordValid(string login, string password, ApplicationContextDB db)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == login);
            if (user != null && bc.CheckPassword(password, user.Password))
            {
                return true;
            }
            return false;
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
