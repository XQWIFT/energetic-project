using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using Microsoft.Extensions.DependencyInjection;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для главного меню администратора.
    /// </summary>
    public partial class AdministratorMainMenu : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы главного меню администратора.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AdministratorMainMenu(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            ActiveControl = LabelOfCompanyName;

            LoadUserData();
        }

        private void LoadUserData()
        {
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
            if (user == null) return;

            LabelOfFullName.Text = $"{Resources.FullName}: {user.Surname} {user.Name} {user.Patronymic}";
        }

        private void ButtonOfChangePassword_Click(object sender, EventArgs e)
        {
            var changePassword = new ChangePasswordForm(userLogin);
            FH.OpenForm(this, changePassword);
        }

        private void ButtonListOfUsers_Click(object sender, EventArgs e)
        {
            var listOfUsers = new TableOfUsers(userLogin);
            FH.OpenForm(this, listOfUsers);
        }

        private void ButtonOfLogOut_Click(object sender, EventArgs e)
        {
            var authorizationForm = Program.ServiceProvider.GetRequiredService<AuthorizationForm>();
            FH.OpenForm(this, authorizationForm);
        }

        private void ButtonOfClients_Click(object sender, EventArgs e)
        {
            var listOfClients = new TableOfClients(userLogin);
            FH.OpenForm(this, listOfClients);
        }

        private void ButtonOfProductCatalog_Click(object sender, EventArgs e)
        {
            var productCatalog = new TableOfProducts(userLogin);
            FH.OpenForm(this, productCatalog);
        }

        private void ButtonOfShipmentLog_Click(object sender, EventArgs e)
        {
            var shipmentJournal = new TableOfShipmentsForm(userLogin);
            FH.OpenForm(this, shipmentJournal);
        }

        private void ButtonOfSettings_Click(object sender, EventArgs e)
        {
            var userSettings = new SettingsForm(userLogin);
            FH.OpenForm(this, userSettings);
        }

        private void ButtonOfSupply_Click(object sender, EventArgs e)
        {
            var makingSupply = new MakeDeliveryForm(userLogin);
            FH.OpenForm(this, makingSupply);
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