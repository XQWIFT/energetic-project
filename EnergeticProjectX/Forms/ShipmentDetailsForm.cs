using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using FH = EnergeticProjectX.Classes.FormHandler;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма просмотра подробной информации об отгрузке.
    /// </summary>
    public partial class ShipmentDetailsForm : Form
    {
        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        private readonly Shipment currentShipment;

        /// <summary>
        /// Конструктор для реализации формы подробностей отгрузок.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <param name="currentShipment">Заданная отгрузка.</param>
        public ShipmentDetailsForm(string userLogin, Shipment currentShipment,
            IUserService userService, IProductService productService, IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _productService = productService;

             _clientService = clientService;
            
            this.currentShipment = currentShipment;

            LoadShipmentDetails();
        }

        private void LoadShipmentDetails()
        {
            try
            {
                var user = _userService.FindUserById(currentShipment.User_Id);

                var client = _clientService.FindClientById(currentShipment.Client_Id);

                var shipmentItems = _productService.GetShipmentItemsByID(currentShipment.Shipment_Id);

                var totalRevenue = shipmentItems.Sum(si => si.FixedSalePrice * si.Quantity);
                var totalCost = shipmentItems.Sum(si => si.FixedPurchasePrice * si.Quantity);
                var profit = totalRevenue - totalCost;

                var revenueFormatted = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, totalRevenue, userLogin), userLogin);

                var profitFormatted = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, profit, userLogin), userLogin);

                TextBoxOfUserData.Text = user != null ? $"{user.Surname} {user.Name}".Trim() : Resources.Notstated;
                TextBoxOfClient.Text = client?.Name ?? Resources.Notstated;
                TextBoxOfRevenue.Text = revenueFormatted;
                TextBoxOfProfit.Text = profitFormatted;
                TextBoxOfDate.Text = DateOnly.FromDateTime(TH.UtcToLocalDateTime(currentShipment.CreationDate)).ToString("dd.MM.yyyy");

                var displayData = shipmentItems.Select(si => new ShipmentItemDetailModel
                {
                    Name = si.Product?.Name ?? Resources.Notstated,
                    Category = si.Product?.Category?.Name ?? Resources.Notstated,
                    Quantity = si.Quantity,
                    Unit = si.Product?.Category?.Unit?.Name ?? Resources.Notstated,
                    SalePrice = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, si.FixedSalePrice, userLogin), userLogin)
                }).ToList();

                DataGridViewOfShipmentProducts.DataSource = displayData;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorWhileLoadingData, true);

                return;
            }
        }

        private void ButtonOfGoingBack_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            var shipmentJournal = new TableOfShipmentsForm(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, shipmentJournal);
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
