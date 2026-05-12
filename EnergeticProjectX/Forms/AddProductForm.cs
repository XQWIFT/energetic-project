using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using CHK = EnergeticProjectX.Classes.Chekouts;
using System.Text.RegularExpressions;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
    
namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для добавления нового товара.
    /// </summary>
    public partial class AddProductForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы добавления нового товара.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AddProductForm(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LabelOfCurrencySymbol.Text = UIHelper.GetCurrencySymbol(Db, userLogin);

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

                var categories = Db.Categories.Where(u => u.Status == Status.Active).ToList();

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

        private void IsComboBoxOfCategoryChanged(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem is not Category selectedCategory)
            {
                EH.ShowError(Resources.ErrorCategoryUpload, true);

                return;
            }

            var unit = Db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);

            if (unit != null)
                TextBoxOfUnit.Text = unit.Name;
            else
                EH.ShowError(Resources.UnitForChosenCategoryNotFound, true);
        }

        private void ButtonOfAdd_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (ComboBoxOfCategory.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryProductFirst);

                return;
            }

            var purchasePrice = PCM.ValidatePurchasePrice(Regex.Replace(TextBoxOfPurchasePrice.Text.Trim(), @"\s", ""));

            if (purchasePrice == null)
                return;

            var purchasePriceInDefaultCurrency = PCM.SetPriceToDefaultCurrency(Db, (decimal)purchasePrice, userLogin);

            var product = new Product
            {
                Article = GenerateUniqueProductArticle(Db),
                Name = Regex.Replace(TextBoxOfName.Text.Trim(), @"\s+", " "),
                CategoryId = (Guid)ComboBoxOfCategory.SelectedValue,
                PurchasePrice = purchasePriceInDefaultCurrency,
                SalePrice = PCM.GetSalePriceInDefaultCurrency(purchasePriceInDefaultCurrency),
                CreationDate = DateTime.UtcNow,
                DiscountDate = TH.GetDiscountUtcDate()
            };

            Db.Products.Add(product);
            if (EH.DBSaveChangesUniversalErrorCheck(Db))
                return;

            var salePriceInChosenCurrency = PCM.SetPriceToChosenCurrency(Db, product.SalePrice, userLogin);

            EH.ShowInformation($"{Resources.Product} {product.Name} {Resources.AddProductSuccess}:\n\n" +
                               $"{Resources.CreationData}: {TH.UtcToLocalDateTime(DateTime.UtcNow):dd.MM.yyyy HH:mm}\n" +
                               $"{Resources.DiscountDate}: {TH.UtcDateToLocalDateOnly(product.DiscountDate)}\n" +
                               $"{Resources.PurchasePrice}: {PCM.PriceToCorrectFormat(Db, (decimal)purchasePrice, userLogin)}\n" +
                               $"{Resources.SalePrice}: {PCM.PriceToCorrectFormat(Db, salePriceInChosenCurrency, userLogin)}\n" +
                               $"{Resources.StockQuantityByDefault}");

            OpenProductCatalog();
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
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            OpenProductCatalog();
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
