using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для регистрации нового пользователя.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        private readonly ApplicationContextDB db = new();

        /// <summary>
        /// Конструктор для реализации формы регистрации.
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfRegistration.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfSurname.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfLogin.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfPassword.Text) &&
                                           !string.IsNullOrWhiteSpace(TextBoxOfPasswordConfirmation.Text);
        }

        private void ButtonOfRegistration_Click(object sender, EventArgs e)
        {
            var firstname = User.IsUserPersonalDataRelevant(TextBoxOfName.Text);
            var surname = User.IsUserPersonalDataRelevant(TextBoxOfName.Text);
            var patronymic = User.IsUserPersonalDataRelevant(TextBoxOfName.Text);

            if (firstname == null || surname == null)
            {
                EH.ShowWarning(Resources.PersonalDataIsIrrelevant, true);

                if (firstname == null)
                {
                    TextBoxOfName.Clear();
                    TextBoxOfName.Focus();
                }
                else if (surname == null)
                {
                    TextBoxOfSurname.Clear();
                    TextBoxOfSurname.Focus();
                }

                return;
            }

            var password = TextBoxOfPassword.Text.Trim();
            var login = TextBoxOfLogin.Text.Trim();
            var passwordConfirmation = TextBoxOfPasswordConfirmation.Text.Trim();

            var userLoginFree = IsUserLoginFree(login, db);
            var (passwordsMatch, passwordSatisfyRequirements) = User.IsPasswordRelevant(password, passwordConfirmation);

            if (userLoginFree && passwordsMatch && passwordSatisfyRequirements)
            {
                var currencyByDefault = db.Currencies.FirstOrDefault(u => u.Code == "RUB");

                if (currencyByDefault == null)
                {
                    EH.ShowError(Resources.ErrorDefaultCurrencyUpload, true);

                    return;
                }

                var user = new User
                {
                    Surname = TextBoxOfSurname.Text.Trim(),
                    Name = TextBoxOfName.Text.Trim(),
                    Patronymic = TextBoxOfPatronymic.Text.Trim() ?? null,
                    Login = TextBoxOfLogin.Text.Trim(),
                    Password = BCryptRealization.PasswordHash(TextBoxOfPassword.Text.Trim()),
                    UserRole = UserRole.Warehouseman,
                    CurrencyId = currencyByDefault.Currency_Id
                };

                db.Users.Add(user);
                if (EH.DBSaveChangesUniversalErrorCheck(db))
                    return;

                Hide();
                var warehousemanPanel = new WarehousemanPanel(user.Login);
                warehousemanPanel.ShowDialog();
                Close();
            }
            else if (!userLoginFree)
            {
                EH.ShowError(Resources.UserLoginAlreadyExists);

                TextBoxOfLogin.Clear();
                TextBoxOfLogin.Focus();
            }
            else if (!passwordSatisfyRequirements)
            {
                EH.ShowWarning(Resources.TooSimplePassword, true);

                TextBoxOfPassword.Clear();
                TextBoxOfPasswordConfirmation.Clear();
                TextBoxOfPassword.Focus();
            }
            else if (!passwordsMatch)
            {
                EH.ShowWarning(Resources.UnmatchedPasswords, true);

                TextBoxOfPassword.Clear();
                TextBoxOfPasswordConfirmation.Clear();
                TextBoxOfPassword.Focus();
            }
        }

        /// <summary>
        /// Проверка, свободен ли указанный пользователем логин для регистрации.
        /// </summary>
        /// <param name="login">Логин нового пользователя.</param>
        /// <param name="db">Контекст базы данных.</param>
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