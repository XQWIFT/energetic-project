using EnergeticProjectX.Classes;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using AdministratorPanelForm;
using EnergeticProjectX.Forms;
using System.Text;

namespace ShipmentJournalForm
{
    /// <summary>
    /// Форма журнала отгрузок для администратора.
    /// </summary>
    public partial class ShipmentJournal : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly string userLogin;

        private Shipment? selectedShipment;
        private List<ShipmentJournalDisplayModel> allShipments = [];

        /// <summary>
        /// Конструктор для реализации формы.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public ShipmentJournal(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoggerService.Info($"{Resources.ShipmentJournalOpened} {userLogin}");

            DateTimePickerFrom.Value = DateTime.Today;
            DateTimePickerTo.Value = DateTime.Today.AddDays(1);

            DateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            DateTimePickerFrom.CustomFormat = Resources.CorrectDateFormat;
            DateTimePickerTo.Format = DateTimePickerFormat.Custom;
            DateTimePickerTo.CustomFormat = Resources.CorrectDateFormat;

            DataGridViewOfShipments.CellClick += DataGridViewOfShipments_CellClick;
            DateTimePickerFrom.ValueChanged += DateTimePickerFrom_ValueChanged;
            DateTimePickerTo.ValueChanged += DateTimePickerTo_ValueChanged;

            LoadShipments();

            selectedShipment = null;

            UpdateButtonStates();
        }

        private void LoadShipments()
        {
            try
            {
                LoggerService.Debug($"{Resources.StartLoadingShipments}.\n{Resources.RangeRus}:" +
                                    $"{DateTimePickerFrom.Value:dd.MM.yyyy} - {DateTimePickerTo.Value:dd.MM.yyyy}");

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

                LoggerService.Debug($"{Resources.ShipmentsLoaded} {shipmentsList.Count}");

                allShipments = [];

                foreach (var shipment in shipmentsList)
                {
                    try
                    {
                        var user = db.Users.FirstOrDefault(u => u.User_Id == shipment.User_Id);
                        var userName = user != null ? $"{user.Surname} {user.Name}".Trim(): Resources.Notstated;

                        var client = db.Clients.FirstOrDefault(c => c.Client_Id == shipment.Client_Id);

                        var shipmentItems = db.ShipmentItems.Where(si => si.Shipment_Id == shipment.Shipment_Id).ToList();

                        var totalRevenue = shipmentItems.Sum(si => si.FixedSalePrice * si.Quantity);

                        var totalCost = shipmentItems.Sum(si => si.FixedPurchasePrice * si.Quantity);

                        var profit = totalRevenue - totalCost;

                        var totalRevenueString = PriceCurrencyManager.PriceToCorrectFormat(db, PriceCurrencyManager.SetPriceToChosenCurrency(db, totalRevenue, userLogin), userLogin);

                        var totalProfitString = PriceCurrencyManager.PriceToCorrectFormat(db, PriceCurrencyManager.SetPriceToChosenCurrency(db, profit, userLogin), userLogin);

                        allShipments.Add(new ShipmentJournalDisplayModel
                        {
                            ShipmentId = shipment.Shipment_Id,
                            UserName = userName,
                            ClientName = client?.Name ?? Resources.Notstated,
                            Date = DateOnly.FromDateTime(shipment.CreationDate),
                            Revenue = totalRevenueString,
                            Profit = totalProfitString,
                            RevenueValue = totalRevenue,
                            ProfitValue = profit

                        });

                        LoggerService.Debug($"{Resources.ShipmentLoaded} {shipment.Shipment_Id}:\n{Resources.Revenue}:{totalRevenueString}\n" +
                                            $"{Resources.TotalProfit}: {totalProfitString}");
                    }
                    catch (Exception ex)
                    {
                        LoggerService.Error($"{Resources.ErrorWhileLoadingShipment} {shipment.Shipment_Id}", ex);
                    }
                }

                DataGridViewOfShipments.DataSource = null;
                DataGridViewOfShipments.DataSource = allShipments;

                LoggerService.Info($"{Resources.ShipmentsLoaded} {allShipments.Count}");

                if (allShipments.Count == 0)
                {
                    LoggerService.Info(Resources.ShipmentNotFounded);
                }
            }
            catch (Exception ex)
            {
                LoggerService.Error(Resources.CriticalErrorWhenLoadingShipments, ex);

                MessageBox.Show($"{Resources.ErrorWhileLoadingData}\n{Resources.TryAgain}", Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                allShipments = [];
                DataGridViewOfShipments.DataSource = allShipments;

                return;
            }
        }

        private void DataGridViewOfShipments_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                selectedShipment = null;
                UpdateButtonStates();
                return;
            }

            DataGridViewOfShipments.ClearSelection();
            DataGridViewOfShipments.Rows[e.RowIndex].Selected = true;

            DataGridViewOfShipments.ClearSelection();
            DataGridViewOfShipments.Rows[e.RowIndex].Selected = true;

            if (e.RowIndex < allShipments.Count &&
                DataGridViewOfShipments.Rows[e.RowIndex].DataBoundItem is ShipmentJournalDisplayModel model)
            {
                selectedShipment = db.Shipments.FirstOrDefault(s => s.Shipment_Id == model.ShipmentId);

                LoggerService.Debug($"{Resources.ShipmentSelected}: {selectedShipment?.Shipment_Id}");
            }
            else
            {
                selectedShipment = null;
            }

            UpdateButtonStates();
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
            LoggerService.Info(Resources.ReturnToMainMenu);

            Hide();
            var administratorPanel = new AdministratorPanel(userLogin);
            administratorPanel.ShowDialog();
            Close();
        }

        private void ExportToCsv(string filePath)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Resources.CreatedBy};{Resources.Client};{Resources.Date}; {Resources.Revenue};{Resources.Profit}");

            var totalRevenue = 0m;
            var totalProfit = 0m;

            foreach (var shipment in allShipments)
            {
                stringBuilder.AppendLine($"{shipment.UserName};{shipment.ClientName};{shipment.Date:dd.MM.yyyy};{shipment.Revenue};{shipment.Profit}");

                totalRevenue += shipment.RevenueValue;
                totalProfit += shipment.ProfitValue;
            }

            var totalRevenueDisplay = PriceCurrencyManager.PriceToCorrectFormat(db, PriceCurrencyManager.SetPriceToChosenCurrency(db, totalRevenue, userLogin), userLogin);
            var totalProfitDisplay = PriceCurrencyManager.PriceToCorrectFormat(db, PriceCurrencyManager.SetPriceToChosenCurrency(db, totalProfit, userLogin), userLogin);

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{Resources.TotalRevenue};{totalRevenueDisplay}");
            stringBuilder.AppendLine($"{Resources.TotalProfit};{totalProfitDisplay}");
            stringBuilder.AppendLine($"{Resources.TotalShipments};{allShipments.Count}");

            File.WriteAllText(filePath, stringBuilder.ToString(), new UTF8Encoding(true));

            LoggerService.Info($"{Resources.ReportExported}: {filePath}\n{Resources.TotalRevenue}: {totalRevenueDisplay}\n{Resources.TotalProfit}: {totalProfitDisplay}");

            MessageBox.Show($"{Resources.ReportExportedSuccessfully}\n\n{Resources.TotalRevenue}: {totalRevenueDisplay} ₽\n{Resources.TotalProfit}: {totalProfitDisplay} ₽\n" +
                            $"{Resources.TotalShipments}: {allShipments.Count}", Resources.TitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DateTimePickerTo_ValueChanged(object? sender, EventArgs e)
        {
            if (DateTimePickerTo.Value < DateTimePickerFrom.Value)
            {
                LoggerService.Warning($"{Resources.IncorrectDataPeriod}: " +
                                     $"From={DateTimePickerFrom.Value:dd.MM.yyyy}, " +
                                     $"To={DateTimePickerTo.Value:dd.MM.yyyy}");

                MessageBox.Show($"{Resources.IncorrectPeriodOfDates}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                LoggerService.Warning($"Некорректный выбор начальной даты: {DateTimePickerFrom.Value:dd.MM.yyyy}");

                MessageBox.Show($"{Resources.StartDateCannotBeInFuture}\n{Resources.TryAgain}", Resources.TitleWarning,
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                LoggerService.Info($"{Resources.ExportReportStarted}: {DateTimePickerFrom.Value:dd.MM.yyyy} - {DateTimePickerTo.Value:dd.MM.yyyy}");

                var fileName = $"ShipmentReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                using SaveFileDialog saveDialog = new();
                saveDialog.Filter = "CSV files|*.csv|All files|*.*";
                saveDialog.FileName = fileName;
                saveDialog.Title = Resources.SaveReportAs;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                    ExportToCsv(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                LoggerService.Error(Resources.ErrorExportReport, ex);

                MessageBox.Show($"{Resources.ErrorExportReport}\n{ex.Message}",
                               Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfContent_Click(object sender, EventArgs e)
        {
            if (selectedShipment == null)
            {
                MessageBox.Show(Resources.SelectShipmentForDetails, Resources.TitleWarning,
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoggerService.Info($"{Resources.OpenShipmentDetails}: {selectedShipment}");

            Hide();
            var shipmentDetails = new ShipmentDetails(userLogin, selectedShipment);
            shipmentDetails.ShowDialog();
            Close();
        }
    }
}