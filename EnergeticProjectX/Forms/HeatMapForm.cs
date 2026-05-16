using FH = EnergeticProjectX.Classes.FormHandler;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;

namespace EnergeticProjectX.Forms
{
    public partial class HeatMapForm : Form
    {
        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IClientService _clientService;

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы каталога товаров.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public HeatMapForm(string userLogin, IUserService userService, IProductService productService,
            IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _productService = productService;

            _clientService = clientService;

            LoadProducts();

            ActiveControl = DGVOfProducts;
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

                if (_userService.FindByLogin(userLogin).UserRole == UserRoles.Administrator)
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
            }
        }

        private void DGVProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || DGVOfProducts.Rows[e.RowIndex].DataBoundItem is not ProductDisplayModel product)
                return;

            var columnName = DGVOfProducts.Columns[e.ColumnIndex].Name;

            if (columnName == nameof(product.StockQuantity))
                if (product.StockQuantity < 5)
                    e.CellStyle.BackColor = Color.LightCoral;

            if (columnName == nameof(product.DiscountDate))
            {
                if (TH.UtcDateToLocalDateOnly(product.DiscountDate) <= DateOnly.FromDateTime(DateTime.Today))
                    e.CellStyle.BackColor = Color.LightSalmon;
                else if (TH.UtcDateToLocalDateOnly(product.DiscountDate) <= DateOnly.FromDateTime(DateTime.Today.AddDays(7)))
                    e.CellStyle.BackColor = Color.LightGoldenrodYellow;
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

            if (_userService.FindByLogin(userLogin).UserRole == UserRoles.Warehouseman)
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

        private void ButtonOfTableOfProducts_Click(object sender, EventArgs e)
        {
            if (EnsureUserActive() == null)
                return;

            var productCatalog = new TableOfProducts(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, productCatalog);
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
