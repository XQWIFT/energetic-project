using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для пользовательских настроек приложения.
    /// </summary>
    public partial class Settings : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private Guid originalCurrencyId;

        private bool currencyChanged = false;

        /// <summary>
        /// Конструктор для реализации формы пользовательских настроек.
        /// </summary>
        public Settings(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadCurrencies();
        }

        private void LoadCurrencies()
        {

            try
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

                if (user == null)
                {
                    EH.ShowError(Resources.UserNotFound, true);

                    return;
                }

                originalCurrencyId = user.CurrencyId;

                var startCurrency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

                if (startCurrency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                var currencies = db.Currencies.ToList();
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
                var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == currencyId);

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
            if (currency != null)
            {
                TextBoxOfExchangeRate.Text = currency.ExchangeRate.ToString("F4");
                TextBoxOfCurrenciesUpload.Text = currency.DataOfUpdate.AddHours(3).ToString("dd.MM.yyyy HH:mm");
            }
            else
            {
                TextBoxOfExchangeRate.Text = string.Empty;
                TextBoxOfCurrenciesUpload.Text = string.Empty;
            }
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfCurrency.SelectedValue is not Guid newCurrencyId)
                {
                    EH.ShowWarning(Resources.SelectCurrency);

                    return;
                }

                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
                if (user == null)
                {
                    EH.ShowError(Resources.UserNotFound, true);

                    return;
                }

                user.CurrencyId = newCurrencyId;

                if (EH.DBSaveChangesUniversalErrorCheck(db))
                    return;

                var newCurrency = db.Currencies.FirstOrDefault(c => c.Currency_Id == newCurrencyId);

                EH.ShowInformation($"{Resources.SettingsSuccessfullySaved}\n" +
                                   $"{Resources.NewCurrency}: {newCurrency?.CurrencyName}.\n" +
                                   $"{Resources.ExchangeRate}: {newCurrency?.ExchangeRate:F4}.");

                originalCurrencyId = newCurrencyId;
                currencyChanged = false;

                OpenMainMenu();
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorSave, true);

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            OpenMainMenu();
        }

        private void OpenMainMenu()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            Hide();

            if (user != null && user.UserRole == UserRole.Administrator)
            {
                var administratorPanel = new AdministratorPanel(userLogin);
                administratorPanel.ShowDialog();
                Close();
            }
            else if (user != null && user.UserRole == UserRole.Warehouseman)
            {
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
                Close();
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
