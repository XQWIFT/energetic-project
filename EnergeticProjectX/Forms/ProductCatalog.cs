using AddCategoryForm;
using AddProductForm;
using AdministratorPanelForm;
using EditCategoriesForm;
using EditProductForms;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Models;
using EnergeticProjectX.Properties;
using MakingShipmentForm;
using Microsoft.EntityFrameworkCore;
using WarehousemanPanelForm;

namespace ProductCatalogForm
{
    /// <summary>
    /// Форма для работы с каталогом товаров в виде таблицы
    /// </summary>
    public partial class ProductCatalog : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;
        private readonly bool isWarehouseman = false;

        private string? selectedArticle;

        /// <summary>
        /// Конструктор для работы с каталогом товаров
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public ProductCatalog(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            DataGridOfProducts.CellDoubleClick += DGVProductsCellDoubleClick!;
            DataGridOfProducts.CellMouseEnter += DGVProductsCellMouseEnter!;
            DataGridOfProducts.CellMouseClick += DGVProductsCellMouseClick!;
            DataGridOfProducts.SelectionChanged += DGVProductsSelectionChanged!;
            DataGridOfProducts.CellFormatting += DGVProductsCellFormatting!;

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
                MessageBox.Show($"{Resources.ErrorUserDataUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LoadProducts();
        }

        /// <summary>
        /// Загрузка товаров из базы данных
        /// </summary>
        /// <param name="searchText">Текст из поля для поиска товара</param>
        public void LoadProducts(string? searchText = null)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
                if (user == null)
                {
                    MessageBox.Show(Resources.ErrorUserDataUpload, Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);
                if (currency == null)
                {
                    MessageBox.Show($"{Resources.UserCurrencyNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var query = db.Products.AsQueryable();
                query = query.Where(p => p.Status == ProductStatus.Active);

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    string search = searchText.Trim();
                    query = query.Where(product => EF.Functions.ILike(product.Article, search) ||
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
                    var priceInChosenCurrency = PriceCurrencyManager.SetPriceToChosenCurrency(db, p.SalePrice, userLogin);
                    var formattedPrice = PriceCurrencyManager.PriceToCorrectFormat(db, priceInChosenCurrency, userLogin);

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
                    MessageBox.Show($"{Resources.HowMuchProductsUploaded} {products.Count}",
                                    Resources.TitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception )
            {
                MessageBox.Show($"{Resources.ErrorUploadData}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProductsCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || DataGridOfProducts.Rows[e.RowIndex].DataBoundItem is not ProductDisplayModel product)
                return;

            string columnName = DataGridOfProducts.Columns[e.ColumnIndex].Name;

            if (columnName == Resources.StockQuantityName)
                if (product.StockQuantity < 5)
                    e.CellStyle.BackColor = Color.LightCoral;

            if (columnName == Resources.DiscountDateName)
            {
                if (product.DiscountDate <= DateOnly.FromDateTime(DateTime.Today))
                    e.CellStyle.BackColor = Color.LightSalmon;
                else if (product.DiscountDate <= DateOnly.FromDateTime(DateTime.Today.AddDays(7)))
                    e.CellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void DGVProductsSelectionChanged(object sender, EventArgs e)
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

        private void DGVProductsCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = DataGridOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? Resources.Empty;

                var columnName = DataGridOfProducts.Columns[e.ColumnIndex].HeaderText;

                var tooltipText = $"{columnName}: {cellValue}";

                cell.ToolTipText = tooltipText;
            }
        }

        private void DGVProductsCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DGVProductsCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bindingSource.Current != null)
            {
                DataGridOfProducts.ClearSelection();
                DataGridOfProducts.Rows[e.RowIndex].Selected = true;

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
    }
}
