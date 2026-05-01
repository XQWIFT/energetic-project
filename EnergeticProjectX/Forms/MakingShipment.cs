using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для оформления отгрузки товара.
    /// </summary>
    public partial class MakingShipment : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private readonly List<ShipmentItemRow> ShipmentItems = [];

        private ShipmentItemRow? selectedShipmentItem;

        /// <summary>
        /// Конструктор для реализации формы оформления отгрузки товара.
        /// </summary>
        public MakingShipment(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadClients();
            LoadProducts();
            UpdateButtonStates();

            NumericQuantity.ValueChanged += ValidateFields!;
        }

        private void LoadClients()
        {
            var clients = db.Clients.ToList();

            ComboBoxOfClient.DataSource = clients;
            ComboBoxOfClient.DisplayMember = nameof(Client.Name);
            ComboBoxOfClient.ValueMember = nameof(Client.Client_Id);

            ComboBoxOfClient.SelectedIndex = -1;
        }

        private void LoadProducts()
        {
            var products = db.Products.Where(p => p.Status == ProductStatus.Active && p.StockQuantity > 0).ToList();

            ComboBoxOfProduct.DataSource = products;
            ComboBoxOfProduct.DisplayMember = nameof(Product.Name);
            ComboBoxOfProduct.ValueMember = nameof(Product.Article);

            ComboBoxOfProduct.SelectedIndex = -1;
            TextBoxOfStockQuantity.Text = string.Empty;
        }

        private void UpdateButtonStates()
        {
            ButtonOfMakingShipment.Enabled = ShipmentItems.Count > 0;
            ButtonOfProductDelete.Enabled = selectedShipmentItem != null;
        }

        private void DGVItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DGVOfItems.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? string.Empty;

                var columnName = DGVOfItems.Columns[e.ColumnIndex].HeaderText;

                var tooltipText = $"{columnName}: {cellValue}";

                cell.ToolTipText = tooltipText;
            }
        }

        private void DGVOfItems_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DGVOfItems.ClearSelection();
            DGVOfItems.Rows[e.RowIndex].Selected = true;

            if (DGVOfItems.Rows[e.RowIndex].DataBoundItem is ShipmentItemDisplayModel)
            {
                selectedShipmentItem = ShipmentItems[e.RowIndex];

                UpdateButtonStates();
            }
        }

        private void ComboBoxOfProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumericQuantity.Enabled = true;

            if (ComboBoxOfProduct.SelectedValue is string article)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product != null)
                {
                    var alreadyAdded = ShipmentItems.Where(i => i.Article == article).Sum(i => i.Quantity);

                    var available = product.StockQuantity - alreadyAdded;

                    TextBoxOfStockQuantity.Text = available.ToString();

                    NumericQuantity.Enabled = false;
                    NumericQuantity.Minimum = 1;
                    NumericQuantity.Value = 1;
                }
            }
            else
            {
                TextBoxOfStockQuantity.Text = string.Empty;
            }

            ValidateFields();
        }

        private void NumericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfProduct.SelectedValue is string article && int.TryParse(TextBoxOfStockQuantity.Text, out var available))
            {
                var alreadyAdded = ShipmentItems.Where(i => i.Article == article).Sum(i => i.Quantity);

                var maxAllowed = available - alreadyAdded;

                if (NumericQuantity.Value > maxAllowed && maxAllowed > 0)
                {
                    EH.ShowWarning($"{Resources.StockQuantityIsNotEnough}\n\n{Resources.AvailableInWarehouse} {maxAllowed}\n" +
                                   $"{Resources.TryToPoint} {NumericQuantity.Value}");

                    NumericQuantity.Value = maxAllowed;
                }
            }

            ValidateFields();
        }

        private void ValidateFields(object? sender = null, EventArgs? e = null)
        {
            var hasClient = ComboBoxOfClient.SelectedValue != null;
            var hasProduct = ComboBoxOfProduct.SelectedValue != null;
            var hasQuantity = NumericQuantity.Value > 0;

            ButtonOfAddProduct.Enabled = hasClient && hasProduct && hasQuantity;
            ButtonOfProductDelete.Enabled = selectedShipmentItem != null;
        }

        private void ButtonOfAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfClient.SelectedValue == null || ComboBoxOfProduct.SelectedValue == null)
                {
                    EH.ShowWarning(Resources.ChooseClientAndProductFirst, true);

                    return;
                }

                var article = ComboBoxOfProduct.SelectedValue.ToString();

                var product = db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null || article == null)
                {
                    EH.ShowError(Resources.ProductNotFound, true);

                    return;
                }

                var client = db.Clients.FirstOrDefault(c => c.Client_Id == (Guid)ComboBoxOfClient.SelectedValue);

                if (client == null)
                {
                    EH.ShowWarning(Resources.ClientsLoadError, true);

                    return;
                }

                var newItem = new ShipmentItemRow
                {
                    Article = article,
                    Name = product.Name,
                    Quantity = (int)NumericQuantity.Value,
                    ClientId = (Guid)ComboBoxOfClient.SelectedValue,
                    ClientName = client.Name,
                    PriceSnapshot = PCM.SetPriceToChosenCurrency(db, product.SalePrice, userLogin)
                };

                ShipmentItems.Add(newItem);

                DGVRefreshItems();
                UpdateButtonStates();
                UpdateStockQuantityDisplay();

                NumericQuantity.Value = 1;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ProductAddToShipmentError, true);

                return;
            }
        }

        private void UpdateStockQuantityDisplay()
        {
            if (ComboBoxOfProduct.SelectedValue is string article)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product != null)
                {
                    var alreadyAdded = ShipmentItems.Where(i => i.Article == article).Sum(i => i.Quantity);

                    var available = product.StockQuantity - alreadyAdded;

                    TextBoxOfStockQuantity.Text = available.ToString();
                }
            }
        }

        private void DGVRefreshItems()
        {
            DGVOfItems.DataSource = null;

            var displayData = ShipmentItems
                .Select((i, index) => new ShipmentItemDisplayModel
                {
                    Article = i.Article,
                    Name = i.Name,
                    Quantity = i.Quantity,
                    ClientName = i.ClientName
                })
                .ToList();

            DGVOfItems.DataSource = displayData;
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            if (ShipmentItems.Count == 0)
            {
                EH.ShowWarning(Resources.AddProductsInShipmentFirst);

                return;
            }

            var answer = EH.ShowConfirmation($"{Resources.SureWantToMakeShipment}\n\n{Resources.ProductsNumber} {ShipmentItems.Count}");

            if (answer == DialogResult.Yes)
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

                    if (user == null)
                    {
                        EH.ShowError(Resources.UserNotFound, true);

                        return;
                    }

                    var clientId = ShipmentItems.First().ClientId;

                    var shipment = new Shipment
                    {
                        CreationDate = DateTime.UtcNow,
                        Client_Id = clientId,
                        User_Id = user.User_Id
                    };

                    db.Shipments.Add(shipment);

                    var totalQuantity = 0;

                    foreach (var item in ShipmentItems)
                    {
                        var product = db.Products.First(p => p.Article == item.Article);

                        db.ShipmentItems.Add(new ShipmentItems
                        {
                            Shipment_Id = shipment.Shipment_Id,
                            Product_Id = product.Product_Id,
                            FixedPurchasePrice = PCM.SetPriceToDefaultCurrency(db, product.PurchasePrice, userLogin),
                            FixedSalePrice = PCM.SetPriceToDefaultCurrency(db, item.PriceSnapshot, userLogin),
                            Quantity = item.Quantity
                        });

                        product.StockQuantity -= item.Quantity;
                        totalQuantity += item.Quantity;
                    }

                    if (EH.DBSaveChangesUniversalErrorCheck(db))
                    {
                        EH.ShowError(Resources.SaveShipmentError, true);

                        return;
                    }

                    EH.ShowInformation($"{Resources.ShipmentSuccessfullyProcessed}\n\n" +
                                       $"{Resources.Date}: {TH.UtcToLocalDateTime(shipment.CreationDate)}");

                    OpenWarehousemanPanel();
                }
                catch (Exception)
                {
                    EH.ShowError(Resources.SaveShipmentError, true);

                    return;
                }
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            OpenWarehousemanPanel();
        }

        private void OpenWarehousemanPanel()
        {
            Hide();
            var warehousemanPanel = new WarehousemanPanel(userLogin);
            warehousemanPanel.ShowDialog();
            Close();
        }

        private void ButtonOfProductDelete_Click(object sender, EventArgs e)
        {
            if (selectedShipmentItem == null)
            {
                EH.ShowAlert(Resources.SelectProductToDeleteFirst);

                return;
            }

            try
            {
                ShipmentItems.Remove(selectedShipmentItem);

                selectedShipmentItem = null;
                DGVRefreshItems();
                UpdateButtonStates();
                UpdateStockQuantityDisplay();

                if (ComboBoxOfProduct.SelectedValue == null)
                {
                    NumericQuantity.Enabled = false;
                }
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorProductDeleteFromShipment, true);

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