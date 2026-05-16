using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Properties;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для реализации главного меню кладовщика.
    /// </summary>
    public partial class WarehousemanMainMenu : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы главного меню кладовщика.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public WarehousemanMainMenu(string userLogin, IUserService userService, IProductService productService,
            IClientService clientService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _clientService = clientService;

            _productService = productService;

            LoadUserData();

            ActiveControl = LabelOfCompanyName;
        }

        private void LoadUserData()
        {
            var user = _userService.EnsureUserActive(userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            LabelOfFullName.Text = $"{Resources.FullName}: {user.Surname} {user.Name} {user.Patronymic}";
        }

        private void ButtonOfChangePassword_Click(object sender, EventArgs e)
        {
            var userChangePassword = new ChangePasswordForm(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, userChangePassword);
        }

        private void ButtonOfLogOut_Click(object sender, EventArgs e)
        {
            FH.RedirectToAuthorization(this);
        }

        private void ButtonOfProductCatalog_Click(object sender, EventArgs e)
        {
            var productCatalog = new TableOfProducts(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, productCatalog);
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            var makingShipment = new MakeShipmentForm(userLogin, _clientService, _userService, _productService);
            FH.OpenForm(this, makingShipment);
        }

        private void ButtonOfSettings_Click(object sender, EventArgs e)
        {
            var userSettings = new SettingsForm(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, userSettings);
        }

        private void ButtonOfSupply_Click(object sender, EventArgs e)
        {
            var makingSupply = new MakeDeliveryForm(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, makingSupply);
        }

        private void ButtonOfHeatMap_Click(object sender, EventArgs e)
        {
            var heatMapForm = new HeatMapForm(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, heatMapForm);
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
