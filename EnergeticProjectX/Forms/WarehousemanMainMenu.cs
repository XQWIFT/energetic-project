using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для реализации главного меню кладовщика.
    /// </summary>
    public partial class WarehousemanMainMenu : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы главного меню кладовщика.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public WarehousemanMainMenu(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUserData();

            ActiveControl = LabelOfCompanyName;
        }

        private void LoadUserData()
        {
            var user = EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted);

            if (user == null)
                return;

            LabelOfFullName.Text = $"{Resources.FullName}: {user.Surname} {user.Name} {user.Patronymic}";
        }

        private void ButtonOfChangePassword_Click(object sender, EventArgs e)
        {
            var userChangePassword = new ChangePasswordForm(userLogin);
            FH.OpenForm(this, userChangePassword);
        }

        private void ButtonOfLogOut_Click(object sender, EventArgs e)
        {
            FH.RedirectToAuthorization(this);
        }

        private void ButtonOfProductCatalog_Click(object sender, EventArgs e)
        {
            var productCatalog = new TableOfProducts(userLogin);
            FH.OpenForm(this, productCatalog);
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            var makingShipment = new MakeShipmentForm(userLogin);
            FH.OpenForm(this, makingShipment);
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
