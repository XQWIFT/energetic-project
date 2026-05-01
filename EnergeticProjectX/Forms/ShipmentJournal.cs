using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма журнала отгрузок для отображения совершённых отгрузок.
    /// </summary>
    public partial class ShipmentJournal : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private Shipment? selectedShipment;

        private List<ShipmentJournalDisplayModel> allShipments = [];

        /// <summary>
        /// Конструктор для реализации формы журнала отгрузок.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public ShipmentJournal(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            DateTimePickerFrom.Value = DateTime.Today.AddDays(-7);
            DateTimePickerTo.Value = DateTime.Today;

            LoadShipments();
            UpdateButtonStates();

            selectedShipment = null;
        }

        private void DataGridViewOfShipments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                selectedShipment = null;
                UpdateButtonStates();
                return;
            }

            DGVOfShipments.ClearSelection();
            DGVOfShipments.Rows[e.RowIndex].Selected = true;

            DGVOfShipments.ClearSelection();
            DGVOfShipments.Rows[e.RowIndex].Selected = true;

            if (e.RowIndex < allShipments.Count &&
                DGVOfShipments.Rows[e.RowIndex].DataBoundItem is ShipmentJournalDisplayModel model)
            {
                selectedShipment = db.Shipments.FirstOrDefault(s => s.Shipment_Id == model.ShipmentId);
            }
            else
            {
                selectedShipment = null;
            }

            UpdateButtonStates();
        }

        private void DataGridViewOfShipments_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DGVOfShipments.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? string.Empty;

                var columnName = DGVOfShipments.Columns[e.ColumnIndex].HeaderText;

                var tooltipText = $"{columnName}: {cellValue}";

                cell.ToolTipText = tooltipText;
            }
        }

        private void LoadShipments()
        {
            try
            {
                var query = db.Shipments.AsQueryable();

                if (DateTimePickerFrom.Value.Date != DateTime.Today.Date)
                {
                    var fromDateUtc = DateTime.SpecifyKind(DateTimePickerFrom.Value.Date, DateTimeKind.Utc);
                    query = query.Where(s => s.CreationDate >= fromDateUtc);
                }

                if (DateTimePickerTo.Value.Date != DateTime.Today.Date)
                {
                    var toDateUtc = DateTime.SpecifyKind(DateTimePickerTo.Value.Date.AddDays(1), DateTimeKind.Utc);
                    query = query.Where(s => s.CreationDate < toDateUtc);
                }

                var shipmentsList = query.OrderByDescending(s => s.CreationDate).ToList();

                allShipments = [];

                foreach (var shipment in shipmentsList)
                {
                    var user = db.Users.FirstOrDefault(u => u.User_Id == shipment.User_Id);

                    if (user == null)
                    {
                        EH.ShowError(Resources.UserNotFound, true);

                        return;
                    }

                    var userFirstnameAndSurname = $"{user.Surname} {user.Name}".Trim();

                    var client = db.Clients.FirstOrDefault(c => c.Client_Id == shipment.Client_Id);

                    if (client == null)
                    {
                        EH.ShowError(Resources.ClientsLoadError, true);

                        return;
                    }

                    var shipmentItems = db.ShipmentItems.Where(si => si.Shipment_Id == shipment.Shipment_Id).ToList();

                    var totalRevenue = 0m;
                    var totalCost = 0m;

                    foreach (var shipmentItem in shipmentItems)
                    {
                        totalRevenue += PCM.SetPriceToChosenCurrency(db, shipmentItem.FixedSalePrice, userLogin) * shipmentItem.Quantity;

                        totalCost += PCM.SetPriceToChosenCurrency(db, shipmentItem.FixedPurchasePrice, userLogin) * shipmentItem.Quantity;
                    }

                    var profit = totalRevenue - totalCost;

                    var totalRevenueString = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, totalRevenue, userLogin), userLogin);

                    var totalProfitString = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, profit, userLogin), userLogin);

                    allShipments.Add(new ShipmentJournalDisplayModel
                    {
                        ShipmentId = shipment.Shipment_Id,
                        UserName = userFirstnameAndSurname,
                        ClientName = client.Name,
                        Date = DateOnly.FromDateTime(shipment.CreationDate),
                        Revenue = totalRevenueString,
                        Profit = totalProfitString,
                        RevenueValue = totalRevenue,
                        ProfitValue = profit

                    });
                }

                DGVOfShipments.DataSource = null;
                DGVOfShipments.DataSource = allShipments;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorWhileLoadingData, true);

                allShipments = [];
                DGVOfShipments.DataSource = allShipments;

                return;
            }
        }

        private void UpdateButtonStates()
        {
            ButtonOfContent.Enabled = selectedShipment != null;

            var hasDateRange = DateTimePickerFrom.Value != DateTime.Today ||
                               DateTimePickerTo.Value != DateTime.Today;

            var hasData = allShipments.Count > 0;

            ButtonOfExport.Enabled = hasDateRange && hasData;
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            var administratorPanel = new AdministratorPanel(userLogin);
            administratorPanel.ShowDialog();
            Close();
        }

        private void ExportToCsv(string filePath)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Resources.CreatedBy};{Resources.Client};{Resources.Date};{Resources.Revenue};{Resources.Profit}");

            var totalRevenue = 0m;
            var totalProfit = 0m;

            foreach (var shipment in allShipments)
            {
                stringBuilder.AppendLine($"{shipment.UserName};{shipment.ClientName};{shipment.Date:dd.MM.yyyy};{shipment.Revenue};{shipment.Profit}");

                totalRevenue += shipment.RevenueValue;
                totalProfit += shipment.ProfitValue;
            }

            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }

            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

            if (currency == null)
            {
                EH.ShowError(Resources.UserCurrencyNotFound, true);

                return;
            }

            var totalRevenueDisplay = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, totalRevenue, userLogin), userLogin);
            var totalProfitDisplay = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, totalProfit, userLogin), userLogin);

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{Resources.TotalRevenue};{totalRevenueDisplay}");
            stringBuilder.AppendLine($"{Resources.TotalProfit};{totalProfitDisplay}");
            stringBuilder.AppendLine($"{Resources.TotalShipments};{allShipments.Count}");

            File.WriteAllText(filePath, stringBuilder.ToString(), new UTF8Encoding(true));

            EH.ShowInformation($"{Resources.ReportSuccessfullyExported}\n\n{Resources.TotalRevenue}: {totalRevenueDisplay} {currency.CurrencySymbol}\n" +
                               $"{Resources.TotalProfit}: {totalProfitDisplay} ₽\n" + $"{Resources.TotalShipments}: {allShipments.Count}");
        }

        private void DateTimePickerTo_ValueChanged(object? sender, EventArgs e)
        {
            if (DateTimePickerTo.Value < DateTimePickerFrom.Value)
            {
                EH.ShowWarning(Resources.IncorrectPeriodOfDates, true);

                DateTimePickerTo.Value = DateTimePickerFrom.Value;

                return;
            }

            LoadShipments();
            UpdateButtonStates();
        }

        private void DateTimePickerFrom_ValueChanged(object? sender, EventArgs e)
        {
            if (DateTimePickerFrom.Value.Date > DateTime.Today)
            {
                EH.ShowWarning(Resources.StartDateCannotBeInFuture, true);

                DateTimePickerFrom.Value = DateTime.Today;
                return;
            }

            LoadShipments();
            UpdateButtonStates();
        }

        private void ButtonOfExport_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = $"ShipmentReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                var saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files|*.csv|All files|*.*",
                    FileName = fileName,
                    Title = Resources.SaveReportAs
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                    ExportToCsv(saveDialog.FileName);
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorExportReport, true);

                return;
            }
        }

        private void ButtonOfContent_Click(object sender, EventArgs e)
        {
            if (selectedShipment == null)
            {
                EH.ShowAlert(Resources.SelectShipmentForDetails);

                return;
            }

            Hide();
            var shipmentDetails = new ShipmentDetails(userLogin, selectedShipment);
            shipmentDetails.ShowDialog();
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