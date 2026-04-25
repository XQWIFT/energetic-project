using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Globalization;
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
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <param name="article">Артикул выбранного товара.</param>
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
                    EH.ShowError($"{Resources.ProductNotFound}\n{Resources.TryAgain}");

                    return;
                }
            }
            catch (Exception)
            {
                EH.ShowError($"{Resources.ErrorUploadData}\n{Resources.TryAgain}");

                return;
            }
        }

        private void UserExistsCheck()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError($"{Resources.UserNotFound}\n{Resources.TryAgain}");

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
                    EH.ShowError($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}");

                    return;
                }
            }
            catch (Exception)
            {
                EH.ShowError($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}");

                return;
            }
        }

        private void ButtonOfChange_Click(object sender, EventArgs e)
        {
            var answer = EH.ShowConfirmation($"{Resources.SureWantToChangeProductData}\n\n{Resources.AvailableFieldsToEditProduct}\n\n" +
                                             $"{Resources.IfChangePurchaseThenChangeSale}");

            if (answer == DialogResult.Yes)
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

            var hasChangesTextBoxes = TextBoxOfName.Text.Trim() != currentProduct.Name ||
                                      TextBoxOfPurchasePrice.Text.Trim() != PriceCurrencyManager.SetPriceToChosenCurrency(db, currentProduct.PurchasePrice, userLogin).ToString() ||
                                      TextBoxOfDiscountDate.Text.Trim() != currentProduct.DiscountDate.ToString();

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
                    EH.ShowAlert(Resources.ChooseCategoryProduct);

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
                        EH.ShowError($"{Resources.IncorrectCategory}\n{Resources.TryAgain}");

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

                    productToUpdate.SalePrice = PriceCurrencyManager.GetSalePriceInDefaultCurrency(productToUpdate.PurchasePrice);

                    if (!DateOnly.TryParseExact(TextBoxOfDiscountDate.Text, Resources.CorrectDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var discountDate))
                    {
                        EH.ShowError($"{Resources.IncorrectDateFormat}\n\n{Resources.CorrectDateFormatExample}");

                        return;
                    }
                    else if (discountDate < DateOnly.FromDateTime(productToUpdate.CreationDate).AddMonths(2))
                    {
                        EH.ShowWarning($"{Resources.DiscountDateCannotBeCreationDate}.\n{Resources.TryAgain}");

                        TextBoxOfDiscountDate.Text = string.Empty;

                        return;
                    }

                    productToUpdate.DiscountDate = discountDate;

                    if (EH.DBSaveChangesUniversalErrorCheck(db))
                        return;

                    EH.ShowInformation(Resources.SuccessUpdateProduct);

                    Hide();
                    var productCatalog = new ProductCatalog(userLogin);
                    productCatalog.ShowDialog();
                    Close();
                }
                else
                {
                    EH.ShowError($"{Resources.ProductNotFound}\n{Resources.TryAgain}");
                }
            }
            catch (Exception)
            {
                EH.ShowError($"{Resources.ErrorUploadData}\n{Resources.TryAgain}");

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            var answer = EH.ShowConfirmation($"{Resources.AskOfCancelEdit}\n\n{Resources.LostUnsavedChanges}");

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

            var text = ComboBoxOfCategory.GetItemText(ComboBoxOfCategory.Items[e.Index])!;

            e.Graphics.DrawString(text, e.Font!, Brushes.Black, e.Bounds);

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }
        }

        private void ButtonOfProductDelete_Click(object sender, EventArgs e)
        {
            var answer = EH.ShowConfirmation(Resources.AskForDeleteProduct);

            if (answer == DialogResult.Yes)
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null)
                {
                    EH.ShowError($"{Resources.ProductNotFound}\n{Resources.TryAgain}");

                    return;
                }

                product.Status = ProductStatus.Hidden;

                if (EH.DBSaveChangesUniversalErrorCheck(db))
                    return;

                EH.ShowInformation(Resources.SuccessDeleteProduct);

                Hide();
                var productCatalog = new ProductCatalog(userLogin);
                productCatalog.ShowDialog();
                Close();
            }
        }
    }
}