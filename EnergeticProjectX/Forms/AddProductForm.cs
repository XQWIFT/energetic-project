using EH = EnergeticProjectX.Classes.ErrorHandler;
using PCM = EnergeticProjectX.Classes.PriceCurrencyManager;
using TH = EnergeticProjectX.Classes.TimeHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using CHK = EnergeticProjectX.Classes.Chekouts;
using System.Text.RegularExpressions;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для добавления нового товара.
    /// </summary>
    public partial class AddProductForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы добавления нового товара.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AddProductForm(string userLogin, IProductService productService, IUserService userService, IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _productService = productService;

            _userService = userService;

            _clientService = clientService;

            LabelOfCurrencySymbol.Text = UIHelper.GetCurrencySymbol(_userService, userLogin);

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

                var categories = _productService.GetCategories();

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

            var unit = _productService.LoadCategoryUnit(selectedCategory);

            if (unit != null)
                TextBoxOfUnit.Text = unit.Name;
            else
                EH.ShowError(Resources.UnitForChosenCategoryNotFound, true);
        }

        private void ButtonOfAdd_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }
            ;

            if (ComboBoxOfCategory.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryProductFirst);

                return;
            }

            var purchasePrice = PCM.ValidatePurchasePrice(Regex.Replace(TextBoxOfPurchasePrice.Text.Trim(), @"\s", ""));

            if (purchasePrice == null)
                return;

            var purchasePriceInDefaultCurrency = PCM.SetPriceToDefaultCurrency(_userService, (decimal)purchasePrice, userLogin);


            string article;
            try
            {
               article =  _productService.GenerateUniqueProductArticle();
            }
            catch (InvalidOperationException)
            {
                EH.ShowError(Resources.MaxNumberOfProducts, true);
                return;
            }

            var product = new Product
            {
                Article = article,
                Name = Regex.Replace(TextBoxOfName.Text.Trim(), @"\s+", " "),
                CategoryId = (Guid)ComboBoxOfCategory.SelectedValue,
                PurchasePrice = purchasePriceInDefaultCurrency,
                SalePrice = PCM.GetSalePriceInDefaultCurrency(purchasePriceInDefaultCurrency),
                CreationDate = DateTime.UtcNow,
                DiscountDate = TH.GetDiscountUtcDate()
            };

            _productService.AddProduct(product);
            if (_userService.DbSaveChangesErrorCheck() == false)
            {
                EH.ShowError(Resources.UniversalErrorDatabase, true);
                return;
            }

            var salePriceInChosenCurrency = _productService.SetPriceToChosenCurrency(purchasePriceInDefaultCurrency, userLogin);

            EH.ShowInformation($"{Resources.Product} {product.Name} {Resources.AddProductSuccess}:\n\n" +
                               $"{Resources.CreationData}: {TH.UtcToLocalDateTime(DateTime.UtcNow):dd.MM.yyyy HH:mm}\n" +
                               $"{Resources.DiscountDate}: {TH.UtcDateToLocalDateOnly(product.DiscountDate)}\n" +
                               $"{Resources.PurchasePrice}: {_productService.PriceToCorrectFormat((decimal)purchasePrice, userLogin)}\n" +
                               $"{Resources.SalePrice}: {_productService.PriceToCorrectFormat(salePriceInChosenCurrency, userLogin)}\n" +
                               $"{Resources.StockQuantityByDefault}");

            OpenProductCatalog();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            OpenProductCatalog();
        }

        private void OpenProductCatalog()
        {
            var productCatalog = new TableOfProducts(userLogin, _userService, _productService, _clientService);
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