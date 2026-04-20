using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using ProductCatalogForm;

namespace EditProductForms
{
    /// <summary>
    /// Форма изменения товаров
    /// </summary>
    public partial class EditProduct : Form
    {
        readonly ApplicationContextDB db = new();

        readonly string userLogin;
        readonly string article;
        private Product currentProduct;

        /// <summary>
        /// Конструктор изменения товаров
        /// </summary>
        public EditProduct(string userLogin, string article)
        {
            InitializeComponent();
            this.userLogin = userLogin;
            this.article = article;

            LoadProductData();

            textBoxOfName.TextChanged += isTextChanged!;
            comboBoxOfCategory.TextChanged += isTextChanged!;
            textBoxOfPrice.TextChanged += isTextChanged!;
            textBoxOfUnit.TextChanged += isTextChanged!;
            comboBoxOfCategory.SelectedIndexChanged += isTextChanged!;

            LoadCategories();

            buttonOfSaveChanges.Enabled = false;
        }

        /// <summary>
        /// Загрузка товаров из базы данных
        /// </summary>
        public void LoadProductData()
        {
            try
            {
                currentProduct = db.Products.FirstOrDefault(p => p.Article == article)!;

                if (currentProduct != null)
                {
                    textBoxOfName.Text = currentProduct.Name;
                    textBoxOfPrice.Text = currentProduct.PurchasePrice.ToString();
                }
                else
                {
                    MessageBox.Show(Resources.ProductNotFound, Resources.TitleError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.ErrorUploadData} {ex.Message}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузка категорий из базы данных
        /// </summary>
        public void LoadCategories()
        {
            try
            {
                comboBoxOfCategory.SelectedIndexChanged -= isComboBoxOfCategoryChanged!;

                var categories = db.Categories.Where(u => u.Status == 1).ToList();

                /// ???
                if (categories != null && categories.Any())
                {
                    comboBoxOfCategory.DataSource = categories;
                    comboBoxOfCategory.DisplayMember = Resources.CategoryDisplayMember;
                    comboBoxOfCategory.ValueMember = Resources.CategoryValueMember;

                    if (currentProduct != null)
                    {
                        comboBoxOfCategory.SelectedValue = currentProduct.CategoryId;
                        UpdateUnitDisplay();
                    }

                    comboBoxOfCategory.SelectedIndexChanged += isComboBoxOfCategoryChanged!;
                }
                else
                {
                    MessageBox.Show($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}",
                        Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.ErrorCategoryUpload} {ex.Message}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void isComboBoxOfCategoryChanged(object sender, EventArgs e)
        {
            UpdateUnitDisplay();
        }

        private void UpdateUnitDisplay()
        {
            if (comboBoxOfCategory.SelectedItem is not Category selectedCategory)
            {
                textBoxOfUnit.Text = string.Empty;
                return;
            }

            var unit = db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);
            textBoxOfUnit.Text = unit?.Value?.ToString() ?? string.Empty;
        }

        private bool HasChanges()
        {
            if (currentProduct == null) return false;

            bool nameChanged = textBoxOfName.Text != currentProduct.Name;

            bool categoryChanged = false;
            if (comboBoxOfCategory.SelectedItem != null)
            {
                var selectedCategory = comboBoxOfCategory.SelectedItem as Category;

                if (selectedCategory != null)
                {
                    categoryChanged = selectedCategory.Category_Id != currentProduct.CategoryId;
                }
            }

            bool priceChanged = false;
            /// price double?
            //if (double.TryParse(textBoxOfPrice.Text, out double newPrice))
            //{
            //    priceChanged = Math.Abs(newPrice - currentProduct.PurchasePrice) > 0.01;
            //}

            return nameChanged || categoryChanged || priceChanged;
        }

        private void isTextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfCategory.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPrice.Text);

            buttonOfSaveChanges.Enabled = allFieldsFilled && HasChanges();
        }

        private void buttonOfSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxOfCategory.SelectedValue == null)
                {
                    MessageBox.Show(Resources.ChooseCategoryProduct, Resources.TitleError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var productToUpdate = db.Products
                    .FirstOrDefault(p => p.Article == article);

                if (productToUpdate != null)
                {
                    productToUpdate.Name = textBoxOfName.Text;
                    if (Guid.TryParse(comboBoxOfCategory.SelectedValue.ToString(), out Guid categoryId))
                    {
                        productToUpdate.CategoryId = categoryId;
                    }
                    else
                    {
                        MessageBox.Show($"{Resources.UncorrectCategory}\n{Resources.TryAgain}",
                           Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxOfCategory.ResetText();
                        return;
                    }

                    //if (double.TryParse(textBoxOfPrice.Text, out double price))
                    //{
                    //    productToUpdate.PurchasePrice = price;
                    //}
                    //else
                    //{
                    //    MessageBox.Show($"{Resources.UncorrectPrice}\n{Resources.TryAgain}",
                    //        Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    textBoxOfPrice.Clear();
                    //    return;
                    //}

                    db.SaveChanges();

                    MessageBox.Show(Resources.SuccessUpdateProduct, Resources.TitleSuccess,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    var productCatalog = new ProductCatalog(userLogin);
                    productCatalog.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Resources.ProductNotFound, Resources.TitleError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"{Resources.AskOfCancelEdit}\n{Resources.LostUnsavedChanges}",
                Resources.ConfirmationCancel, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                var productCatalog = new ProductCatalog(userLogin);
                productCatalog.ShowDialog();
                this.Close();
            }
        }
    }
}