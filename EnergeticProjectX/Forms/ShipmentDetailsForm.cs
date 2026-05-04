using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using FH = EnergeticProjectX.Classes.FormHandler;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма просмотра подробной информации об отгрузке.
    /// </summary>
    public partial class ShipmentDetailsForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        private readonly Shipment currentShipment;

        /// <summary>
        /// Конструктор для реализации формы подробностей отгрузок.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <param name="currentShipment">Заданная отгрузка.</param>
        public ShipmentDetailsForm(string userLogin, Shipment currentShipment)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            
            this.currentShipment = currentShipment;

            LoadShipmentDetails();
        }

        private void LoadShipmentDetails()
        {
            try
            {
                var user = Db.Users.FirstOrDefault(u => u.User_Id == currentShipment.User_Id);

                var client = Db.Clients.FirstOrDefault(c => c.Client_Id == currentShipment.Client_Id);

                var shipmentItems = Db.ShipmentItems
                    .Where(si => si.Shipment_Id == currentShipment.Shipment_Id)
                    .Include(si => si.Product)
                    .ThenInclude(p => p!.Category)
                    .ThenInclude(c => c!.Unit)
                    .ToList();

                var totalRevenue = shipmentItems.Sum(si => si.FixedSalePrice * si.Quantity);
                var totalCost = shipmentItems.Sum(si => si.FixedPurchasePrice * si.Quantity);
                var profit = totalRevenue - totalCost;

                var revenueFormatted = PCM.PriceToCorrectFormat(Db, PCM.SetPriceToChosenCurrency(Db, totalRevenue, userLogin), userLogin);

                var profitFormatted = PCM.PriceToCorrectFormat(Db, PCM.SetPriceToChosenCurrency(Db, profit, userLogin), userLogin);

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
                    SalePrice = PCM.PriceToCorrectFormat(Db, PCM.SetPriceToChosenCurrency(Db, si.FixedSalePrice, userLogin), userLogin)
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
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var shipmentJournal = new TableOfShipmentsForm(userLogin);
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
