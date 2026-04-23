using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;
using WarehousemanPanelForm;

namespace MakingShipmentForm
{
    /// <summary>
    /// Форма оформления отгрузки
    /// </summary>
    public partial class MakingShipment : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private readonly List<ShipmentItemRow> shipmentItems = [];

        private ShipmentItemRow? selectedShipmentItem;

        /// <summary>
        /// Конструктор оформления отгрузки
        /// </summary>
        public MakingShipment(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoggerService.Info($"{Resources.SLMakingShipmentFormIsOpened} {userLogin}");

            LoadClients();
            LoadProducts();

            UpdateButtonStates();

            DataGridOfItems.CellClick += DataGridOfItems_CellClick;
            ComboBoxOfClient.SelectedIndexChanged += ValidateFields!;
            ComboBoxOfProduct.SelectedIndexChanged += ComboBoxProduct_SelectedIndexChanged!;
            NumericQuantity.ValueChanged += ValidateFields!;
        }

        private void LoadClients()
        {
            var clients = db.Clients.ToList();

            ComboBoxOfClient.DataSource = clients;
            ComboBoxOfClient.DisplayMember = "Name";
            ComboBoxOfClient.ValueMember = "Client_Id";
        }

        private void LoadProducts()
        {
            var products = db.Products
                .Where(p => p.Status == ProductStatus.Active)
                .ToList();

            ComboBoxOfProduct.DataSource = products;
            ComboBoxOfProduct.DisplayMember = "Name";
            ComboBoxOfProduct.ValueMember = "Article";
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfClient.SelectedValue == null || ComboBoxOfProduct.SelectedValue == null)
                {
                    MessageBox.Show(Resources.FillRequiredFields, Resources.TitleWarning,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                string article = ComboBoxOfProduct.SelectedValue.ToString()!;
                var product = db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null)
                {
                    LoggerService.Warning($"{Resources.Product} {article} {Resources.NotFoundInDB}");

                    return;
                }

                int quantity = (int)NumericQuantity.Value;

                int alreadyAdded = shipmentItems
                    .Where(i => i.Article == article)
                    .Sum(i => i.Quantity);

                if (alreadyAdded + quantity > product.StockQuantity)
                {
                    int available = product.StockQuantity - alreadyAdded;
                    LoggerService.Warning($"{Resources.TryToAdd} {article}.\n{Resources.Quantity}: {quantity}\n{Resources.Available}: {available}");

                    MessageBox.Show($"{Resources.NotEnoughProductInStock}\n{Resources.Available}: {available}",
                                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                Guid clientId = Guid.Parse(ComboBoxOfClient.SelectedValue.ToString()!);
                string clientName = db.Clients.FirstOrDefault(c => c.Client_Id == clientId)?.Name ?? "—";

                var newItem = new ShipmentItemRow
                {
                    Article = article,
                    Name = product.Name,
                    Quantity = quantity,
                    ClientId = clientId,
                    ClientName = clientName,
                    PriceSnapshot = PriceCurrencyManager.PriceToCorrectFormat(db, PriceCurrencyManager.SetPriceToChosenCurrency(db, product.PurchasePrice, userLogin), userLogin)
                };

                shipmentItems.Add(newItem);
                LoggerService.Info($"{Resources.Product} {article} {Resources.AddedToShipment}\n{Resources.Quantity}: {quantity}");

                RefreshItemsGrid();
                UpdateButtonStates();

                NumericQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                LoggerService.Error(Resources.ProductAddToShipmentError, ex);

                MessageBox.Show($"{Resources.ProductAddToShipmentError}\n{Resources.TryAgain}",
                               Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }


        private void RefreshItemsGrid()
        {
            DataGridOfItems.DataSource = null;

            var displayData = shipmentItems
                .Select((i, index) => new ShipmentItemDisplayModel
                {
                    Article = i.Article,
                    Name = i.Name,
                    Quantity = i.Quantity,
                    ClientName = i.ClientName
                })
                .ToList();

            DataGridOfItems.DataSource = displayData;

            if (selectedShipmentItem != null)
            {
                var selectedIndex = shipmentItems.IndexOf(selectedShipmentItem);
                if (selectedIndex >= 0 && selectedIndex < DataGridOfItems.Rows.Count)
                {
                    DataGridOfItems.ClearSelection();
                    DataGridOfItems.Rows[selectedIndex].Selected = true;
                }
            }

            LoggerService.Debug($"{Resources.ShipmentUploaded}: {shipmentItems.Count}");
        }

        private void ButtonMakeShipment_Click(object sender, EventArgs e)
        {
            if (shipmentItems.Count == 0)
            {
                MessageBox.Show(Resources.NoProductsInShipment, Resources.TitleWarning,
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var result = MessageBox.Show($"{Resources.SureWantToMakeShipment}\n\n{Resources.ProductNumber}: {shipmentItems.Count}",
                                        Resources.TitleConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                LoggerService.Info(Resources.ShipmentCreationCancelledByUser);
                return;
            }

            try
            {
                LoggerService.Info($"{Resources.StartOfMakingShipment} {shipmentItems.Count}");

                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
                if (user == null)
                {
                    LoggerService.Error($"{userLogin}: {Resources.UserNotFound}");
                    MessageBox.Show($"{Resources.UserNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var clientId = shipmentItems.First().ClientId;

                var shipment = new Shipment
                {
                    CreationDate = DateTime.UtcNow,
                    Client_Id = clientId,
                    User_Id = user.User_Id
                };

                db.Shipments.Add(shipment);
                LoggerService.Debug($"{Resources.RecordOfShipmentCreated} {shipment.Shipment_Id}");

                int totalQuantity = 0;
                foreach (var item in shipmentItems)
                {
                    var product = db.Products.First(p => p.Article == item.Article);

                    db.ShipmentItems.Add(new ShipmentItems
                    {
                        Shipment_Id = shipment.Shipment_Id,
                        Product_Id = product.Product_Id,
                        FixedSalePrice = decimal.Parse(item.PriceSnapshot!),
                        Quantity = item.Quantity
                    });

                    product.StockQuantity -= item.Quantity;
                    totalQuantity += item.Quantity;

                    LoggerService.Debug($"{Resources.Product}: {item.Article}.\n{Resources.Quantity}: {item.Quantity}\n{Resources.NewStockQuantity} {product.StockQuantity}");
                }

                if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                {
                    LoggerService.Error(Resources.NotManagedToSaveShipment);

                    return;
                }

                LoggerService.Info($"{Resources.ShipmentSuccessfullyCreated} {shipment.Shipment_Id}, {Resources.Products} {totalQuantity}");

                MessageBox.Show($"{Resources.ShipmentSuccessfullyProcessed}\n{Resources.Date}: {DateOnly.FromDateTime(shipment.CreationDate)}",
                                Resources.TitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                LoggerService.Error(Resources.CriticalErrorWhenMakingShipment, ex);

                MessageBox.Show($"{Resources.ErrorSave}\n", Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            LoggerService.Info(Resources.ShipmentCreationCancelledByUser);

            Hide();
            var warehousemanPanel = new WarehousemanPanel(userLogin);
            warehousemanPanel.ShowDialog();
            Close();
        }

        private void UpdateButtonStates()
        {
            ButtonOfMakingShipment.Enabled = shipmentItems.Count > 0;
            ButtonOfProductDelete.Enabled = selectedShipmentItem != null;
        }
        private void ValidateFields(object? sender = null, EventArgs? e = null)
        {
            bool hasClient = ComboBoxOfClient.SelectedValue != null;
            bool hasProduct = ComboBoxOfProduct.SelectedValue != null;
            bool hasQuantity = NumericQuantity.Value > 0;

            ButtonOfAddProduct.Enabled = hasClient && hasProduct && hasQuantity;
            ButtonOfProductDelete.Enabled = selectedShipmentItem != null;

            LoggerService.Debug($"{Resources.Client}: {hasClient}\n" +
                                $"{Resources.Product}: {hasProduct}\n" +
                                $"{Resources.Quantity}: {hasQuantity}");
        }

        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfProduct.SelectedValue is string article)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product != null)
                {
                    TextBoxOfStockQuantity.Text = product.StockQuantity.ToString();
                    LoggerService.Debug($"{Resources.ProductIsChosen} {article}\n{Resources.InWhatAmount} {product.StockQuantity}");
                }
            }
            else
            {
                TextBoxOfStockQuantity.Text = Resources.StringO;
            }

            ValidateFields();
        }

        private void DataGridOfItems_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < shipmentItems.Count)
            {
                selectedShipmentItem = shipmentItems[e.RowIndex];

                LoggerService.Debug($"{Resources.ProductRowSelected}: {selectedShipmentItem.Article}");

                UpdateButtonStates();
            }
        }

        private void ButtonOfProductDelete_Click(object sender, EventArgs e)
        {
            if (selectedShipmentItem == null)
            {
                MessageBox.Show(Resources.SelectProductToDelete, Resources.TitleWarning,
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                shipmentItems.Remove(selectedShipmentItem);

                LoggerService.Info($"{Resources.ProductRemovedFromShipment}: {selectedShipmentItem.Article}");

                selectedShipmentItem = null;
                RefreshItemsGrid();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                LoggerService.Error(Resources.ProductRemoveFromShipmentError, ex);

                MessageBox.Show($"{Resources.ErrorProductDelete}\n{Resources.TryAgain}",
                               Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}