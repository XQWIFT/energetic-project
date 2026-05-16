using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для работы с каталогом товаров в виде таблицы.
    /// </summary>
    public partial class TableOfProducts : Form
    {
        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IClientService _clientService;

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        private bool isWarehouseman = false;

        private string? selectedArticle;

        /// <summary>
        /// Конструктор для реализации формы каталога товаров.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public TableOfProducts(string userLogin, IUserService userService, IProductService productService,
            IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _productService = productService;

            _clientService = clientService;

            LoadUser();

            LoadProducts();
        }

        private void LoadUser()
        {
            var user = EnsureUserActive();

            if (user == null)
                return;

            if (user.UserRole == UserRoles.Administrator)
            {
                ButtonOfAddCategory.Visible = true;
                ButtonOfChangeCaterogies.Visible = true;
                ButtonOfAddProduct.Visible = true;
                ButtonOfProductCard.Visible = true;
                PanelSearch.Visible = true;
                ButtonOfMakingShipment.Visible = false;
            }
            else if (user.UserRole == UserRoles.Warehouseman)
            {
                isWarehouseman = true;
                ButtonOfAddCategory.Visible = false;
                ButtonOfChangeCaterogies.Visible = false;
                ButtonOfAddProduct.Visible = false;
                ButtonOfProductCard.Visible = true;
                ButtonOfMakingShipment.Visible = true;
                PanelSearch.Visible = true;
            }
        }

        private void LoadProducts(string? searchText = null)
        {
            try
            {
                var user = EnsureUserActive();

                if (user == null)
                    return;

                var currency = _userService.FindUserChosenCurrency(user);
                if (currency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                var query = _productService.GetQueryProducts();

                query = query.Where(p => p.Status == Status.Active);

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var search = searchText.Trim();
                    query = query.Where(product => EF.Functions.ILike(product.Article, $"{search}%") ||
                                                   EF.Functions.ILike(product.Name, $"%{search}%") && product.Status == Status.Active);
                }

                var productsLoaded = query
                    .Select(p => new
                    {
                        p.Article,
                        p.Name,
                        CategoryName = p.Category!.Name,
                        p.StockQuantity,
                        UnitName = p.Category.Unit!.Name,
                        p.SalePrice,
                        p.DiscountDate
                    })
                    .ToList();

                var products = productsLoaded.Select(p =>
                {
                    var salePriceInChosenCurrency = _productService.SetPriceToChosenCurrency(p.SalePrice, userLogin);
                    var formattedPrice = _productService.PriceToCorrectFormat(salePriceInChosenCurrency, userLogin);

                    return new ProductDisplayModel
                    {
                        Article = p.Article,
                        Name = p.Name,
                        Category = p.CategoryName,
                        StockQuantity = p.StockQuantity,
                        Unit = p.UnitName,
                        SalePrice = formattedPrice,
                        DiscountDate = p.DiscountDate
                    };

                }).ToList();

                bindingSource.DataSource = products;
                DGVOfProducts.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                if (!isWarehouseman)
                {
                    EH.ShowInformation($"{Resources.HowMuchProductsUploaded} {products.Count}.");
                }
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void DGVProducts_SelectionChanged(object sender, EventArgs e)
        {
            var hasSelectedRow = DGVOfProducts.SelectedRows.Count > 0;

            ButtonOfProductCard.Enabled = hasSelectedRow;

            if (hasSelectedRow && bindingSource.Current is ProductDisplayModel selectedProduct)
            {
                selectedArticle = selectedProduct.Article;
            }
            else if (!hasSelectedRow)
            {
                selectedArticle = null;
            }
        }

        private void DGVProducts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DGVOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? string.Empty;

                var columnName = DGVOfProducts.Columns[e.ColumnIndex].HeaderText;

                var tooltipText = $"{columnName}: {cellValue}";

                cell.ToolTipText = tooltipText;
            }
        }

        private void DGVProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGVOfProducts.Rows.Count)
            {
                DGVOfProducts.ClearSelection();

                DGVOfProducts.Rows[e.RowIndex].Selected = true;

                DGVOfProducts.CurrentCell = DGVOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (bindingSource.Current is ProductDisplayModel selectedProduct)
                {
                    selectedArticle = selectedProduct.Article;
                }
            }
        }

        private void ButtonOfSearch_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            LoadProducts(TextBoxOfSearch.Text.Trim());
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            if (isWarehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin, _userService, _productService, _clientService);
                FH.OpenForm(this, warehousemanMainMenu);
            }
            else
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin, _userService, _clientService, _productService);
                FH.OpenForm(this, administratorMainMenu);
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            var addProduct = new AddProductForm(userLogin, _productService, _userService, _clientService);
            FH.OpenForm(this, addProduct);
        }

        private void ButtonOfAddCategory_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            var addCategory = new AddCategoryForm(userLogin, _productService, _userService, _clientService);
            FH.OpenForm(this, addCategory);
        }

        private void ButtonOfProductCard_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            var editProduct = new EditProductForm(userLogin, selectedArticle!, _userService, _productService, _clientService);
            FH.OpenForm(this, editProduct);
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            var makingShipment = new MakeShipmentForm(userLogin, _clientService, _userService, _productService);
            FH.OpenForm(this, makingShipment);
        }

        private void ButtonOfChangeCaterogies_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            var editCategories = new EditCategoryForm(userLogin, _productService, _userService, _clientService);
            FH.OpenForm(this, editCategories);
        }

        private User? EnsureUserActive()
        {
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return null;
            }
            else
                return user;
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
