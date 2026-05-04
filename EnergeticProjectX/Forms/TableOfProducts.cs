using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для работы с каталогом товаров в виде таблицы.
    /// </summary>
    public partial class TableOfProducts : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        private bool isWarehouseman = false;

        private string? selectedArticle;

        /// <summary>
        /// Конструктор для реализации формы каталога товаров.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public TableOfProducts(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUser();

            LoadProducts();
        }

        private void LoadUser()
        {
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.ErrorUserDataUpload);

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
                ButtonOfProductCard.Visible = false;
                ButtonOfMakingShipment.Visible = true;
                PanelSearch.Visible = true;
            }
        }

        private void LoadProducts(string? searchText = null)
        {
            try
            {
                var user = EH.EnsureUserActive(this, Db, userLogin, Resources.ErrorUserDataUpload);

                if (user == null)
                    return;

                var currency = Db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);
                if (currency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                var query = Db.Products.AsQueryable();

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
                    var salePriceInChosenCurrency = PCM.SetPriceToChosenCurrency(Db, p.SalePrice, userLogin);
                    var formattedPrice = PCM.PriceToCorrectFormat(Db, salePriceInChosenCurrency, userLogin);

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
                DataGridOfProducts.DataSource = bindingSource;
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

        private void DGVProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || DataGridOfProducts.Rows[e.RowIndex].DataBoundItem is not ProductDisplayModel product)
                return;

            var columnName = DataGridOfProducts.Columns[e.ColumnIndex].Name;

            if (columnName == nameof(Product.StockQuantity))
                if (product.StockQuantity < 5)
                    e.CellStyle.BackColor = Color.LightCoral;

            if (columnName == nameof(Product.DiscountDate))
            {
                if (TH.UtcDateToLocalDateOnly(product.DiscountDate) <= DateOnly.FromDateTime(DateTime.Today))
                    e.CellStyle.BackColor = Color.LightSalmon;
                else if (TH.UtcDateToLocalDateOnly(product.DiscountDate) <= DateOnly.FromDateTime(DateTime.Today.AddDays(7)))
                    e.CellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void DGVProducts_SelectionChanged(object sender, EventArgs e)
        {
            var hasSelectedRow = DataGridOfProducts.SelectedRows.Count > 0;

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
                var cell = DataGridOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? string.Empty;

                var columnName = DataGridOfProducts.Columns[e.ColumnIndex].HeaderText;

                var tooltipText = $"{columnName}: {cellValue}";

                cell.ToolTipText = tooltipText;
            }
        }

        private void DGVProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridOfProducts.Rows.Count)
            {
                DataGridOfProducts.ClearSelection();

                DataGridOfProducts.Rows[e.RowIndex].Selected = true;

                DataGridOfProducts.CurrentCell = DataGridOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (bindingSource.Current is ProductDisplayModel selectedProduct)
                {
                    selectedArticle = selectedProduct.Article;
                }
            }
        }

        private void ButtonOfSearch_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            LoadProducts(textBoxSearch.Text.Trim());
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (isWarehouseman)
            {
                var warehousemanMainMenu = new WarehousemanMainMenu(userLogin);
                FH.OpenForm(this, warehousemanMainMenu);
            }
            else
            {
                var administratorMainMenu = new AdministratorMainMenu(userLogin);
                FH.OpenForm(this, administratorMainMenu);
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var addProduct = new AddProductForm(userLogin);
            FH.OpenForm(this, addProduct);
        }

        private void ButtonOfAddCategory_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var addCategory = new AddCategoryForm(userLogin);
            FH.OpenForm(this, addCategory);
        }

        private void ButtonOfProductCard_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var editProduct = new EditProductForm(userLogin, selectedArticle!);
            FH.OpenForm(this, editProduct);
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var makingShipment = new MakeShipmentForm(userLogin);
            FH.OpenForm(this, makingShipment);
        }

        private void ButtonOfChangeCaterogies_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var editCategories = new EditCategoryForm(userLogin);
            FH.OpenForm(this, editCategories);
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
