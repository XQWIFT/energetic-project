using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для пользовательских настроек приложения.
    /// </summary>
    public partial class SettingsForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        private Guid originalCurrencyId;

        private bool currencyChanged = false;

        /// <summary>
        /// Конструктор для реализации формы пользовательских настроек.
        /// </summary>
        public SettingsForm(string userLogin, IUserService userService, IProductService productService,
            IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _clientService = clientService;

            _productService = productService;

            LoadCurrencies();
        }

        private void LoadCurrencies()
        {

            try
            {
                var user = _userService.EnsureUserActive(userLogin);

                if (user == null)
                {
                    EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                    return;
                }

                originalCurrencyId = user.CurrencyId;

                var startCurrency = _userService.FindUserChosenCurrency(user);

                if (startCurrency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                var currencies = _userService.GetAllCurrencies();
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
                var currency = _userService.GetCurrencyById(currencyId);

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
                var user = _userService.EnsureUserActive(userLogin);

                if (user == null)
                {
                    EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                    return;
                }
                    

                if (ComboBoxOfCurrency.SelectedValue is not Guid newCurrencyId)
                {
                    EH.ShowWarning(Resources.SelectCurrency);

                    return;
                }

                user.CurrencyId = newCurrencyId;

                if (_userService.DbSaveChangesErrorCheck())
                {
                    EH.ShowError(Resources.UniversalErrorDatabase, true);
                    return;
                }
                    

                var newCurrency = _userService.GetCurrencyById(newCurrencyId);

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
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            OpenMainMenu(user);
        }

        private void OpenMainMenu(User user)
        {
            if (user.UserRole == UserRoles.Administrator)
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin, _userService, _clientService, _productService);
                FH.OpenForm(this, administratorMainMenu);
            }
            else if (user.UserRole == UserRoles.Warehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin, _userService, _productService, _clientService);
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
