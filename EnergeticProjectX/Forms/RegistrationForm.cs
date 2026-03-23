using BCrypt;
using EnergeticProjectX;
using UserControl;
using GeneratedUserCode;
using WarehousemanPanelForm;

namespace Registration
{
    public partial class RegistrationForm : Form
    {
        DbOfUser.ApplicationContextOfUser db = new();
        GenerateUniqueUserCode generateUniqueUserCode = new GenerateUniqueUserCode();
        public RegistrationForm()
        {
            InitializeComponent();

            textBoxOfName.TextChanged += TextBox_TextChanged!;
            textBoxOfSurname.TextChanged += TextBox_TextChanged!;
            textBoxOfPatronymic.TextChanged += TextBox_TextChanged!;
            textBoxOfLogin.TextChanged += TextBox_TextChanged!;
            textBoxOfPassword.TextChanged += TextBox_TextChanged!;
            textBoxOfPasswordToo.TextChanged += TextBox_TextChanged!;

            buttonOfRegistration.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfSurname.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPatronymic.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfLogin.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPassword.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPasswordToo.Text);

            buttonOfRegistration.Enabled = allFieldsFilled;
        }

        private void buttonOfAuthorization_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.ShowDialog();
            this.Close();
        }

        private void buttonOfRegistration_Click(object sender, EventArgs e)
        {
            var logins = db.Users
                .Select(u => u.Login)
                .ToList();

            if (!logins.Contains(textBoxOfLogin.Text.Trim()))
            {
                var charPasswordArray = textBoxOfPassword.Text.Trim().ToCharArray();
                bool hasDigit = false;
                bool hasLetter = false;
                foreach (char c in charPasswordArray)
                {
                    if (char.IsDigit(c))
                    {
                        hasDigit = true;
                    }
                    else if (char.IsLetter(c))
                    {
                        hasLetter = true;
                    }
                }
                if (hasDigit && hasLetter && charPasswordArray.Length >= 8)
                {
                    if (textBoxOfPassword.Text.Trim() == textBoxOfPasswordToo.Text.Trim())
                    {
                        BCryptRealization bc = new();
                        var user = new User();
                        user.Surname = textBoxOfSurname.Text.Trim();
                        user.Name = textBoxOfName.Text.Trim();
                        user.Patronymic = textBoxOfPatronymic.Text.Trim() == null ? null :
                            textBoxOfPatronymic.Text.Trim();
                        user.Login = textBoxOfLogin.Text.Trim();
                        user.Password = bc.PasswordHash(textBoxOfPassword.Text.Trim());
                        user.UserRole = "Warehouseman";
                        user.UserCode = generateUniqueUserCode.Generate();
                        db.Users.Add(user);
                        db.SaveChanges();

                        this.Hide();
                        WarehousemanPanel warehousemanPanel = new WarehousemanPanel(user.Login);
                        warehousemanPanel.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!\n" +
                        "Придумайте снова", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxOfPassword.Clear();
                        textBoxOfPasswordToo.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Данный пароль не соответствует требованиям безопасности!\n" +
                        "Придумайте новый", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOfPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("Данный логин уже существует!\nПридумайте новый", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOfLogin.Clear();
            }
        }
    }
}