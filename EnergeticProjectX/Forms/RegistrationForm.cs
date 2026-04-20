using EnergeticProjectX;
using WarehousemanPanelForm;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Classes;

namespace Registration
{
    /// <summary>
    /// Форма регистрации нового пользователя. Роль по умолчанию - Кладовщик
    /// </summary>
    public partial class RegistrationForm : Form
    {
        public bool isLoginFree;
        public bool isPasswordCorrect;
        public bool isPasswordsMatch;

        private readonly BCryptRealization bc = new();
        private readonly ApplicationContextDB db = new();

        /// <summary>
        /// Основной конструктор формы регистрации
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();

            textBoxOfName.TextChanged += TextBox_TextChanged!;
            textBoxOfSurname.TextChanged += TextBox_TextChanged!;
            textBoxOfLogin.TextChanged += TextBox_TextChanged!;
            textBoxOfPassword.TextChanged += TextBox_TextChanged!;
            textBoxOfPasswordConfirmation.TextChanged += TextBox_TextChanged!;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfSurname.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfLogin.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPassword.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPasswordConfirmation.Text);

            ButtonOfRegistration.Enabled = allFieldsFilled;
        }

        private void ButtonOfRegistration_Click(object sender, EventArgs e)
        {
            var logins = db.Users.Select(u => u.Login).ToList();

            string password = textBoxOfPassword.Text;
            string login = textBoxOfLogin.Text;
            string passwordConfirmation = textBoxOfPasswordConfirmation.Text;

            IsUserDataValid(login, password, passwordConfirmation, db);

            if (isLoginFree && isPasswordCorrect && isPasswordsMatch)
            {
                var user = new User
                {
                    User_Id = Guid.NewGuid(),
                    Surname = textBoxOfSurname.Text.Trim(),
                    Name = textBoxOfName.Text.Trim(),
                    Patronymic = textBoxOfPatronymic.Text.Trim() ?? null,
                    Login = textBoxOfLogin.Text.Trim(),
                    Password = bc.PasswordHash(textBoxOfPassword.Text.Trim()),
                    UserCode = GenerateUniqueCode.GenerateUniqueUserCode(db),
                    UserRole = Resources.UserRoleWarehousemanEng
                };

                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}\n\n" +
                                    $"Текст ошибки: {ex.Message}", Resources.TitleErrorBD,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Hide();
                var warehousemanPanel = new WarehousemanPanel(user.Login);
                warehousemanPanel.ShowDialog();
                Close();
            }
            else if (!isLoginFree)
            {
                MessageBox.Show($"{Resources.ExistsUsername}\n{Resources.InventNewLogin}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxOfLogin.Clear();
                textBoxOfLogin.Focus();
            }
            else if (!isPasswordCorrect)
            {
                MessageBox.Show($"{Resources.TooSimplePassword}\n{Resources.InventNewPassword}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxOfPassword.Clear();
                textBoxOfPasswordConfirmation.Clear();
                textBoxOfPassword.Focus();
            }
            else if (!isPasswordsMatch)
            {
                MessageBox.Show($"{Resources.UnmatchedPasswords}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxOfPassword.Clear();
                textBoxOfPasswordConfirmation.Clear();
                textBoxOfPassword.Focus();
            }
        }

        /// <summary>
        /// Проверка регистрации на соответствие условиям
        /// </summary>
        /// <param name="login">Логин нового пользователя</param>
        /// <param name="password">Пароль нового пользователя</param>
        /// <param name="passwordConfirmation">Подтверждение пароля</param>
        /// <param name="db">Контекст базы данных</param>
        public void IsUserDataValid(string login, string password, string passwordConfirmation, ApplicationContextDB db)
        {
            var logins = db.Users.Select(u => u.Login).ToList();

                var charPasswordArray = password.Trim().ToCharArray();

                bool hasDigit = false;
                bool hasCapitalLetter = false;

                foreach (char symbol in charPasswordArray)
                {
                    if (char.IsDigit(symbol))
                        hasDigit = true;
                    else if (char.IsLetter(symbol) && char.IsUpper(symbol))
                        hasCapitalLetter = true;

                    if (hasDigit && hasCapitalLetter)
                        break;
                }
                
                isLoginFree = !logins.Contains(login);

                isPasswordsMatch = password.Trim() == passwordConfirmation.Trim();

                isPasswordCorrect = hasDigit && hasCapitalLetter && charPasswordArray.Length >= 8;
        }

        private void LabelOfAuthorization_Click(object sender, EventArgs e)
        {
            Hide();
            var authorizationForm = new AuthorizationForm();
            authorizationForm.ShowDialog();
            Close();
        }
    }
}