using AdministratorPanelForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using WarehousemanPanelForm;
using EH = EnergeticProjectX.Classes.ErrorHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для пользовательских настроек.
    /// </summary>
    public partial class Settings : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private Guid originalCurrencyId;

        private bool currencyChanged = false;

        /// <summary>
        /// Конструктор для реализации настроек.
        /// </summary>
        public Settings(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoggerService.Info($"Открыты настройки пользователя. Пользователь: {userLogin}");

            LoadCurrencies();
        }

        private void LoadCurrencies()
        {

            try
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

                if (user == null)
                {
                    LoggerService.Error($"Пользователь не найден: {userLogin}");

                    EH.ShowError($"{Resources.UserNotFound}\n{Resources.TryAgain}");

                    return;
                }

                originalCurrencyId = user.CurrencyId;

                var startCurrency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

                if (startCurrency == null)
                {
                    LoggerService.Error($"Курс валюты не найден. Пользователь: {userLogin}");

                    EH.ShowError($"{Resources.UserCurrencyNotFound}\n{Resources.TryAgain}");

                    return;
                }

                var currencies = db.Currencies.ToList();
                ComboBoxOfCurrency.DataSource = currencies;
                ComboBoxOfCurrency.DisplayMember = Resources.CurrencyName;
                ComboBoxOfCurrency.ValueMember = Resources.Currency_Id;
                ComboBoxOfCurrency.SelectedValue = user.CurrencyId;

                UpdateCurrencyInfo(startCurrency);

                LoggerService.Debug($"Загружено {currencies.Count} валют. Текущая: {startCurrency.CurrencyName}");
            }
            catch (Exception ex)
            {
                LoggerService.Error("Ошибка загрузки валют.", ex);

                EH.ShowError($"{Resources.ErrorWhileLoadingData}\n{Resources.TryAgain}");

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
                    LoggerService.Error($"{Resources.UserNotFound}: {userLogin}");
                    EH.ShowError($"{Resources.UserNotFound}\n{Resources.TryAgain}");
                    return;
                }

                user.CurrencyId = newCurrencyId;

                if (EH.DBSaveChangesUniversalErrorCheck(db))
                {
                    LoggerService.Error("Не удалось сохранить настройки пользователя.");
                    return;
                }

                var newCurrency = db.Currencies.FirstOrDefault(c => c.Currency_Id == newCurrencyId);

                LoggerService.Info($"Настройки пользователя {userLogin} сохранены. Новая валюта: {newCurrency?.CurrencyName}.");

                EH.ShowInformation($"{Resources.SettingsSavedSuccessfully}\n" +
                                   $"{Resources.NewCurrency}: {newCurrency?.CurrencyName}.\n" +
                                   $"{Resources.ExchangeRate}: {newCurrency?.ExchangeRate:F4}.");

                originalCurrencyId = newCurrencyId;
                currencyChanged = false;

                LoadMainMenu();
            }
            catch (Exception ex)
            {
                LoggerService.Error($"Ошибка при сохранении настроек.", ex);

                EH.ShowError($"{Resources.ErrorSave}\n{Resources.TryAgain}");

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            LoggerService.Info("Настройки отменены пользователем.");

            LoadMainMenu();
        }

        private void LoadMainMenu()
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
    }
}
