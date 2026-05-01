using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма оформления поставки товаров.
    /// </summary>
    public partial class MakingSupply : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private readonly List<DeliveryItemRow> DeliveryItems = [];

        private DeliveryItemRow? selectedDeliveryItem;

        /// <summary>
        /// Конструктор для реализации формы поставки.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public MakingSupply(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadCategories();
            UpdateButtonStates();

            ComboBoxOfCategory.SelectedIndexChanged += ComboBoxOfCategory_SelectedIndexChanged;
            ComboBoxOfProduct.SelectedIndexChanged += ComboBoxOfProduct_SelectedIndexChanged;
            TextBoxOfQuantity.TextChanged += ValidateFields;
            DataGridViewOfSupply.CellClick += DataGridOfItems_CellClick;
            ButtonOfAddProduct.Click += ButtonOfAddProduct_Click;
            ButtonOfUploadingByFile.Click += ButtonOfLoadFromFile_Click;
            ButtonOfDeleteProduct.Click += ButtonOfProductDelete_Click;
            ButtonOfMakingSupply.Click += ButtonOfMakingDelivery_Click;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
        }

        private void LoadCategories()
        {
            try
            {
                var categories = db.Categories.Include(c => c.Unit).Where(c => c.Status == CategoryStatus.Active).ToList();

                ComboBoxOfCategory.DataSource = categories;
                ComboBoxOfCategory.DisplayMember = nameof(Category.Name);
                ComboBoxOfCategory.ValueMember = nameof(Category.Category_Id);
                ComboBoxOfCategory.SelectedIndex = -1;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void LoadProducts()
        {
            try
            {
                if (ComboBoxOfCategory.SelectedValue is not Guid categoryId)
                {
                    ComboBoxOfProduct.DataSource = null;
                    return;
                }

                var products = db.Products.Where(p => p.CategoryId == categoryId && p.Status == ProductStatus.Active).ToList();

                ComboBoxOfProduct.DataSource = products;
                ComboBoxOfProduct.DisplayMember = nameof(Product.Name);
                ComboBoxOfProduct.ValueMember = nameof(Product.Article);
                ComboBoxOfProduct.SelectedIndex = -1;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void ComboBoxOfCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedValue == null)
            {
                TextBoxOfUnit.Text = string.Empty;

                return;
            }

            if (ComboBoxOfCategory.SelectedValue is Guid categoryId)
            {
                var category = (ComboBoxOfCategory.DataSource as List<Category>)?.FirstOrDefault(c => c.Category_Id == categoryId);

                if (category != null)
                {
                    var unit = category.Unit?.Name ?? string.Empty;
                    TextBoxOfUnit.Text = unit;
                }
                else
                {
                    TextBoxOfUnit.Text = string.Empty;
                }

                ComboBoxOfProduct.Enabled = true;
                LoadProducts();
            }
            else
            {
                ComboBoxOfProduct.Enabled = false;
                ComboBoxOfProduct.DataSource = null;
                TextBoxOfUnit.Text = string.Empty;
            }

            TextBoxOfQuantity.Text = "1";
            ValidateFields();
        }

        private void ComboBoxOfProduct_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (ComboBoxOfProduct.SelectedValue is string article)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product != null)
                {
                    TextBoxOfStockQuantity.Text = product.StockQuantity.ToString();
                }
            }
            else
            {
                TextBoxOfStockQuantity.Text = string.Empty;
            }

            ValidateFields();
        }

        private void ValidateFields(object? sender = null, EventArgs? e = null)
        {
            var hasCategory = ComboBoxOfCategory.SelectedValue != null;
            var hasProduct = ComboBoxOfProduct.SelectedValue != null;
            var hasQuantity = int.TryParse(TextBoxOfQuantity.Text, out var qty) && qty > 0;

            ButtonOfAddProduct.Enabled = hasCategory && hasProduct && hasQuantity;
            ButtonOfDeleteProduct.Enabled = selectedDeliveryItem != null;
        }

        private void ButtonOfAddProduct_Click(object? sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfCategory.SelectedValue is not Guid categoryId || ComboBoxOfProduct.SelectedValue is not string article)
                {
                    EH.ShowWarning(Resources.ChooseClientAndProductFirst);

                    return;
                }

                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product == null)
                {
                    EH.ShowError(Resources.ProductNotFound, true);

                    return;
                }

                if (!int.TryParse(TextBoxOfQuantity.Text, out var quantity) || quantity <= 0)
                {
                    EH.ShowWarning(Resources.InputCorrectQuantity);

                    return;
                }

                var purchasePrice = product.PurchasePrice;

                var existingItem = DeliveryItems.FirstOrDefault(i => i.Article == article);
                if (existingItem != null)
                {
                    EH.ShowWarning($"{Resources.Product} {product.Name} {Resources.AlreadyInSupply}.");

                    return;
                }

                var category = db.Categories.FirstOrDefault(c => c.Category_Id == categoryId);
                var unit = category?.Unit?.Name ?? "—";

                var newItem = new DeliveryItemRow
                {
                    Article = article,
                    Name = product.Name,
                    Quantity = quantity,
                    PurchasePrice = purchasePrice,
                    Category = category?.Name ?? "—",
                    Unit = unit
                };

                DeliveryItems.Add(newItem);

                RefreshItemsGrid();
                UpdateTotalCost();
                UpdateButtonStates();

                TextBoxOfQuantity.Text = "1";
                TextBoxOfQuantity.Focus();
            }
            catch (Exception)
            {
                EH.ShowError(Resources.AddProductError, true);

                return;
            }
        }

        private void RefreshItemsGrid()
        {
            DataGridViewOfSupply.DataSource = null;

            var displayData = DeliveryItems
                .Select((i, index) => new DeliveryItemDisplayModel
                {
                    Index = index,
                    Name = i.Name,
                    Quantity = i.Quantity,
                    PurchasePrice = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, i.PurchasePrice, userLogin), userLogin),
                    Category = i.Category,
                    Unit = i.Unit,
                    TotalPrice = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, i.PurchasePrice * i.Quantity, userLogin), userLogin)
                })
                .ToList();

            DataGridViewOfSupply.DataSource = displayData;

            if (DataGridViewOfSupply.Rows.Count > 0)
            {
                var lastIndex = DataGridViewOfSupply.Rows.Count - 1;

                DataGridViewOfSupply.ClearSelection();
                DataGridViewOfSupply.Rows[lastIndex].Selected = true;
            }
        }

        private void DataGridOfItems_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DeliveryItems.Count)
            {
                selectedDeliveryItem = DeliveryItems[e.RowIndex];

                UpdateButtonStates();
            }
        }

        private void ButtonOfProductDelete_Click(object? sender, EventArgs e)
        {
            if (selectedDeliveryItem == null)
            {
                EH.ShowWarning(Resources.SelectProductToDeleteFirst);

                return;
            }

            try
            {
                DeliveryItems.Remove(selectedDeliveryItem);

                selectedDeliveryItem = null;
                RefreshItemsGrid();
                UpdateTotalCost();
                UpdateButtonStates();
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorProductDeleteFromShipment, true);
            }
        }

        private void UpdateTotalCost()
        {
            var totalCost = DeliveryItems.Sum(i => i.PurchasePrice * i.Quantity);

            var totalCostFormatted = PCM.PriceToCorrectFormat(db, PCM.SetPriceToChosenCurrency(db, totalCost, userLogin), userLogin);

            TextBoxOfPurchaseAll.Text = totalCostFormatted;
        }

        private void ButtonOfLoadFromFile_Click(object? sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON files|*.json|All files|*.*",
                    Title = "Выберите JSON файл с товарами",
                    CheckFileExists = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var json = File.ReadAllText(openFileDialog.FileName);

                    var items = JsonSerializer.Deserialize<List<DeliveryItemRow>>(json);

                    if (items == null || items.Count == 0)
                    {
                        EH.ShowWarning(Resources.FileForSupplyNoProducts);

                        return;
                    }

                    int addedCount = 0;

                    foreach (var item in items)
                    {
                        var product = db.Products.FirstOrDefault(p => p.Article == item.Article);

                        if (product != null)
                        {
                            if (DeliveryItems.All(i => i.Article != item.Article))
                            {
                                var category = db.Categories.FirstOrDefault(c => c.Category_Id == product.CategoryId);

                                item.Category = category?.Name ?? "—";
                                item.Unit = category?.Unit?.Name ?? "—";
                                item.PurchasePrice = product.PurchasePrice;

                                DeliveryItems.Add(item);
                                addedCount++;
                            }
                        }
                    }

                    if (addedCount > 0)
                    {
                        RefreshItemsGrid();
                        UpdateTotalCost();
                        UpdateButtonStates();

                        EH.ShowInformation($"{Resources.Loaded} {addedCount} {Resources.ProductsFromFile}!");
                    }
                    else
                    {
                        EH.ShowWarning(Resources.NoProductsLoaded);

                        return;
                    }
                }
            }
            catch (JsonException)
            {
                EH.ShowError(Resources.ErrorReadingFile, true);

                return;
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void ButtonOfMakingDelivery_Click(object? sender, EventArgs e)
        {
            if (DeliveryItems.Count == 0)
            {
                EH.ShowWarning($"{Resources.NoProductsToAdd}!");

                return;
            }

            var answer = EH.ShowConfirmation($"{Resources.SureWantToMakeSupply}?");
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

                    var delivery = new Delivery
                    {
                        DeliveryDate = DateTime.UtcNow,
                        User_Id = user.User_Id,
                        TotalAmount = DeliveryItems.Sum(i => i.PurchasePrice * i.Quantity)
                    };

                    db.Deliveries.Add(delivery);

                    int totalQuantity = 0;
                    foreach (var item in DeliveryItems)
                    {
                        var product = db.Products.First(p => p.Article == item.Article);

                        db.DeliveryItems.Add(new DeliveryItems
                        {
                            Delivery_Id = delivery.Delivery_Id,
                            Product_Id = product.Product_Id,
                            PurchasePrice = item.PurchasePrice,
                            Quantity = item.Quantity
                        });

                        product.StockQuantity += item.Quantity;
                        totalQuantity += item.Quantity;
                    }

                    if (EH.DBSaveChangesUniversalErrorCheck(db))
                    {
                        EH.ShowError(Resources.ErrorUploadData, true);

                        return;
                    }

                    EH.ShowInformation($"{Resources.SupplySuccessfullyProcessed}\n\n" +
                                       $"{Resources.Date}: {DateOnly.FromDateTime(delivery.DeliveryDate)}\n" +
                                       $"{Resources.ProductsQuantity}: {totalQuantity}\n" +
                                       $"{Resources.Sum}: {TextBoxOfPurchaseAll.Text}");

ReturnToMainMenu(userLogin);
                }
                catch (Exception)
                {
                    EH.ShowError(Resources.ErrorSave, true);

                    return;
                }
            }
        }

        private void ButtonOfCancel_Click(object? sender, EventArgs e)
        {
            ReturnToMainMenu(userLogin);
        }

        private void ReturnToMainMenu(string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user != null && user.UserRole == UserRole.Administrator)
            {
                var administratorPanel = new AdministratorPanel(userLogin);
                administratorPanel.ShowDialog();
            }
            if (user != null && user.UserRole == UserRole.Warehouseman)
            {
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
            }
            else
            {
                EH.ShowError(Resources.UserNotFound, true);
            }
        }

        private void UpdateButtonStates()
        {
            ButtonOfMakingSupply.Enabled = DeliveryItems.Count > 0;

            ButtonOfDeleteProduct.Enabled = selectedDeliveryItem != null;
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