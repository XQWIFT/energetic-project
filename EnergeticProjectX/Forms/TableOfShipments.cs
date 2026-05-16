using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма журнала отгрузок для отображения совершённых отгрузок.
    /// </summary>
    public partial class TableOfShipmentsForm : Form
    {
         //ApplicationContextDB Db = new ApplicationContextDB();
        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        private bool isUpdatingDates = false;

        private Shipment? selectedShipment;

        private List<ShipmentJournalDisplayModel> allShipments = [];

        private const int DefaultDateRangeDays = 7;
        /// <summary>
        /// Конструктор для реализации формы журнала отгрузок.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public TableOfShipmentsForm(string userLogin, IUserService userService, IClientService clientService,
            IProductService productService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _productService = productService;
            
            _clientService = clientService;

           

            DateTimePickerFrom.Value = DateTime.Today.AddDays(-DefaultDateRangeDays);
            DateTimePickerTo.Value = DateTime.Today;

            LoadShipments();
            UpdateButtonStates();

            selectedShipment = null;
        }

        private void LoadShipments()
        {
            try
            {
                var users = _userService.GetUsersInDictionary();
                var clients = _clientService.GetClientsInDictionary();

                var query = _productService.GetShipmentsInQuery();

                var fromDate = DateOnly.FromDateTime(DateTimePickerFrom.Value.Date);
                var toDate = DateOnly.FromDateTime(DateTimePickerTo.Value.Date);

                var fromDateUtc = TH.LocalDateToUtcStartOfDay(fromDate);
                query = query.Where(s => s.CreationDate >= fromDateUtc);

                var toDateUtc = TH.LocalDateToUtcStartOfNextDay(toDate.AddDays(1));
                query = query.Where(s => s.CreationDate < toDateUtc);

                var shipmentsList = query.OrderByDescending(s => s.CreationDate).ToList();

                allShipments = new List<ShipmentJournalDisplayModel>(shipmentsList.Count);

                foreach (var shipment in shipmentsList)
                {
                    if (!users.TryGetValue(shipment.User_Id, out var user) ||
                        !clients.TryGetValue(shipment.Client_Id, out var client))
                    {
                        continue;
                    }

                    var userName = $"{user.Surname} {user.Name}";
                    var shipmentItems = _productService.GetShipmentItemsByID(shipment.Shipment_Id);

                    var totalRevenue = shipmentItems.Sum(si => si.FixedSalePrice * si.Quantity);
                    var totalCost = shipmentItems.Sum(si => si.FixedPurchasePrice * si.Quantity);
                    var profit = totalRevenue - totalCost;

                    allShipments.Add(new ShipmentJournalDisplayModel
                    {
                        ShipmentId = shipment.Shipment_Id,
                        UserName = userName,
                        ClientName = client.Name,
                        Date = TH.UtcDateToLocalDateOnly(DateOnly.FromDateTime(shipment.CreationDate)),
                        Revenue = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, totalRevenue, userLogin), userLogin),
                        Profit = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, profit, userLogin), userLogin),
                        RevenueValue = totalRevenue,
                        ProfitValue = profit
                    });
                }

                DGVOfShipments.DataSource = null;
                DGVOfShipments.DataSource = allShipments;
                UpdateButtonStates();
            }
            catch (Exception)
            {
                allShipments = [];
                DGVOfShipments.DataSource = allShipments;
                EH.ShowError(Resources.ErrorWhileLoadingData, true);
                return;
            }
        }

        private void UpdateButtonStates()
        {
            ButtonOfContent.Enabled = selectedShipment != null;

            var hasDateRange = DateTimePickerFrom.Value.Date != DateTime.Today ||
                               DateTimePickerTo.Value.Date != DateTime.Today;

            var hasData = allShipments.Count > 0;

            ButtonOfExport.Enabled = hasDateRange && hasData;
        }

        private void ValidateDateRange()
        {
            if (isUpdatingDates) return;
            isUpdatingDates = true;

            try
            {
                if (DateTimePickerFrom.Value.Date > DateTime.Today)
                {
                    EH.ShowWarning(Resources.StartDateCannotBeInFuture, true);
                    DateTimePickerFrom.Value = DateTime.Today;
                }

                if (DateTimePickerTo.Value.Date > DateTime.Today)
                {
                    EH.ShowWarning(Resources.EndDateCannotBeInFuture, true);
                    DateTimePickerTo.Value = DateTime.Today;
                }

                if (DateTimePickerFrom.Value.Date > DateTimePickerTo.Value.Date)
                {
                    DateTimePickerTo.Value = DateTimePickerFrom.Value;
                    EH.ShowWarning(Resources.IncorrectPeriodOfDates, true);
                }
            }
            finally
            {
                isUpdatingDates = false;
            }
        }

        private void DateTimePicker_ValueChanged(object? sender, EventArgs e)
        {
            if (isUpdatingDates) return;

            ValidateDateRange();
            LoadShipments();
            UpdateButtonStates();
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

            if (e.RowIndex < allShipments.Count &&
                DGVOfShipments.Rows[e.RowIndex].DataBoundItem is ShipmentJournalDisplayModel shipmentModel)
            {
                selectedShipment = _productService.GetShipmentById(shipmentModel.ShipmentId);
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

        private void ExportToCsv(string filePath)
        {
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }
                

            var currency = _userService.FindUserChosenCurrency(user);

            if (currency == null)
            {
                EH.ShowError(Resources.UserCurrencyNotFound, true);

                return;
            }

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

            var totalRevenueDisplay = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, totalRevenue, userLogin), userLogin);
            var totalProfitDisplay = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, totalProfit, userLogin), userLogin);

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{Resources.TotalRevenue};{totalRevenueDisplay}");
            stringBuilder.AppendLine($"{Resources.TotalProfit};{totalProfitDisplay}");
            stringBuilder.AppendLine($"{Resources.TotalShipments};{allShipments.Count}");

            File.WriteAllText(filePath, stringBuilder.ToString(), new UTF8Encoding(true));

            EH.ShowInformation($"{Resources.ReportSuccessfullyExported}\n\n{Resources.TotalRevenue}: {totalRevenueDisplay} {currency.CurrencySymbol}\n" +
                               $"{Resources.TotalProfit}: {totalProfitDisplay} {currency.CurrencySymbol}\n" + $"{Resources.TotalShipments}: {allShipments.Count}");
        }

        private void ButtonOfExport_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            if (allShipments.Count == 0)
            {
                EH.ShowWarning(Resources.ThereIsNoDataToExport, true);
                return;
            }

            try
            {
                var fileName = $"ShipmentReport_{DateTime.Now:dd.MM.yyyy_HH:mm:ss}.csv";

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

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            var administratorMainMenu = new AdministratorMainMenu(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, administratorMainMenu);
        }

        private void ButtonOfContent_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            if (selectedShipment == null)
            {
                EH.ShowAlert(Resources.SelectShipmentForDetails);

                return;
            }

            var shipmentDetails = new ShipmentDetailsForm(userLogin, selectedShipment, _userService, _productService, _clientService);
            FH.OpenForm(this, shipmentDetails);
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