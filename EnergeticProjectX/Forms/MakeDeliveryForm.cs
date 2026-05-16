using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using FH = EnergeticProjectX.Classes.FormHandler;
using TH = EnergeticProjectX.Classes.TimeHandler;
using CHK = EnergeticProjectX.Classes.Chekouts;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Models;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма оформления поставки товаров.
    /// </summary>
    public partial class MakeDeliveryForm : Form
    {
        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        private readonly List<DeliveryItemRow> DeliveryItems = [];

        private DeliveryItemRow? selectedDeliveryItem;

        /// <summary>
        /// Конструктор для реализации формы поставки.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public MakeDeliveryForm(string userLogin, IUserService userService,IProductService productService, IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            _userService = userService;
            _productService = productService;
            _clientService = clientService;

            LoadCategories();
            UpdateButtonStates();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _productService.GetCategories();

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
           
                var products = _productService.GetProductsByCategoryId(categoryId);

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
            try
            {
                if (ComboBoxOfProduct.SelectedValue is string article)
                {
                    var product = _productService.GetProductByArticle(article);
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
            catch (Exception ex)
            {
                EH.ShowError("Ошибка:" + ex);
            }
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
                    EH.ShowWarning(Resources.ChooseProductToAddInShipmentFirst);

                    return;
                }

                var product = _productService.GetProductByArticle(article);
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
                    int rowIndex = DeliveryItems.IndexOf(existingItem);

                    DeliveryItems[rowIndex].Quantity += quantity;

                    RefreshItemsGrid();
                    UpdateTotalCost();
                    UpdateButtonStates();

                    TextBoxOfQuantity.Text = "1";
                    TextBoxOfQuantity.Focus();
                    return;
                }

                var category = _productService.GetCategoryById(categoryId);
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
                    PurchasePrice = _productService.PriceToCorrectFormat( PCM.SetPriceToChosenCurrency(_userService, i.PurchasePrice, userLogin), userLogin),
                    Category = i.Category,
                    Unit = i.Unit,
                    TotalPrice = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, i.PurchasePrice * i.Quantity, userLogin), userLogin)
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

        private void DataGridOfItems_CellClick(object? sender, DataGridViewCellMouseEventArgs e)
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

            var totalCostFormatted = _productService.PriceToCorrectFormat(PCM.SetPriceToChosenCurrency(_userService, totalCost, userLogin), userLogin);

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
                        var product = _productService.GetProductByArticle(item.Article);

                        if (product != null)
                        {
                            if (DeliveryItems.All(i => i.Article != item.Article))
                            {
                                var category = _productService.GetCategoryById(product.CategoryId);

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
                EH.ShowWarning(Resources.NoProductsToAdd, true);

                return;
            }

            var answer = EH.ShowConfirmation(Resources.SureWantToMakeSupply);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    var user =_userService.EnsureUserActive(userLogin);

                    if (user == null)
                        return;

                    var delivery = new Delivery
                    {
                        DeliveryDate = DateTime.UtcNow,
                        User_Id = user.User_Id,
                        TotalAmount = DeliveryItems.Sum(i => i.PurchasePrice * i.Quantity)
                    };

                    _productService.AddDeliveries(delivery);

                    int totalQuantity = 0;
                    foreach (var item in DeliveryItems)
                    {
                        var product = _productService.GetProductByArticle(item.Article);

                        _productService.AddDeliveryItems(delivery.Delivery_Id, product.Product_Id, item.PurchasePrice, item.Quantity);
                        
                        product.StockQuantity += item.Quantity;
                        totalQuantity += item.Quantity;
                    }

                    if (_userService.DbSaveChangesErrorCheck())
                    {
                        EH.ShowError(Resources.ErrorUploadData, true);

                        return;
                    }

                    EH.ShowInformation($"{Resources.SupplySuccessfullyProcessed}\n\n" +
                                       $"{Resources.Date} {TH.UtcDateToLocalDateOnly(DateOnly.FromDateTime(delivery.DeliveryDate))}\n" +
                                       $"{Resources.ProductsQuantity} {totalQuantity}\n" +
                                       $"{Resources.SupplySum} {TextBoxOfPurchaseAll.Text}");

                    OpenMainMenu(userLogin);
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
            OpenMainMenu(userLogin);
        }

        private void OpenMainMenu(string userLogin)
        {
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
                return;

            if (user.UserRole == UserRoles.Administrator)
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin, _userService, _clientService, _productService);
                FH.OpenForm(this, administratorMainMenu);
            }
            else if (user.UserRole == UserRoles.Warehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin, _userService, _productService, _clientService);
                FH.OpenForm(this, warehousemanMainMenu);
            }
            else
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }
        }

        private void UpdateButtonStates()
        {
            ButtonOfMakingSupply.Enabled = DeliveryItems.Count > 0;

            ButtonOfDeleteProduct.Enabled = selectedDeliveryItem != null;
        }

        private void TextBoxOfQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            CHK.CheckOnlyNumber(e);
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