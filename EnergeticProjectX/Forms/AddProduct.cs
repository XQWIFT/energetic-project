using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using ProductCatalogForm;

namespace AddProductForm
{
    /// <summary>
    /// Класс для добавления нового товара
    /// </summary>
    public partial class AddProduct : Form
    {
        readonly ApplicationContextDB db = new();

        readonly string userLogin;

        /// <summary>
        /// Конструктор добавления нового товара
        /// </summary>
        public AddProduct(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            TextBoxOfName.TextChanged += IsTextChanged!;
            ComboBoxOfCategory.TextChanged += IsTextChanged!;
            TextBoxOfPurchasePrice.TextChanged += IsTextChanged!;
            ComboBoxOfCategory.SelectedIndexChanged += IsTextChanged!;
            ComboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged!;

            LoadChosenCurrency();
            LoadCategories();

            ComboBoxOfCategory.SelectedIndex = -1;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                  !string.IsNullOrWhiteSpace(ComboBoxOfCategory.Text) &&
                                  !string.IsNullOrWhiteSpace(TextBoxOfPurchasePrice.Text);

            ButtonOfAdd.Enabled = allFieldsFilled;
        }
        private void LoadCategories()
        {
            ComboBoxOfCategory.SelectedIndexChanged -= IsComboBoxOfCategoryChanged!;

            var categories = db.Categories.Where(u => u.Status == CategoryStatus.Active).ToList();

            if (categories != null)
            {
                ComboBoxOfCategory.DataSource = categories;
                ComboBoxOfCategory.DisplayMember = Resources.CategoryDisplayMember;
                ComboBoxOfCategory.ValueMember = Resources.CategoryValueMember;

                ComboBoxOfCategory.SelectedIndex = -1;
                TextBoxOfUnit.Text = string.Empty;

                ComboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged!;
            }
            else
            {
                EH.ShowError($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}");

                return;
            }
        }

        private void LoadChosenCurrency()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError($"{Resources.UserNotFound}\n{Resources.TryAgain}");

                return;
            }

            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

            if (currency == null)
            {
                EH.ShowError($"{Resources.ErrorUserDataUpload}\n{Resources.TryAgain}");

                return;
            }

            LabelOfCurrencySymbol.Text = currency.CurrencySymbol;
        }

        private void IsComboBoxOfCategoryChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem is not Category selectedCategory)
            {
                EH.ShowError($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}");

                return;
            }

            var categoryId = selectedCategory.Category_Id;

            var unit = db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);

            if (unit != null)
                TextBoxOfUnit.Text = unit.Name.ToString();
            else
                EH.ShowError($"{Resources.UnitNotFound}\n{Resources.TryAgain}");
        }

        private void ButtonOfAdd_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryProduct);

                return;
            }

            var purchasePrice = PriceCurrencyManager.ValidatePurchasePrice(TextBoxOfPurchasePrice.Text.Trim());
            if (purchasePrice == null)
                return;

            if (!Guid.TryParse(ComboBoxOfCategory.SelectedValue.ToString()!, out Guid selectedCategoryId))
            {
                EH.ShowError($"{Resources.CategoryGetIdError}\n{Resources.TryAgain}");

                return;
            }

            var product = new Product
            {
                Article = GenerateUniqueProductArticle(db),
                Name = TextBoxOfName.Text,
                CategoryId = selectedCategoryId,
                PurchasePrice = PriceCurrencyManager.SetPriceToDefaultCurrency(db, (decimal)purchasePrice, userLogin),
                SalePrice = PriceCurrencyManager.GetSalePriceInDefaultCurrency(PriceCurrencyManager.SetPriceToDefaultCurrency(db, (decimal)purchasePrice, userLogin)),
                CreationDate = DateTime.UtcNow,
                DiscountDate = DateOnly.FromDateTime(DateTime.Now).AddMonths(2)
            };
            
            db.Products.Add(product);
            if (EH.DBSaveChangesUniversalErrorCheck(db))
                return;

            EH.ShowInformation($"{Resources.Product} {product.Name} {Resources.AddProductSuccess}:\n\n" +
                               $"{Resources.CreationData}: {DateTime.Now}\n" +
                               $"{Resources.DiscountDate}: {product.DiscountDate}\n" +
                               $"{Resources.PurchasePriceRus}: {PriceCurrencyManager.PriceToCorrectFormat(db, (decimal)purchasePrice, userLogin)}\n" +
                               $"{Resources.SalePrice}: {PriceCurrencyManager.PriceToCorrectFormat(db, Product.priceIncreaseCoefficient * (decimal)purchasePrice, userLogin)}\n" +
                               $"{Resources.StockQuantityByDefault}");

            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private static string GenerateUniqueProductArticle(ApplicationContextDB db)
        {
            var maxArticleString = db.Products
                                     .Select(u => u.Article)
                                     .Where(article => !string.IsNullOrWhiteSpace(article))
                                     .OrderByDescending(article => article)
                                     .FirstOrDefault();

            var maxCode = string.IsNullOrEmpty(maxArticleString) ? 0 : int.Parse(maxArticleString![1..]);

            if (maxCode >= 999999)
                throw new InvalidOperationException(Resources.MaxNumberOfProducts);

            return "A" + (maxCode + 1).ToString("D6");
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }
    }
}
