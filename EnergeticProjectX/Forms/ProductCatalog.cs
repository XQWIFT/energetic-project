using AddProductForm;
using AdministratorPanelForm;
using EditCategoriesForm;
using EnergeticProjectX.Properties;
using MakingShipmentForm;
using AddCategoryForm;
using WarehousemanPanelForm;
using EnergeticProjectX.Models;
using EnergeticProjectX.Classes;
using EditProductForms;

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

        private readonly Dictionary<Guid, string> _unitMap = [];

        /// <summary>
        /// Конструктор для работы с каталогом товаров
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public ProductCatalog(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            DataGridOfProducts.CellFormatting += DGVProductsCellFormatting!;
            DataGridOfProducts.CellDoubleClick += DGVProductsCellDoubleClick!;
            DataGridOfProducts.CellMouseEnter += DGVProductsCellMouseEnter!;
            DataGridOfProducts.CellMouseClick += DGVProductsCellMouseClick!;
            DataGridOfProducts.SelectionChanged += DGVProductsSelectionChanged!;
            DataGridOfProducts.RowPrePaint += DGVProductsRowIsRed!;

            var logins = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (logins != null && logins.UserRole == Resources.UserRoleAdminEng)
            {
                ButtonOfAddCategory.Visible = true;
                ButtonOfChangeCaterogies.Visible = true;
                ButtonOfAddProduct.Visible = true;
                ButtonOfProductCard.Visible = true;
                panelSearch.Visible = true;
                ButtonOfMakingShipment.Visible = false;
            }
            else if (logins != null && logins.UserRole == Resources.UserRoleWarehousemanEng)
            {
                isWarehouseman = true;
                ButtonOfAddCategory.Visible = false;
                ButtonOfChangeCaterogies.Visible = false;
                ButtonOfAddProduct.Visible = false;
                ButtonOfProductCard.Visible = false;
                ButtonOfMakingShipment.Visible = true;
                panelSearch.Visible = true;
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
                var units = db.Units.ToList();
                _unitMap.Clear();

                foreach (var unit in units)
                    _unitMap[unit.Unit_Id] = unit.Value?.ToString() ?? "—";


                var query = db.Products.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    string lower = searchText.ToLower().Trim();
                    query = query.Where(product => product.Article.ToLower() == lower || product.Name.ToLower().Contains(lower) && product.Status == 1);
                }

                var products = query
                    .Select(u => new ProductDisplayModel
                    {
                        Article = u.Article,
                        Name = u.Name,
                        Category = u.Category.Name,
                        PurchasePrice = u.PurchasePrice,
                        StockQuantity = u.StockQuantity,
                        UnitId = u.Category.Unit_Id
                    })
                    .ToList();

                bindingSource.DataSource = products;
                DataGridOfProducts.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                if (!isWarehouseman)
                {
                    MessageBox.Show($"{Resources.HowMuchProductsUploaded}: {products.Count}",
                                    Resources.TitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.ErrorUploadData} {ex.Message}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProductsRowIsRed(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (DataGridOfProducts.Rows[e.RowIndex].DataBoundItem is ProductDisplayModel product)
            {
                DataGridOfProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    product.StockQuantity < 5 ? Color.LightCoral : Color.White;
            }
        }   

        private void DGVProductsSelectionChanged(object sender, EventArgs e)
        {
            bool hasSelectedRow = DataGridOfProducts.SelectedRows.Count > 0;

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

                string cellValue = cell.Value?.ToString() ?? Resources.Empty;

                string columnName = DataGridOfProducts.Columns[e.ColumnIndex].HeaderText;

                string tooltipText = $"{columnName}: {cellValue}";

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
                var selectedProduct = bindingSource.Current as ProductDisplayModel;

                if (selectedProduct != null)
                {
                    selectedArticle = selectedProduct.Article;
                }
            }
        }

        private void ButtonOfSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(textBoxSearch.Text.Trim());
        }

        private void DGVProductsCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            var column = DataGridOfProducts.Columns[e.ColumnIndex];
            if (column.Name == "Unit" && e.Value is Guid unitId)
            {
                e.Value = _unitMap.TryGetValue(unitId, out var unitText) ? unitText : "—";
                e.FormattingApplied = true;
            }
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
