using EnergeticProjectX.Classes;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Properties;
using Microsoft.Extensions.DependencyInjection;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для главного меню администратора.
    /// </summary>
    public partial class AdministratorMainMenu : Form
    {
        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly IProductService _productService;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы главного меню администратора.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AdministratorMainMenu(string userLogin, IUserService userService, IClientService clientService, IProductService productService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            ActiveControl = LabelOfCompanyName;

            _userService = userService;

            _clientService = clientService;

            _productService = productService;

            LoadUserData();
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
            var changePassword = new ChangePasswordForm(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, changePassword);
        }

        private void ButtonListOfUsers_Click(object sender, EventArgs e)
        {
            var listOfUsers = new TableOfUsers(userLogin, _clientService, _userService, _productService);
            FH.OpenForm(this, listOfUsers);
        }

        private void ButtonOfLogOut_Click(object sender, EventArgs e)
        {
            var authorizationForm = Program.ServiceProvider.GetRequiredService<AuthorizationForm>();
            FH.OpenForm(this, authorizationForm);
        }

        private void ButtonOfClients_Click(object sender, EventArgs e)
        {
            var listOfClients = new TableOfClients(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, listOfClients);
        }

        private void ButtonOfProductCatalog_Click(object sender, EventArgs e)
        {
            var productCatalog = new TableOfProducts(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, productCatalog);
        }

        private void ButtonOfShipmentLog_Click(object sender, EventArgs e)
        {
            var shipmentJournal = new TableOfShipmentsForm(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, shipmentJournal);
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
            var heapMapForm = new HeatMapForm(userLogin, _userService, _productService, _clientService);
            FH.OpenForm(this, heapMapForm);
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