using BCrypt;
using EnergeticProjectX;
using UserControl;
using GeneratedCode;
using WarehousemanPanelForm;
using DBControl;

namespace Registration
{
    /// <summary>
    /// Открывается форма регистрации
    /// </summary>
    public partial class RegistrationForm : Form
    {
        /// <summary>
        /// Для тестов
        /// </summary>
        public bool isLoginFree;
        public bool isPasswordCorrect;
        public bool isPasswordsMatch;


        DBControl.ApplicationContextDB db = new();
        GenerateUniqueCode generateUniqueUserCode = new GenerateUniqueCode();
        /// <summary>
        /// Базовый конструктор
        /// </summary>
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
            var authorizationForm = new AuthorizationForm();
            authorizationForm.ShowDialog();
            this.Close();
        }

        private void buttonOfRegistration_Click(object sender, EventArgs e)
        {
            var logins = db.Users
     .Select(u => u.Login)
     .ToList();

            string password = textBoxOfPassword.Text;
            string login = textBoxOfLogin.Text;
            string passwordConfirmation = textBoxOfPasswordToo.Text;

            isUserDataValid(login, password, passwordConfirmation, db);

            if (isLoginFree)
            {
                if (isPasswordCorrect == true)
                {
                    if (isPasswordsMatch == true)
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
                        for (int i = 0; i < 100; i++)
                        {
                            var codes = generateUniqueUserCode.Generate5();
                            if (!user.UserCode.Contains(codes))
                            {
                                break;
                            }

                            user.UserCode = codes;
                        }
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
                    textBoxOfPasswordToo.Clear();
                }
            }
            else
            {
                MessageBox.Show("Данный логин уже существует!\nПридумайте новый", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOfLogin.Clear();
            }
        }

        public void isUserDataValid(string login, string password, string passwordConfirmation, ApplicationContextDB db)
        {
            var logins = db.Users
                .Select(u => u.Login)
                .ToList();

            if (!logins.Contains(login))
            {
                isLoginFree = true;

                var charPasswordArray = password.Trim().ToCharArray();
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
                    isPasswordCorrect = true;

                    if (password.Trim() == passwordConfirmation.Trim())
                    {
                        isPasswordsMatch = true;
                    }
                    else
                    {
                        isPasswordsMatch = false;
                    }
                }
                else
                {
                    isPasswordCorrect = false;
                }
            }
            else
            {
                isLoginFree = false;
            }
        }
    }
}