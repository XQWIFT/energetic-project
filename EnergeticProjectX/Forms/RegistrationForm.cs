using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Classes;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для регистрации нового пользователя.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

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
            var firstname = UIHelper.IsUserPersonalDataRelevant(TextBoxOfName.Text);
            var surname = UIHelper.IsUserPersonalDataRelevant(TextBoxOfSurname.Text);
            var patronymic = UIHelper.IsUserPersonalDataRelevant(TextBoxOfPatronymic.Text);

            if (firstname == null || surname == null)
            {
                EH.ShowWarning(Resources.PersonalDataIsIrrelevant, true);

                if (firstname == null && surname == null)
                {
                    TextBoxOfName.Clear();
                    TextBoxOfSurname.Clear();
                    TextBoxOfName.Focus();
                }
                else if (firstname == null)
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

            var password = Regex.Replace(TextBoxOfPassword.Text, @"\s+", "");
            var login = Regex.Replace(TextBoxOfLogin.Text, @"\s+", "");
            var passwordConfirmation = Regex.Replace(TextBoxOfPasswordConfirmation.Text, @"\s+", "");

            var userLoginFree = IsUserLoginFree(login, Db);
            var (passwordsMatch, passwordSatisfyRequirements) = UIHelper.IsPasswordRelevant(password, passwordConfirmation);

            if (userLoginFree && passwordsMatch && passwordSatisfyRequirements)
            {
                var currencyByDefault = Db.Currencies.FirstOrDefault(u => u.Code == "RUB");

                if (currencyByDefault == null)
                {
                    EH.ShowError(Resources.ErrorDefaultCurrencyUpload, true);

                    return;
                }

                var user = new User
                {
                    Surname = surname,
                    Name = firstname,
                    Patronymic = patronymic ?? null,
                    Login = login,
                    Password = BCryptRealization.PasswordHash(password),
                    CurrencyId = currencyByDefault.Currency_Id
                };

                Db.Users.Add(user);
                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;

                var warehousemanMainMenu = new WarehousemanMainMenu(user.Login);
                FH.OpenForm(this, warehousemanMainMenu);
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
        /// <param name="login">Введённый пользователем логин.</param>
        /// <param name="db">Контекст базы данных.</param>
        /// <returns>Подтверждение, есть ли соответствие с введённым логином в базе данных.</returns>
        public static bool IsUserLoginFree(string login, ApplicationContextDB db)
        {
            var logins = db.Users.Select(u => u.Login).ToList();

            return !logins.Contains(login);
        }

        private void LabelOfAuthorization_Click(object sender, EventArgs e)
        {
            var authorizationForm = Program.ServiceProvider.GetRequiredService<AuthorizationForm>();
            FH.OpenForm(this, authorizationForm);
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

        private void TextBoxOfPersonalData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                EH.ShowBlinkWarning(LabelOfWarning, "Личные данные должны содержать\nтолько буквы!");
            }
        }
    }
}