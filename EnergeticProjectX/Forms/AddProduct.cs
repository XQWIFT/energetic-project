using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для добавления нового товара.
    /// </summary>
    public partial class AddProduct : Form
    {
        readonly ApplicationContextDB db = new();

        readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы добавления нового товара.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AddProduct(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadChosenCurrency(db, ref LabelOfCurrencySymbol, userLogin);
            LoadCategories();
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfAddProduct.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                         !string.IsNullOrWhiteSpace(ComboBoxOfCategory.Text) &&
                                         !string.IsNullOrWhiteSpace(TextBoxOfPurchasePrice.Text);
        }

        private void LoadCategories()
        {
            try
            {
                ComboBoxOfCategory.SelectedIndexChanged -= IsComboBoxOfCategoryChanged!;

                var categories = db.Categories.Where(u => u.Status == CategoryStatus.Active).ToList();

                ComboBoxOfCategory.DisplayMember = nameof(Category.Name);
                ComboBoxOfCategory.ValueMember = nameof(Category.Category_Id);
                ComboBoxOfCategory.DataSource = categories;

                ComboBoxOfCategory.SelectedIndex = -1;
                TextBoxOfUnit.Text = string.Empty;

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

        /// <summary>
        /// Метод, который загружает символ выбранной у пользователя валюты в соответствующее поле.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="label">Соответствующее поле.</param>
        public static void LoadChosenCurrency(ApplicationContextDB db, ref Label label, string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }

            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

            if (currency == null)
            {
                EH.ShowError(Resources.ErrorUserDataUpload, true);

                return;
            }

            label.Text = currency.CurrencySymbol;
        }

        private void IsComboBoxOfCategoryChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem is not Category selectedCategory)
            {
                EH.ShowError(Resources.ErrorCategoryUpload, true);

                return;
            }

            var unit = db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);

            if (unit != null)
                TextBoxOfUnit.Text = unit.Name;
            else
                EH.ShowError(Resources.UnitForChosenCategoryNotFound, true);
        }

        private void ButtonOfAdd_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryProductFirst);

                return;
            }

            var purchasePrice = PCM.ValidatePurchasePrice(TextBoxOfPurchasePrice.Text.Replace(" ", ""));

            if (purchasePrice == null)
                return;

            var purchasePriceInDefaultCurrency = PCM.SetPriceToDefaultCurrency(db, (decimal)purchasePrice, userLogin);

            var product = new Product
            {
                Article = GenerateUniqueProductArticle(db),
                Name = TextBoxOfName.Text.Trim(),
                CategoryId = (Guid)ComboBoxOfCategory.SelectedValue,
                PurchasePrice = purchasePriceInDefaultCurrency,
                SalePrice = PCM.GetSalePriceInDefaultCurrency(purchasePriceInDefaultCurrency),
                CreationDate = DateTime.UtcNow,
                DiscountDate = TH.GetDiscountUtcDate()
            };
            
            db.Products.Add(product);
            if (EH.DBSaveChangesUniversalErrorCheck(db))
                return;

            var salePriceInChosenCurrency = PCM.SetPriceToChosenCurrency(db, product.SalePrice, userLogin);

            EH.ShowInformation($"{Resources.Product} {product.Name} {Resources.AddProductSuccess}:\n\n" +
                               $"{Resources.CreationData}: {TH.UtcToLocalDateTime(DateTime.UtcNow):dd.MM.yyyy HH:mm}\n" +
                               $"{Resources.DiscountDate}: {TH.UtcDateToLocalDateOnly(product.DiscountDate)}\n" +
                               $"{Resources.PurchasePrice}: {PCM.PriceToCorrectFormat(db, (decimal)purchasePrice, userLogin)}\n" +
                               $"{Resources.SalePrice}: {PCM.PriceToCorrectFormat(db, salePriceInChosenCurrency, userLogin)}\n" +
                               $"{Resources.StockQuantityByDefault}");

            ReturnToMainMenu();
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
            ReturnToMainMenu();
        }

        private void ReturnToMainMenu()
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
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
