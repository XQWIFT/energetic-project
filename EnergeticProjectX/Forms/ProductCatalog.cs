using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
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
    public partial class ProductCatalog : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        private bool isWarehouseman = false;

        private string? selectedArticle;

        /// <summary>
        /// Конструктор для реализации формы каталога товаров.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public ProductCatalog(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUser();
            LoadProducts();
        }

        private void LoadUser()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user != null && user.UserRole == UserRole.Administrator)
            {
                ButtonOfAddCategory.Visible = true;
                ButtonOfChangeCaterogies.Visible = true;
                ButtonOfAddProduct.Visible = true;
                ButtonOfProductCard.Visible = true;
                PanelSearch.Visible = true;
                ButtonOfMakingShipment.Visible = false;
            }
            else if (user != null && user.UserRole == UserRole.Warehouseman)
            {
                isWarehouseman = true;
                ButtonOfAddCategory.Visible = false;
                ButtonOfChangeCaterogies.Visible = false;
                ButtonOfAddProduct.Visible = false;
                ButtonOfProductCard.Visible = false;
                ButtonOfMakingShipment.Visible = true;
                PanelSearch.Visible = true;
            }
            else
            {
                EH.ShowError(Resources.ErrorUserDataUpload, true);

                return;
            }
        }

        private void LoadProducts(string? searchText = null)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
                if (user == null)
                {
                    EH.ShowError(Resources.ErrorUserDataUpload, true);

                    return;
                }

                var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);
                if (currency == null)
                {
                    EH.ShowError(Resources.UserCurrencyNotFound, true);

                    return;
                }

                var query = db.Products.AsQueryable();

                query = query.Where(p => p.Status == ProductStatus.Active);

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var search = searchText.Trim();
                    query = query.Where(product => EF.Functions.ILike(product.Article, $"{search}%") ||
                                                   EF.Functions.ILike(product.Name, $"%{search}%"));
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
                    var priceInChosenCurrency = PCM.SetPriceToChosenCurrency(db, p.SalePrice, userLogin);
                    var formattedPrice = PCM.PriceToCorrectFormat(db, priceInChosenCurrency, userLogin);

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
            LoadProducts(textBoxSearch.Text.Trim());
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            if (isWarehouseman)
            {
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
            }
            else
            {
                var administratorPanel = new AdministratorPanel(userLogin);
                administratorPanel.ShowDialog();
            }
            Close();
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            Hide();
            var addProduct = new AddProduct(userLogin);
            addProduct.ShowDialog();
            Close();
        }

        private void ButtonOfAddCategory_Click(object sender, EventArgs e)
        {
            Hide();
            var addCategory = new AddCategory(userLogin);
            addCategory.ShowDialog();
            Close();
        }

        private void ButtonOfProductCard_Click(object sender, EventArgs e)
        {
            Hide();
            var editProduct = new EditProduct(userLogin, selectedArticle!);
            editProduct.ShowDialog();
            Close();
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            Hide();
            var makingShipment = new MakingShipment(userLogin);
            makingShipment.ShowDialog();
            Close();
        }

        private void ButtonOfChangeCaterogies_Click(object sender, EventArgs e)
        {
            Hide();
            var editCategories = new EditCategories(userLogin);
            editCategories.ShowDialog();
            Close();
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
