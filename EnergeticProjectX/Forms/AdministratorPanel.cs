using EnergeticProjectX;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using ListOfClientsForm;
using ListOfUsersForm;
using ProductCatalogForm;
using ShipmentJournalForm;
using UserChangePasswordForm;

namespace AdministratorPanelForm
{
    /// <summary>
    /// Класс для реализации главного меню администратора
    /// </summary>
    public partial class AdministratorPanel : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для главного меню администратора
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public AdministratorPanel(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            var dataOfUser = db.Users.FirstOrDefault(u => u.Login == userLogin);

            LabelOfFullName.Text = $"{Resources.FullName}: {dataOfUser!.Surname} {dataOfUser.Name} {dataOfUser.Patronymic}";
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
            var userSettings = new EnergeticProjectX.Forms.Settings(userLogin);
            userSettings.ShowDialog();
            Close();
        }
    }
}