using AddProductForm;
using AdministratorPanelForm;
using EditCategoriesForm;
using SelectProductDataForTable;
using ProductManagementForms;

namespace ProductCatalogForm
{
    public partial class ProductCatalog : Form
    {
        DBControl.ApplicationContextDB context = new();
        BindingSource bindingSource = new BindingSource();

        string userLogin;
        private string? selectedArticle;
        public ProductCatalog(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            dataGridOfProducts.MultiSelect = false;
            dataGridOfProducts.EnableHeadersVisualStyles = false;

            dataGridOfProducts.CellDoubleClick += DataGridOfProducts_CellDoubleClick!;
            dataGridOfProducts.CellMouseEnter += dataGridOfProducts_CellMouseEnter!;
            dataGridOfProducts.CellMouseClick += dataGridOfProducts_CellMouseClick!;
            dataGridOfProducts.SelectionChanged += DataGridOfProducts_SelectionChanged!;

            buttonOfProductCards.Enabled = false;

            LoadProducts();
        }

        private void DataGridOfProducts_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelectedRow = dataGridOfProducts.SelectedRows.Count > 0;

            buttonOfProductCards.Enabled = hasSelectedRow;

            if (hasSelectedRow && bindingSource.Current is ProductDisplayModel selectedProduct)
            {
                selectedArticle = selectedProduct.Article;
            }
            else if (!hasSelectedRow)
            {
                selectedArticle = null;
            }
        }

        private void dataGridOfProducts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string cellValue = cell.Value?.ToString() ?? "пусто";

                string columnName = dataGridOfProducts.Columns[e.ColumnIndex].HeaderText;

                string tooltipText = $"{columnName}: {cellValue}";

                cell.ToolTipText = tooltipText;
            }
        }

        private void dataGridOfProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridOfProducts.Rows.Count)
            {
                dataGridOfProducts.ClearSelection();

                dataGridOfProducts.Rows[e.RowIndex].Selected = true;

                dataGridOfProducts.CurrentCell = dataGridOfProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (bindingSource.Current is ProductDisplayModel selectedProduct)
                {
                    selectedArticle = selectedProduct.Article;
                }
            }
        }

        private void DataGridOfProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bindingSource.Current != null)
            {
                dataGridOfProducts.ClearSelection();
                dataGridOfProducts.Rows[e.RowIndex].Selected = true;
                var selectedProduct = bindingSource.Current as ProductDisplayModel;

                if (selectedProduct != null)
                {
                    selectedArticle = selectedProduct.Article;
                }
            }
        }

        public void LoadProducts()
        {
            try
            {
                bindingSource.DataSource = context.Products
                    .Select(u => new ProductDisplayModel
                    {
                        Article = u.Article,
                        Name = u.Name,
                        Category = u.Category,
                        Price = u.Price,
                        StockQuantity = u.StockQuantity,
                        Unit = u.Unit
                    })
                    .ToList();
                dataGridOfProducts.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                MessageBox.Show($"Загружено {context.Products.Count()} товаров",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOfMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdministratorPanel administratorPanel = new(userLogin);
            administratorPanel.ShowDialog();
            this.Close();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addProduct = new AddProduct(userLogin);
            addProduct.ShowDialog();
            this.Close();
        }

        private void buttonOfCategories_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editCategories = new EditCategories(userLogin);
            editCategories.ShowDialog();
            this.Close();
        }

        private void buttonOfProductCards_Click(object sender, EventArgs e)
        {
            this.Hide();
            var productManagement = new ProductManagement(userLogin, selectedArticle!);
            productManagement.ShowDialog();
            this.Close();
        }
    }
}
