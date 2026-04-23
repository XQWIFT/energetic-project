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
        private Product? currentProduct;

        /// <summary>
        /// Конструктор изменения товаров.
        /// </summary>
        public EditProduct(string userLogin, string article)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            this.article = article;

            UserExistsCheck();

            LoadCurrency();

            LoadProductData();

            LoadCategories();

            ComboBoxOfCategory.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxOfCategory.DrawItem += ComboBoxOfCategory_DrawItem!;

            ComboBoxOfCategory.BackColor = Color.White;
            ComboBoxOfCategory.Enabled = false;

            TextBoxOfName.TextChanged += IsTextChanged!;
            ComboBoxOfCategory.TextChanged += IsTextChanged!;
            TextBoxOfUnit.TextChanged += IsTextChanged!;
            ComboBoxOfCategory.SelectedIndexChanged += IsTextChanged!;
            TextBoxOfPurchasePrice.TextChanged += IsTextChanged!;
        }

        private void LoadProductData()
        {
            try
            {
                currentProduct = db.Products.FirstOrDefault(p => p.Article == article)!;

                if (currentProduct != null)
                {
                    TextBoxOfName.Text = currentProduct.Name;
                    TextBoxOfCurrentStockQuantity.Text = currentProduct.StockQuantity.ToString();
                    TextBoxOfPurchasePrice.Text = PriceCurrencyManager.SetPriceToChosenCurrency(db, currentProduct.PurchasePrice, userLogin).ToString();
                    TextBoxOfPriceForSell.Text = PriceCurrencyManager.SetPriceToChosenCurrency(db, currentProduct.SalePrice, userLogin).ToString();
                    TextBoxOfCreationDate.Text = currentProduct.CreationDate.ToString("dd.MM.yyyy HH:mm");
                    TextBoxOfDiscountDate.Text = currentProduct.DiscountDate.ToString("dd.MM.yyyy");
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

        private void UserExistsCheck()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                MessageBox.Show($"{Resources.UserNotFound}\n{Resources.TryAgain}", Resources.TitleErrorBD,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void LoadCurrency()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user!.CurrencyId);

            LabelOfCurrencySymbolFirst.Text = currency!.CurrencySymbol;
            LabelOfCurrencySymbolSecond.Text = currency!.CurrencySymbol;
        }

        private void LoadCategories()
        {
            try
            {
                ComboBoxOfCategory.SelectedIndexChanged -= IsComboBoxOfCategoryChanged!;

                var categories = db.Categories.Where(u => u.Status == CategoryStatus.Active).ToList();

                if (categories != null && categories.Count != 0)
                {
                    ComboBoxOfCategory.DataSource = categories;
                    ComboBoxOfCategory.DisplayMember = Resources.CategoryDisplayMember;
                    ComboBoxOfCategory.ValueMember = Resources.CategoryValueMember;

                    if (currentProduct != null)
                    {
                        ComboBoxOfCategory.SelectedValue = currentProduct.CategoryId;
                        UpdateUnitDisplay();
                    }

                    ComboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged!;
                }
                else
                {
                    MessageBox.Show($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}",
                                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}",
                                Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfChange_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"{Resources.SureWantToChangeProductData}\n\n{Resources.AvailableFieldsToEditProduct}\n\n" +
                                        $"{Resources.IfChangePurchaseThenChangeSale}", Resources.TitleConfirmation,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ButtonOfChange.Enabled = false;

                TextBoxOfName.ReadOnly = false;
                ComboBoxOfCategory.Enabled = true;
                ComboBoxOfCategory.BackColor = Color.White;
                TextBoxOfPurchasePrice.ReadOnly = false;
                TextBoxOfDiscountDate.ReadOnly = false;
            }
        }

        private void IsComboBoxOfCategoryChanged(object sender, EventArgs e)
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

        private void IsTextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                  !string.IsNullOrWhiteSpace(ComboBoxOfCategory.Text) &&
                                  !string.IsNullOrWhiteSpace(TextBoxOfPurchasePrice.Text) &&
                                  !string.IsNullOrWhiteSpace(TextBoxOfDiscountDate.Text);

            if (currentProduct == null)
                return;

            var hasChangesTextBoxes = TextBoxOfName.Text != currentProduct.Name ||
                             TextBoxOfPurchasePrice.Text != currentProduct.PurchasePrice.ToString() ||
                             TextBoxOfDiscountDate.Text != currentProduct.DiscountDate.ToString();

            var hasChangesComboBox = false;
            if (ComboBoxOfCategory.SelectedItem != null)
            {
                if (ComboBoxOfCategory.SelectedItem is Category selectedCategory)
                {
                    hasChangesComboBox = selectedCategory.Category_Id != currentProduct.CategoryId;
                }
            }

            var hasChanges = hasChangesTextBoxes || hasChangesComboBox;


            ButtonOfSaveChanges.Enabled = allFieldsFilled && hasChanges;
        }

        private void ButtonOfSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxOfCategory.SelectedValue == null)
                {
                    MessageBox.Show(Resources.ChooseCategoryProduct, Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var productToUpdate = db.Products.FirstOrDefault(p => p.Article == article);

                if (productToUpdate != null)
                {
                    productToUpdate.Name = TextBoxOfName.Text.Trim();
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

                    var purchasePrice = PriceCurrencyManager.ValidatePurchasePrice(TextBoxOfPurchasePrice.Text);
                    if (purchasePrice == null)
                    {
                        TextBoxOfPurchasePrice.Text = string.Empty;
                        return;
                    }

                    productToUpdate.PurchasePrice = PriceCurrencyManager.SetPriceToDefaultCurrency(db, (decimal)purchasePrice, userLogin);

                    if (!DateOnly.TryParse(TextBoxOfDiscountDate.Text, out var discountDate))
                    {
                        MessageBox.Show($"{Resources.IncorrectDateFormat}\n\n{Resources.CorrectDateFormatExample}", Resources.TitleError,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    productToUpdate.DiscountDate = discountDate;

                    if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                        return;

                    MessageBox.Show(Resources.SuccessUpdateProduct, Resources.TitleInformation,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Hide();
                    var productCatalog = new ProductCatalog(userLogin);
                    productCatalog.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show($"{Resources.ProductNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.ErrorUploadData}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show($"{Resources.AskOfCancelEdit}\n\n{Resources.LostUnsavedChanges}", Resources.ConfirmationCancel,
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                Hide();
                var productCatalog = new ProductCatalog(userLogin);
                productCatalog.ShowDialog();
                Close();
            }
        }

        private void ComboBoxOfCategory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.Graphics.FillRectangle(Brushes.White, e.Bounds);

            string text = ComboBoxOfCategory.GetItemText(ComboBoxOfCategory.Items[e.Index])!;

            e.Graphics.DrawString(text, e.Font!, Brushes.Black, e.Bounds);

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }
        }

        private void ButtonOfProductDelete_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show(Resources.AskForDeleteProduct, Resources.TitleConfirmation,
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null)
                {
                    MessageBox.Show($"{Resources.ProductNotFound}\n{Resources.TryAgain}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                product.Status = ProductStatus.Hidden;

                if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                    return;

                MessageBox.Show(Resources.SuccessDeleteProduct, Resources.TitleInformation,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                var productCatalog = new ProductCatalog(userLogin);
                productCatalog.ShowDialog();
                Close();
            }
        }
    }
}