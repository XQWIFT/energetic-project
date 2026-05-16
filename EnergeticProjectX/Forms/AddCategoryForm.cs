using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Text.RegularExpressions;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Класс для добавления новой категории.
    /// </summary>
    public partial class AddCategoryForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        /// <summary>
        /// Основной конструктор добавления новой категории.
        /// </summary>
        public AddCategoryForm(string userLogin, IProductService productService, IUserService userService, IClientService clientService)
        {
            InitializeComponent();

            _productService = productService;
            _userService = userService;
            _clientService = clientService;
            this.userLogin = userLogin;

            try
            {
                _productService.GetUnits();
            }
            catch
            {
                EH.ShowError(Resources.ErrorUnitUpload, true);

                return;
            }
        }
       
        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfAddCategory.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfCategoryName.Text) &&
                                          !string.IsNullOrWhiteSpace(ComboBoxOfUnit.Text);
        }

        private void ButtonOfAddCategory_Click(object sender, EventArgs e)
        {
            if (!EnsureUserActive())
                return;

            if (ComboBoxOfUnit.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseNewUnitToEditCategoryFirst);

                return;
            }

            var newCategory = new Category
            {
                Name = Regex.Replace(TextBoxOfCategoryName.Text, @"\s+", " "),
                Unit_Id = (Guid)ComboBoxOfUnit.SelectedValue
            };

            if (_productService.IsCategoryNameBusy(newCategory.Name))
            {
                EH.ShowWarning(Resources.NewCategoryAlreadyExists, true);

                return;
            }
            

            _productService.AddCategory(newCategory);
            if (_userService.DbSaveChangesErrorCheck())
                return;

            EH.ShowInformation(Resources.NewCategorySuccessfullyAdded);

            OpenProductCatalog();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            OpenProductCatalog();
        }

        private bool EnsureUserActive()
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return false;
            }
            return true;
        }

        private void OpenProductCatalog()
        {
            if (!EnsureUserActive())
                return;

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
    }
}