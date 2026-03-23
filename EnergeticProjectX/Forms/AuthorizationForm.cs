using AdministratorPanelForm;
using BCrypt;
using DbOfUser;
using Registration;

namespace EnergeticProjectX
{
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
            DbOfUser.ApplicationContextOfUser db = new();

            var login = textBoxForLogin.Text.Trim();
            var password = textBoxOfPassword.Text.Trim();

            Authorization(login, password, db);
        }

        public void Authorization(string login, string password, ApplicationContextOfUser db)
        {

            if (IsLoginAndPasswordValid(login, password, db))
            {
                Console.WriteLine("W: " +
                    "Access to the app is open as an administrator!");
                var choice = MessageBox.Show("Успешно!", "Вы вошли в аккаунт",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (choice == DialogResult.OK)
                {
                    this.Hide();
                    AdministratorPanel administratorPanel = new AdministratorPanel(textBoxForLogin.Text);
                    administratorPanel.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxForLogin.Clear();
            textBoxOfPassword.Clear();
            Console.WriteLine("E:" +
                    "Access error. Please try again.");
        }

        public bool IsLoginAndPasswordValid(string login, string password, ApplicationContextOfUser db)
        {
            BCryptRealization bc = new();

            var user = db.Users.FirstOrDefault(u =>
           u.Login == login);
            if (user != null && bc.CheckPassword(password, user.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonOfRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            this.Close();
        }
    }
}
