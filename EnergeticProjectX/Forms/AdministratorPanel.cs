using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для главного меню администратора.
    /// </summary>
    public partial class AdministratorPanel : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы главного меню администратора.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AdministratorPanel(string userLogin)
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
            var changePassword = new UserChangePassword(userLogin);
            changePassword.ShowDialog();
            Close();
        }

        private void ButtonListOfUsers_Click(object sender, EventArgs e)
        {
            Hide();
            var listOfUsers = new ListOfUsers(userLogin);
            listOfUsers.ShowDialog();
            Close();
        }

        private void ButtonOfLogOut_Click(object sender, EventArgs e)
        {
            Hide();
            var authForm = new AuthorizationForm();
            authForm.ShowDialog();
            Close();
        }

        private void ButtonOfClients_Click(object sender, EventArgs e)
        {
            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            Close();
        }

        private void ButtonOfProductCatalog_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void ButtonOfShipmentLog_Click(object sender, EventArgs e)
        {
            Hide();
            var shipmentJournal = new ShipmentJournal(userLogin);
            shipmentJournal.ShowDialog();
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