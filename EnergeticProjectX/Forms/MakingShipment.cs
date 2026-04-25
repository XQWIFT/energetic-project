using EH = EnergeticProjectX.Classes.ErrorHandler;
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

        private readonly List<ShipmentItemRow> ShipmentItems = [];

        private ShipmentItemRow? selectedShipmentItem;

        /// <summary>
        /// Конструктор оформления отгрузки
        /// </summary>
        public MakingShipment(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoggerService.Info($"Форма оформления отгрузки открыта пользователем: {userLogin}");

            LoadClients();
            LoadProducts();

            UpdateButtonStates();

            DataGridOfItems.CellClick += DataGridOfItems_CellClick!;
            ComboBoxOfClient.SelectedIndexChanged += ValidateFields!;
            ComboBoxOfProduct.SelectedIndexChanged += ComboBoxProduct_SelectedIndexChanged!;
            NumericQuantity.ValueChanged += ValidateFields!;
            NumericQuantity.ValueChanged += NumericQuantity_ValueChanged!;

            TextBoxOfStockQuantity.Text = string.Empty;
        }

        private void LoadClients()
        {
            var clients = db.Clients.ToList();

            ComboBoxOfClient.DataSource = clients;
            ComboBoxOfClient.DisplayMember = Resources.NameEng;
            ComboBoxOfClient.ValueMember = Resources.Client_IdEng;

            ComboBoxOfClient.SelectedIndex = -1;
        }

        private void DataGridOfItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridOfItems.ClearSelection();
            DataGridOfItems.Rows[e.RowIndex].Selected = true;

            if (DataGridOfItems.Rows[e.RowIndex].DataBoundItem is ShipmentItemDisplayModel)
            {
                selectedShipmentItem = ShipmentItems[e.RowIndex];

                LoggerService.Debug($"Выбрана позиция отгрузки: {selectedShipmentItem.Article}");

                UpdateButtonStates();
            }
        }

        private void LoadProducts()
        {
            var products = db.Products.Where(p => p.Status == ProductStatus.Active && p.StockQuantity > 0).ToList();

            ComboBoxOfProduct.DataSource = products;
            ComboBoxOfProduct.DisplayMember = Resources.NameEng;
            ComboBoxOfProduct.ValueMember = Resources.ArticleEng;

            ComboBoxOfProduct.SelectedIndex = -1;
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfClient.SelectedValue == null || ComboBoxOfProduct.SelectedValue == null)
                {
                    EH.ShowWarning(Resources.FillRequiredFields);

                    return;
                }

                var article = ComboBoxOfProduct.SelectedValue.ToString()!;
                var product = db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null)
                {
                    LoggerService.Warning($"Товар {article} не найден в базе данных.");

                    return;
                }

                var quantity = (int)NumericQuantity.Value;

                var alreadyAdded = ShipmentItems.Where(i => i.Article == article).Sum(i => i.Quantity);

                if (alreadyAdded + quantity > product.StockQuantity)
                {
                    int available = product.StockQuantity - alreadyAdded;
                    LoggerService.Warning($"Попытка добавления товара {article}.\nКоличество: {quantity}\nДоступно: {available}");

                    EH.ShowWarning($"{Resources.NotEnoughProductInStock}\n{Resources.Available}: {available}");

                    return;
                }

                Guid clientId = Guid.Parse(ComboBoxOfClient.SelectedValue.ToString()!);
                var clientName = db.Clients.FirstOrDefault(c => c.Client_Id == clientId)?.Name ?? "—";

                var newItem = new ShipmentItemRow
                {
                    Article = article,
                    Name = product.Name,
                    Quantity = quantity,
                    ClientId = clientId,
                    ClientName = clientName,
                    PriceSnapshot = PriceCurrencyManager.SetPriceToChosenCurrency(db, product.SalePrice, userLogin)
                };

                ShipmentItems.Add(newItem);
                LoggerService.Info($"{Resources.Product} {article} {Resources.AddedToShipment}\n{Resources.Quantity}: {quantity}");

                RefreshItemsGrid();
                UpdateButtonStates();
                UpdateStockQuantityDisplay();

                NumericQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                LoggerService.Error("Ошибка добавления товара в отгрузку.", ex);

                EH.ShowError($"{Resources.ProductAddToShipmentError}\n{Resources.TryAgain}");

                return;
            }
        }


        private void RefreshItemsGrid()
        {
            DataGridOfItems.DataSource = null;

            var displayData = ShipmentItems
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
                var selectedIndex = ShipmentItems.IndexOf(selectedShipmentItem);
                if (selectedIndex >= 0 && selectedIndex < DataGridOfItems.Rows.Count)
                {
                    DataGridOfItems.ClearSelection();
                    DataGridOfItems.Rows[selectedIndex].Selected = true;
                }
            }

            LoggerService.Debug($"Обновлена таблица отгрузки, всего позиций: {ShipmentItems.Count}.");
        }

        private void ButtonMakeShipment_Click(object sender, EventArgs e)
        {
            if (ShipmentItems.Count == 0)
            {
                EH.ShowWarning(Resources.NoProductsInShipment);

                return;
            }

            var answer = EH.ShowConfirmation($"{Resources.SureWantToMakeShipment}\n\n{Resources.ProductNumber}: {ShipmentItems.Count}");

            if (answer != DialogResult.Yes)
            {
                LoggerService.Info("Создание отгрузки отменено пользователем.");

                return;
            }

            try
            {
                LoggerService.Info($"Начало оформления отгрузки, товаров: {ShipmentItems.Count}.");

                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
                if (user == null)
                {
                    LoggerService.Error($"{userLogin}: Пользователь не найден.");

                    EH.ShowError($"{Resources.UserNotFound}\n{Resources.TryAgain}");

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

                LoggerService.Debug($"Создана запись об отгрузке. ID отгрузки: {shipment.Shipment_Id}.");

                var totalQuantity = 0;
                foreach (var item in ShipmentItems)
                {
                    var product = db.Products.First(p => p.Article == item.Article);

                    db.ShipmentItems.Add(new ShipmentItems
                    {
                        Shipment_Id = shipment.Shipment_Id,
                        Product_Id = product.Product_Id,
                        FixedPurchasePrice = product.PurchasePrice,
                        FixedSalePrice = item.PriceSnapshot,
                        Quantity = item.Quantity
                    });

                    product.StockQuantity -= item.Quantity;
                    totalQuantity += item.Quantity;

                    LoggerService.Debug($"Товар: {item.Article}.\nКоличество: {item.Quantity}.\nНовый остаток: {product.StockQuantity}.");
                }

                if (EH.DBSaveChangesUniversalErrorCheck(db))
                {
                    LoggerService.Error("Не удалось сохранить отгрузку в базу данных.");

                    return;
                }

                LoggerService.Info($"Отгрузка успешно оформлена. ID отгрузки: {shipment.Shipment_Id}, Товаров: {totalQuantity}");

                EH.ShowInformation($"{Resources.ShipmentSuccessfullyProcessed}\n{Resources.Date}: {DateOnly.FromDateTime(DateTime.Now)}");

                Hide();
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                LoggerService.Error("Критическая ошибка при создании отгрузки.", ex);

                EH.ShowError($"{Resources.ErrorSaveShipment}\n{Resources.TryAgain}");

                return;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            LoggerService.Info("Создание отгрузки отменено пользователем.");

            Hide();
            var warehousemanPanel = new WarehousemanPanel(userLogin);
            warehousemanPanel.ShowDialog();
            Close();
        }

        private void UpdateButtonStates()
        {
            ButtonOfMakingShipment.Enabled = ShipmentItems.Count > 0;
            ButtonOfProductDelete.Enabled = selectedShipmentItem != null;
        }
        private void ValidateFields(object? sender = null, EventArgs? e = null)
        {
            var hasClient = ComboBoxOfClient.SelectedValue != null;
            var hasProduct = ComboBoxOfProduct.SelectedValue != null;
            var hasQuantity = NumericQuantity.Value > 0;

            ButtonOfAddProduct.Enabled = hasClient && hasProduct && hasQuantity;
            ButtonOfProductDelete.Enabled = selectedShipmentItem != null;

            LoggerService.Debug($"Получатель: {hasClient}.\n" +
                                $"Товар: {hasProduct}.\n" +
                                $"Количество: {hasQuantity}.");
        }

        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumericQuantity.Enabled = false;

            if (ComboBoxOfProduct.SelectedValue is string article)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product != null)
                {
                    int alreadyAdded = ShipmentItems.Where(i => i.Article == article).Sum(i => i.Quantity);

                    int available = product.StockQuantity - alreadyAdded;

                    TextBoxOfStockQuantity.Text = available.ToString();

                    NumericQuantity.Enabled = true;
                    NumericQuantity.Minimum = 1;
                    NumericQuantity.Value = 1;

                    LoggerService.Debug($"Выбран товар: {article}.\nКоличество:{product.StockQuantity}.\n" +
                                        $"Уже добавлено: {alreadyAdded}.\nДоступно: {available}.");
                }
            }
            else
            {
                TextBoxOfStockQuantity.Text = string.Empty;
            }

            ValidateFields();
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
                ShipmentItems.Remove(selectedShipmentItem);

                LoggerService.Info($"{Resources.ProductRemovedFromShipment}: {selectedShipmentItem.Article}");

                selectedShipmentItem = null;
                RefreshItemsGrid();
                UpdateButtonStates();
                UpdateStockQuantityDisplay();

                if (ComboBoxOfProduct.SelectedValue == null)
                {
                    NumericQuantity.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LoggerService.Error(Resources.ProductRemoveFromShipmentError, ex);

                MessageBox.Show($"{Resources.ErrorProductDelete}\n{Resources.TryAgain}",
                               Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    LoggerService.Debug($"Обновлён список для: {article}.\n" +
                                        $"Текущий остаток: {product.StockQuantity}.\n" +
                                        $"Добавлено: {alreadyAdded}.\n" +
                                        $"Доступно: {available}.");
                }
            }
        }

        private void NumericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfProduct.SelectedValue is string article &&
                int.TryParse(TextBoxOfStockQuantity.Text, out var available))
            {
                var alreadyAdded = ShipmentItems
                    .Where(i => i.Article == article)
                    .Sum(i => i.Quantity);

                var maxAllowed = available - alreadyAdded;

                if (NumericQuantity.Value > maxAllowed && maxAllowed > 0)
                {
                    MessageBox.Show($"{Resources.NotEnoughInStockQuantityRus}.\n{Resources.Available}: {maxAllowed}\n{Resources.TryToPointRus}: {NumericQuantity.Value}",
                                    Resources.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    NumericQuantity.Value = maxAllowed;
                }
            }

            ValidateFields();
        }
    }
}