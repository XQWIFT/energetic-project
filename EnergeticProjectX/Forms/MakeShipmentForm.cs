using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
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
    public partial class MakeShipmentForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        private readonly List<ShipmentItemRow> ShipmentItems = [];

        private ShipmentItemRow? selectedShipmentItem;

        /// <summary>
        /// Конструктор для реализации формы оформления отгрузки товара.
        /// </summary>
        public MakeShipmentForm(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadClients();
            LoadProducts();
        }

        private void LoadClients()
        {
            var clients = Db.Clients.Where(c => c.Status == Status.Active).ToList();

            ComboBoxOfClient.DataSource = clients;
            ComboBoxOfClient.DisplayMember = nameof(Client.Name);
            ComboBoxOfClient.ValueMember = nameof(Client.Client_Id);

            ComboBoxOfClient.SelectedIndex = -1;
        }

        private void LoadProducts()
        {
            var products = Db.Products.Where(p => p.Status == Status.Active && p.StockQuantity > 0).ToList();

            ComboBoxOfProduct.DataSource = products;
            ComboBoxOfProduct.DisplayMember = nameof(Product.Name);
            ComboBoxOfProduct.ValueMember = nameof(Product.Article);

            ComboBoxOfProduct.SelectedIndex = -1;
            TextBoxOfStockQuantity.Text = string.Empty;
        }

        private void UpdateButtonStates()
        {
            ButtonOfMakingShipment.Enabled = ShipmentItems.Count > 0 && ComboBoxOfClient.SelectedIndex != -1;
            ButtonOfAddProduct.Enabled = ComboBoxOfProduct.SelectedIndex != -1;
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

        private void ComboBoxOfProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxOfStockQuantity.Text = string.Empty;

            NumericQuantity.Maximum = 999999;
            NumericQuantity.Minimum = 1;
            NumericQuantity.Value = 1;
            NumericQuantity.Enabled = true; 

            if (ComboBoxOfProduct.SelectedValue is not string article)
            {
                NumericQuantity.Enabled = false;
                return;
            }

            var product = Db.Products.FirstOrDefault(p => p.Article == article);
            if (product == null)
                return;

            var existingItem = ShipmentItems.FirstOrDefault(i => i.Article == article);
            var alreadyAdded = existingItem?.Quantity ?? 0;

            var available = product.StockQuantity - alreadyAdded;

            TextBoxOfStockQuantity.Text = available.ToString();

            if (available <= 0)
            {
                NumericQuantity.Enabled = false;
            }
            else
            {
                NumericQuantity.Enabled = true;
                NumericQuantity.Maximum = available;
                NumericQuantity.Minimum = 1;
                NumericQuantity.Value = 1;
            }

            UpdateButtonStates();
        }

        private void NumericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfProduct.SelectedValue is not string article)
                return;

            var product = Db.Products.FirstOrDefault(p => p.Article == article);
            if (product == null)
                return;

            var existingItem = ShipmentItems.FirstOrDefault(i => i.Article == article);
            var alreadyAdded = existingItem?.Quantity ?? 0;
            var available = product.StockQuantity - alreadyAdded;

            if (NumericQuantity.Value > available && available > 0)
            {
                EH.ShowWarning($"{Resources.StockQuantityIsNotEnough}\n\n" +
                               $"{Resources.AvailableInWarehouse} {available}");
                NumericQuantity.Value = available;
            }
        }

        private void NumericQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (ComboBoxOfProduct.SelectedValue == null)
            {
                e.Handled = true;
                EH.ShowAlert(Resources.ChooseProductFirst);
                return;
            }
        }

        private void UpdateStockQuantityDisplay()
        {
            if (ComboBoxOfProduct.SelectedValue is not string article)
                return;

            var product = Db.Products.FirstOrDefault(p => p.Article == article);
            if (product == null)
                return;

            var existingItem = ShipmentItems.FirstOrDefault(i => i.Article == article);
            var alreadyAdded = existingItem?.Quantity ?? 0;

            var available = product.StockQuantity - alreadyAdded;
            TextBoxOfStockQuantity.Text = available.ToString();

            if (available > 0)
            {
                NumericQuantity.Maximum = available;
                NumericQuantity.Enabled = true;
            }
            else
            {
                NumericQuantity.Enabled = false;
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
                })
                .ToList();

            DGVOfItems.DataSource = displayData;
        }

        private void ButtonOfAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfProduct.SelectedValue == null)
                {
                    EH.ShowWarning(Resources.ChooseProductToAddInShipmentFirst, true);

                    return;
                }

                var article = ComboBoxOfProduct.SelectedValue.ToString();

                var product = Db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null || article == null)
                {
                    EH.ShowError(Resources.ProductNotFound, true);

                    return;
                }

                var quantityToAdd = (int)NumericQuantity.Value;

                var existingItem = ShipmentItems.FirstOrDefault(i => i.Article == article);

                if (existingItem != null)
                {
                    var totalQuantity = existingItem.Quantity + quantityToAdd;

                    var alreadyAdded = ShipmentItems.Where(i => i.Article == article).Sum(i => i.Quantity);
                    var available = product.StockQuantity - alreadyAdded;

                    if (totalQuantity > product.StockQuantity)
                    {
                        EH.ShowWarning($"{Resources.StockQuantityIsNotEnough}\n\n" +
                                       $"{Resources.AvailableInWarehouse} {available}\n" +
                                       $"{Resources.TryToPoint} {product.StockQuantity}");
                        return;
                    }

                    existingItem.Quantity = totalQuantity;
                }
                else
                {
                    var newItem = new ShipmentItemRow
                    {
                        Article = article,
                        Name = product.Name,
                        Quantity = quantityToAdd,
                        PriceSnapshot = PCM.SetPriceToChosenCurrency(Db, product.SalePrice, userLogin)
                    };

                    ShipmentItems.Add(newItem);
                }

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

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

            if (user == null)
                return;

            if (ShipmentItems.Count == 0)
            {
                EH.ShowWarning(Resources.AddProductsInShipmentFirst);

                return;
            }

            if (ComboBoxOfClient.SelectedValue == null)
            {
                EH.ShowWarning(Resources.ChooseClientToMakeShipmentFirst);

                return;
            }

            var client = Db.Clients.FirstOrDefault(c => c.Client_Id == (Guid)ComboBoxOfClient.SelectedValue);

            if (client == null)
            {
                EH.ShowWarning(Resources.ClientsLoadError, true);

                return;
            }

            var answer = EH.ShowConfirmation($"{Resources.SureWantToMakeShipment}\n\n{Resources.ProductsNumber} {ShipmentItems.Count}");

            if (answer == DialogResult.Yes)
            {
                try
                {
                    var shipment = new Shipment
                    {
                        CreationDate = DateTime.UtcNow,
                        Client_Id = client.Client_Id,
                        User_Id = user.User_Id
                    };

                    Db.Shipments.Add(shipment);

                    var totalQuantity = 0;

                    foreach (var item in ShipmentItems)
                    {
                        var product = Db.Products.First(p => p.Article == item.Article);

                        Db.ShipmentItems.Add(new ShipmentItems
                        {
                            Shipment_Id = shipment.Shipment_Id,
                            Product_Id = product.Product_Id,
                            FixedPurchasePrice = product.PurchasePrice,
                            FixedSalePrice = product.SalePrice,
                            Quantity = item.Quantity
                        });

                        product.StockQuantity -= item.Quantity;
                        totalQuantity += item.Quantity;
                    }

                    if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    {
                        EH.ShowError(Resources.SaveShipmentError, true);

                        return;
                    }

                    EH.ShowInformation($"{Resources.ShipmentSuccessfullyProcessed}\n\n" +
                                       $"{Resources.Date}: {TH.UtcToLocalDateTime(shipment.CreationDate)}");

                    OpenMainMenu();
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
            OpenMainMenu();
        }

        private void OpenMainMenu()
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var warehousemanMainMenu = new WarehousemanMainMenu(userLogin);
            FH.OpenForm(this, warehousemanMainMenu);

        }

        private void ButtonOfProductDelete_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

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