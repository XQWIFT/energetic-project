using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using ProductCatalogForm;

namespace EditProductForms
{
    /// <summary>
    /// Форма для просмотра и изменения данных товара.
    /// </summary>
    public partial class EditProduct : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;
        private readonly string article;
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

            TextBoxOfName.TextChanged += isTextChanged!;
            ComboBoxOfCategory.TextChanged += isTextChanged!;
            TextBoxOfPrice.TextChanged += isTextChanged!;
            TextBoxOfUnit.TextChanged += isTextChanged!;
            ComboBoxOfCategory.SelectedIndexChanged += isTextChanged!;

            LoadCategories();
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
                    TextBoxOfName.Text = currentProduct.Name;
                    TextBoxOfPrice.Text = currentProduct.PurchasePrice.ToString();
                }
                else
                {
                    MessageBox.Show($"{Resources.ProductNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.ErrorUploadData}\n{Resources.TryAgain}",
                                Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        /// <summary>
        /// Загрузка категорий из базы данных
        /// </summary>
        public void LoadCategories()
        {
            try
            {
                ComboBoxOfCategory.SelectedIndexChanged -= isComboBoxOfCategoryChanged!;

                var categories = db.Categories.Where(u => u.Status == CategoryStatus.Active).ToList();

                /// ???
                if (categories != null && categories.Any())
                {
                    ComboBoxOfCategory.DataSource = categories;
                    ComboBoxOfCategory.DisplayMember = Resources.CategoryDisplayMember;
                    ComboBoxOfCategory.ValueMember = Resources.CategoryValueMember;

                    if (currentProduct != null)
                    {
                        ComboBoxOfCategory.SelectedValue = currentProduct.CategoryId;
                        UpdateUnitDisplay();
                    }

                    ComboBoxOfCategory.SelectedIndexChanged += isComboBoxOfCategoryChanged!;
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
            if (ComboBoxOfCategory.SelectedItem is not Category selectedCategory)
            {
                TextBoxOfUnit.Text = string.Empty;
                return;
            }

            var unit = db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);
            TextBoxOfUnit.Text = unit?.Name?.ToString() ?? string.Empty;
        }

        private bool HasChanges()
        {
            if (currentProduct == null) return false;

            bool nameChanged = TextBoxOfName.Text != currentProduct.Name;

            bool categoryChanged = false;
            if (ComboBoxOfCategory.SelectedItem != null)
            {
                var selectedCategory = ComboBoxOfCategory.SelectedItem as Category;

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
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(ComboBoxOfCategory.Text) &&
                                   !string.IsNullOrWhiteSpace(TextBoxOfPrice.Text);

            ButtonOfSaveChanges.Enabled = allFieldsFilled && HasChanges();
        }

        private void buttonOfSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfCategory.SelectedValue == null)
                {
                    MessageBox.Show(Resources.ChooseCategoryProduct, Resources.TitleError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var productToUpdate = db.Products
                    .FirstOrDefault(p => p.Article == article);

                if (productToUpdate != null)
                {
                    productToUpdate.Name = TextBoxOfName.Text;
                    if (Guid.TryParse(ComboBoxOfCategory.SelectedValue.ToString(), out Guid categoryId))
                    {
                        productToUpdate.CategoryId = categoryId;
                    }
                    else
                    {
                        MessageBox.Show($"{Resources.UncorrectCategory}\n{Resources.TryAgain}",
                           Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ComboBoxOfCategory.ResetText();
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
            catch (Exception)
            {
                MessageBox.Show($"{Resources.ErrorUploadData}, {Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"{Resources.AskOfCancelEdit}\n{Resources.LostUnsavedChanges}",
                Resources.ConfirmationCancel, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Hide();
                var productCatalog = new ProductCatalog(userLogin);
                productCatalog.ShowDialog();
                Close();
            }
        }
    }
}