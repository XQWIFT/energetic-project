using UserChangePasswordForm;
using EnergeticProjectX;
using ProductCatalogForm;
using MakingShipmentForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;

namespace WarehousemanPanelForm
{
    /// <summary>
    /// Класс для реализации главного меню кладовщика
    /// </summary>
    public partial class WarehousemanPanel : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для главного меню кладовщика
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public WarehousemanPanel(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            var dataOfUser = db.Users.FirstOrDefault(u => u.Login == userLogin);

            labelOfFullName.Text = $"{Resources.FullName}: {dataOfUser!.Surname} {dataOfUser.Name} {dataOfUser.Patronymic}";
        }

        private void ButtonOfChangePassword_Click(object sender, EventArgs e)
        {
            Hide();
            var userChangePassword = new UserChangePassword(userLogin);
            userChangePassword.ShowDialog();
            Close();
        }

        private void ButtonOfLogOut_Click(object sender, EventArgs e)
        {
            Hide();
            var authForm = new AuthorizationForm();
            authForm.ShowDialog();
            Close();
        }

        private void ButtonOfProductCatalog_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void ButtonOfMakingShipment_Click(object sender, EventArgs e)
        {
            Hide();
            var makingShipment = new MakingShipment(userLogin);
            makingShipment.ShowDialog();
            Close();
        }

        private void ButtonOfSettings_Click(object sender, EventArgs e)
        {
            Hide();
            var userSettings = new EnergeticProjectX.Forms.Settings(userLogin);
            userSettings.ShowDialog();
            Close();
        }
    }
}
