using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Globalization;
using System.Text.RegularExpressions;
using CHK = EnergeticProjectX.Classes.Chekouts;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для просмотра и изменения данных товара.
    /// </summary>
    public partial class EditProductForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        private readonly string article;

        private Product? currentProduct;

        /// <summary>
        /// Конструктор для реализации формы просмотра и изменения карточки товара.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <param name="article">Артикул выбранного товара.</param>
        public EditProductForm(string userLogin, string article)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            this.article = article;

            LabelOfCurrencySymbolFirst.Text = UIHelper.GetCurrencySymbol(Db, userLogin);
            LabelOfCurrencySymbolSecond.Text = UIHelper.GetCurrencySymbol(Db, userLogin);
            LoadProductData();
            LoadCategories();

            if (currentProduct != null)
            {
                ComboBoxOfCategory.SelectedValue = currentProduct.CategoryId;
                UpdateUnitDisplay();
            }
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
                                      TextBoxOfPurchasePrice.Text.Trim() != PCM.SetPriceToChosenCurrency(Db, currentProduct.PurchasePrice, userLogin).ToString() ||
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

        private void LoadProductData()
        {
            try
            {
                currentProduct = Db.Products.FirstOrDefault(p => p.Article == article)!;

                if (currentProduct != null)
                {
                    TextBoxOfName.Text = currentProduct.Name;
                    TextBoxOfCurrentStockQuantity.Text = currentProduct.StockQuantity.ToString();
                    TextBoxOfCategory.Text = Db.Categories.FirstOrDefault(c => c.Category_Id == currentProduct.CategoryId)!.Name;
                    TextBoxOfPurchasePrice.Text = PCM.SetPriceToChosenCurrency(Db, currentProduct.PurchasePrice, userLogin).ToString();
                    TextBoxOfPriceForSell.Text = PCM.SetPriceToChosenCurrency(Db, currentProduct.SalePrice, userLogin).ToString();
                    TextBoxOfCreationDate.Text = TH.UtcToLocalDateTime(currentProduct.CreationDate).ToString("dd.MM.yyyy HH:mm");
                    TextBoxOfDiscountDate.Text = TH.UtcDateToLocalDateOnly(currentProduct.DiscountDate).ToString("dd.MM.yyyy");

                }
                else
                {
                    EH.ShowError(Resources.ProductNotFound, true);

                    return;
                }
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void LoadCategories()
        {
            try
            {
                ComboBoxOfCategory.SelectedIndexChanged -= IsComboBoxOfCategoryChanged!;

                var categories = Db.Categories.Where(u => u.Status == Status.Active).ToList();

                ComboBoxOfCategory.DisplayMember = nameof(Category.Name);
                ComboBoxOfCategory.ValueMember = nameof(Category.Category_Id);
                ComboBoxOfCategory.DataSource = categories;

                if (categories.Count == 0)
                {
                    EH.ShowError(Resources.ErrorCategoryUpload, true);
                }
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorCategoryUpload, true);
            }
            finally
            {
                ComboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged!;
            }
        }

        private void ButtonOfChange_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var answer = EH.ShowConfirmation($"{Resources.SureWantToChangeProductData}\n\n{Resources.AvailableFieldsToEditProduct}\n\n" +
                                             $"{Resources.IfChangePurchaseThenChangeSale}");

            if (answer == DialogResult.Yes)
            {
                ButtonOfChange.Enabled = false;
                TextBoxOfName.ReadOnly = false;
                TextBoxOfPurchasePrice.ReadOnly = false;
                TextBoxOfDiscountDate.ReadOnly = false;
                TextBoxOfCategory.Visible = false;
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

            var unit = Db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);

            if (unit == null)
            {
                EH.ShowError(Resources.ErrorUnitUpload, true);

                return;
            }

            TextBoxOfUnit.Text = unit.Name;
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            try
            {
                if (ComboBoxOfCategory.SelectedValue == null)
                {
                    EH.ShowAlert(Resources.ChooseCategoryProductFirst);

                    return;
                }

                var productToUpdate = Db.Products.FirstOrDefault(p => p.Article == article);

                if (productToUpdate == null)
                {
                    EH.ShowError(Resources.ProductNotFound, true);

                    return;
                }

                productToUpdate.Name = Regex.Replace(TextBoxOfName.Text, @"\s+", " ");

                productToUpdate.CategoryId = (Guid)ComboBoxOfCategory.SelectedValue;

                var purchasePrice = PCM.ValidatePurchasePrice(TextBoxOfPurchasePrice.Text);

                if (purchasePrice == null)
                {
                    TextBoxOfPurchasePrice.Text = string.Empty;

                    return;
                }

                productToUpdate.PurchasePrice = PCM.SetPriceToDefaultCurrency(Db, (decimal)purchasePrice, userLogin);

                productToUpdate.SalePrice = PCM.GetSalePriceInDefaultCurrency(productToUpdate.PurchasePrice);

                var creationDateInLocalTime = TH.UtcToLocalDateTime(productToUpdate.CreationDate);

                if (!DateOnly.TryParseExact(TextBoxOfDiscountDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var discountDate))
                {
                    EH.ShowError($"{Resources.IncorrectDateFormat}\n\n{Resources.CorrectDateFormatExample}", true);

                    return;
                }
                else if (discountDate < DateOnly.FromDateTime(creationDateInLocalTime).AddMonths(2))
                {
                    EH.ShowWarning(Resources.DiscountDateShouldNotBeEarlierThanCreationDate, true);

                    TextBoxOfDiscountDate.Text = string.Empty;
                    TextBoxOfDiscountDate.Focus();

                    return;
                }

                productToUpdate.DiscountDate = TH.LocalDateOnlyToUtcDate(discountDate);

                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;

                EH.ShowInformation(Resources.SuccessUpdateProduct);

                OpenProductCatalog();
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (ButtonOfChange.Enabled)
            {
                var answer = EH.ShowConfirmation($"{Resources.ConfirmationToCancelEdit}\n\n{Resources.UnsavedChangesWillBeLost}");

                if (answer == DialogResult.Yes)
                {
                    OpenProductCatalog();
                }
            }
            else
            {
                OpenProductCatalog();
            }
        }

        private void ButtonOfProductDelete_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var answer = EH.ShowConfirmation(Resources.ConfirmationToDeleteProduct);

            if (answer == DialogResult.Yes)
            {
                var product = Db.Products.FirstOrDefault(p => p.Article == article);

                if (product == null)
                {
                    EH.ShowError(Resources.ProductNotFound, true);

                    return;
                }

                product.Status = Status.Hidden;

                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;

                EH.ShowInformation(Resources.ProductSuccessfullyDeleted);

                OpenProductCatalog();
            }
        }

        private void OpenProductCatalog()
        {
            var productCatalog = new TableOfProducts(userLogin);
            FH.OpenForm(this, productCatalog);
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

        private void TextBoxOfPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            var text = TextBoxOfPurchasePrice.Text;

            CHK.CheckPrice(e, text);
        }
    }
}