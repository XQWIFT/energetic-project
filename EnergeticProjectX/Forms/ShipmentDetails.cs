using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
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
    public partial class ShipmentDetails : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private readonly Shipment currentShipment;

        /// <summary>
        /// Конструктор для реализации формы подробностей отгрузок.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <param name="currentShipment">Заданная отгрузка.</param>
        public ShipmentDetails(string userLogin, Shipment currentShipment)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            
            this.currentShipment = currentShipment;

            LoadShipmentDetails();
        }

        private void ButtonOfGoingBack_Click(object sender, EventArgs e)
        {
            Hide();
            var shipmentJournal = new ShipmentJournal(userLogin);
            shipmentJournal.ShowDialog();
            Close();
        }

        private void LoadShipmentDetails()
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.User_Id == currentShipment.User_Id);

                var client = db.Clients.FirstOrDefault(c => c.Client_Id == currentShipment.Client_Id);

                var shipmentItems = db.ShipmentItems
                    .Where(si => si.Shipment_Id == currentShipment.Shipment_Id)
                    .Include(si => si.Product)
                    .ThenInclude(p => p!.Category)
                    .ThenInclude(c => c!.Unit)
                    .ToList();

                var totalRevenue = shipmentItems.Sum(si => si.FixedSalePrice * si.Quantity);
                var totalCost = shipmentItems.Sum(si => si.FixedPurchasePrice * si.Quantity);
                var profit = totalRevenue - totalCost;

                var revenueFormatted = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, totalRevenue, userLogin), userLogin);

                var profitFormatted = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, profit, userLogin), userLogin);

                TextBoxOfUserData.Text = user != null ? $"{user.Surname} {user.Name}".Trim() : Resources.Notstated;
                TextBoxOfClient.Text = client?.Name ?? Resources.Notstated;
                TextBoxOfRevenue.Text = revenueFormatted;
                TextBoxOfProfit.Text = profitFormatted;
                TextBoxOfDate.Text = DateOnly.FromDateTime(currentShipment.CreationDate).ToString("dd.MM.yyyy");

                var displayData = shipmentItems.Select(si => new ShipmentItemDetailModel
                {
                    Name = si.Product?.Name ?? Resources.Notstated,
                    Category = si.Product?.Category?.Name ?? Resources.Notstated,
                    Quantity = si.Quantity,
                    Unit = si.Product?.Category?.Unit?.Name ?? Resources.Notstated,
                    SalePrice = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, si.FixedSalePrice, userLogin), userLogin)
                }).ToList();

                DataGridViewOfShipmentProducts.DataSource = displayData;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorWhileLoadingData, true);

                return;
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
