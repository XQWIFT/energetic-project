using EnergeticProjectX;
using WarehousemanPanelForm;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;

namespace Registration
{
    /// <summary>
    /// Форма регистрации нового пользователя. Роль по умолчанию - Кладовщик
    /// </summary>
    public partial class RegistrationForm : Form
    {
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
            var allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                  !string.IsNullOrWhiteSpace(textBoxOfSurname.Text) &&
                                  !string.IsNullOrWhiteSpace(textBoxOfLogin.Text) &&
                                  !string.IsNullOrWhiteSpace(textBoxOfPassword.Text) &&
                                  !string.IsNullOrWhiteSpace(textBoxOfPasswordConfirmation.Text);

            ButtonOfRegistration.Enabled = allFieldsFilled;
        }

        private void ButtonOfRegistration_Click(object sender, EventArgs e)
        {
            var firstname = User.IsUserPersonalDataRelevant(textBoxOfName.Text);
            var surname = User.IsUserPersonalDataRelevant(textBoxOfName.Text);
            var patronymic = User.IsUserPersonalDataRelevant(textBoxOfName.Text);

            if (firstname == null || surname == null || patronymic == null)
            {
                MessageBox.Show($"{Resources.InputPersonalDataIrrelevant}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (firstname == null)
                {
                    textBoxOfName.Clear();
                    textBoxOfName.Focus();
                }
                if (surname == null)
                    textBoxOfSurname.Clear();
                if (patronymic == null)
                    textBoxOfPatronymic.Clear();

                return;
            }

            var logins = db.Users.Select(u => u.Login).ToList();

            var password = textBoxOfPassword.Text;
            var login = textBoxOfLogin.Text;
            var passwordConfirmation = textBoxOfPasswordConfirmation.Text;

            var userLoginFree = IsUserLoginFree(login, db);
            var (passwordsMatch, passwordSatisfyRequirements) = User.IsPasswordRelevant(password, passwordConfirmation);

            if (userLoginFree && passwordsMatch && passwordSatisfyRequirements)
            {
                var currencyByDefault = db.Currencies.FirstOrDefault(u => u.Code == Resources.RUB);

                if (currencyByDefault == null)
                {
                    MessageBox.Show($"{Resources.ErrorDefaultCurrencyUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var user = new User
                {
                    Surname = textBoxOfSurname.Text.Trim(),
                    Name = textBoxOfName.Text.Trim(),
                    Patronymic = textBoxOfPatronymic.Text.Trim() ?? null,
                    Login = textBoxOfLogin.Text.Trim(),
                    Password = BCryptRealization.PasswordHash(textBoxOfPassword.Text.Trim()),
                    UserRole = UserRole.Warehouseman,
                    CurrencyId = currencyByDefault.Currency_Id
                };

                db.Users.Add(user);
                if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                    return;

                Hide();
                var warehousemanPanel = new WarehousemanPanel(user.Login);
                warehousemanPanel.ShowDialog();
                Close();
            }
            else if (!userLoginFree)
            {
                MessageBox.Show($"{Resources.ExistsUsername}\n{Resources.InventNewLogin}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxOfLogin.Clear();
                textBoxOfLogin.Focus();
            }
            else if (!passwordSatisfyRequirements)
            {
                MessageBox.Show($"{Resources.TooSimplePassword}\n{Resources.InventNewPassword}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxOfPassword.Clear();
                textBoxOfPasswordConfirmation.Clear();
                textBoxOfPassword.Focus();
            }
            else if (!passwordsMatch)
            {
                MessageBox.Show($"{Resources.UnmatchedPasswords}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxOfPassword.Clear();
                textBoxOfPasswordConfirmation.Clear();
                textBoxOfPassword.Focus();
            }
        }

        /// <summary>
        /// Проверка, свободен ли указанный пользователем логин для регистрации.
        /// </summary>
        /// <param name="login">Логин нового пользователя</param>
        /// <param name="db">Контекст базы данных</param>
        public static bool IsUserLoginFree(string login, ApplicationContextDB db)
        {
            var logins = db.Users.Select(u => u.Login).ToList();

            return (!logins.Contains(login));
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