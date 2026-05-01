using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для реализации главного меню кладовщика.
    /// </summary>
    public partial class WarehousemanPanel : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы главного меню кладовщика.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public WarehousemanPanel(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUserData();
        }

        private void LoadUserData()
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
            {
                EH.ShowError(Resources.UserNotFound, true);

                return;
            }

            LabelOfFullName.Text = $"{Resources.FullName}: {user.Surname} {user.Name} {user.Patronymic}";
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
            var userSettings = new Settings(userLogin);
            userSettings.ShowDialog();
            Close();
        }

        private void ButtonOfSupply_Click(object sender, EventArgs e)
        {
            Hide();
            var makingSupply = new MakingSupply(userLogin);
            makingSupply.ShowDialog();
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
