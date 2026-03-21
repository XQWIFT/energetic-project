using AdministratorPanelForm;
using BCrypt;
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
            BCryptRealization bc = new();
            var login = textBoxForLogin.Text.Trim();

            var password = textBoxOfPassword.Text.Trim();

            var user = db.Users.FirstOrDefault(u =>
            u.Login == login);
            if (user != null && bc.CheckPassword(password, user.Password))
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

        private void buttonOfRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            this.Close();
        }
    }
}
