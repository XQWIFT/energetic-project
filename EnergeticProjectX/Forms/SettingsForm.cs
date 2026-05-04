using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для пользовательских настроек приложения.
    /// </summary>
    public partial class SettingsForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        private Guid originalCurrencyId;

        private bool currencyChanged = false;

        /// <summary>
        /// Конструктор для реализации формы пользовательских настроек.
        /// </summary>
        public SettingsForm(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadCurrencies();
        }

        private void LoadCurrencies()
        {

            try
            {
                var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

                if (user == null)
                    return;

                originalCurrencyId = user.CurrencyId;

                var startCurrency = Db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

                if (startCurrency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                var currencies = Db.Currencies.ToList();
                ComboBoxOfCurrency.DataSource = currencies;
                ComboBoxOfCurrency.DisplayMember = nameof(Currency.CurrencyName);
                ComboBoxOfCurrency.ValueMember = nameof(Currency.Currency_Id);
                ComboBoxOfCurrency.SelectedValue = user.CurrencyId;

                UpdateCurrencyInfo(startCurrency);
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorWhileLoadingData, true);

                return;
            }
        }

        private void ComboBoxOfCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfCurrency.SelectedValue is Guid currencyId)
            {
                var currency = Db.Currencies.FirstOrDefault(c => c.Currency_Id == currencyId);

                if (currency != null)
                {
                    UpdateCurrencyInfo(currency);

                    currencyChanged = currencyId != originalCurrencyId;

                    ButtonOfSaveChanges.Enabled = currencyChanged;
                }
            }
        }

        private void UpdateCurrencyInfo(Currency currency)
        {
            TextBoxOfExchangeRate.Text = currency.ExchangeRate.ToString("F4");
            TextBoxOfCurrenciesUpload.Text = TH.UtcToLocalDateTime(currency.DataOfUpdate).ToString("dd.MM.yyyy HH:mm");
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

                if (user == null)
                    return;

                if (ComboBoxOfCurrency.SelectedValue is not Guid newCurrencyId)
                {
                    EH.ShowWarning(Resources.SelectCurrency);

                    return;
                }

                user.CurrencyId = newCurrencyId;

                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;

                var newCurrency = Db.Currencies.FirstOrDefault(c => c.Currency_Id == newCurrencyId);

                if (newCurrency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                EH.ShowInformation($"{Resources.SettingsSuccessfullySaved}\n\n" +
                                   $"{Resources.NewCurrency} {newCurrency.CurrencyName}.\n" +
                                   $"{Resources.ExchangeRate} {newCurrency.ExchangeRate:F4} ₽");

                originalCurrencyId = newCurrencyId;
                currencyChanged = false;

                OpenMainMenu(user);
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorSave, true);

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

            if (user == null)
                return;

            OpenMainMenu(user);
        }

        private void OpenMainMenu(User user)
        {
            if (user.UserRole == UserRoles.Administrator)
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin);
                FH.OpenForm(this, administratorMainMenu);
            }
            else if (user.UserRole == UserRoles.Warehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin);
                FH.OpenForm(this, warehousemanMainMenu);
            }
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
