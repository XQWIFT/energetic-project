using AdministratorPanelForm;
using BCrypt;
using WarehousemanPanelForm;
using Registration;

namespace EnergeticProjectX
{
    /// <summary>
    /// Форма авторизации (запускается самой первой)
    /// </summary>
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();

            textBoxForLogin.TextChanged += TextBox_TextChanged!;
            textBoxOfPassword.TextChanged += TextBox_TextChanged!;

            buttonOfInvolve.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxForLogin.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPassword.Text);

            buttonOfInvolve.Enabled = allFieldsFilled;
        }

        private void buttonOfInvolve_Click(object sender, EventArgs e)
        {
            DBControl.ApplicationContextDB db = new();

            var login = textBoxForLogin.Text.Trim();
            var password = textBoxOfPassword.Text.Trim();

            Authorization(login, password, db);
        }

        /// <summary>
        /// Процесс авторизации и проверка роли пользователя
        /// </summary>
        public void Authorization(string login, string password, DBControl.ApplicationContextDB db)
        {
            var user = db.Users.FirstOrDefault(u =>
           u.Login == login);

            if (IsLoginAndPasswordValid(login, password, db))
            {
                var choice = MessageBox.Show("Успешно!", "Вы вошли в аккаунт",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (choice == DialogResult.OK)
                {
                    this.Hide();
                    var administratorPanel = new AdministratorPanel(textBoxForLogin.Text);
                    var warehousemanPanel = new WarehousemanPanel(textBoxForLogin.Text);

                    if (user != null && user.UserRole == "Admin")
                    {
                        administratorPanel.ShowDialog();
                        this.Close();
                    }
                    else if (user != null && user.UserRole == "Warehouseman")
                    {
                        warehousemanPanel.ShowDialog();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxForLogin.Clear();
            textBoxOfPassword.Clear();
        }

        /// <summary>
        /// Сравнение пароля с имеющимся в БД
        /// </summary>
        public bool IsLoginAndPasswordValid(string login, string password, DBControl.ApplicationContextDB db)
        {
            BCryptRealization bc = new();

            var user = db.Users.FirstOrDefault(u =>
           u.Login == login);
            if (user != null && bc.CheckPassword(password, user.Password))
            {
                return true;
            }
            return false;
        }

        private void buttonOfRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            this.Close();
        }
    }
}
