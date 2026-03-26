using EnergeticProjectX;
using ListOfClientsForm;
using ListOfUsersForm;
using ProductCatalogForm;
using UserChangePasswordForm;

namespace AdministratorPanelForm
{
    /// <summary>
    /// Главное меню администратора
    /// </summary>
    public partial class AdministratorPanel : Form
    {
        string userLogin;
        public AdministratorPanel(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
        }

        private void buttonOfChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            var changePassword = new UserChangePassword(userLogin);
            changePassword.ShowDialog();
            this.Close();
        }

        private void buttonListOfUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var listOfUsers = new ListOfUsers(userLogin);
            listOfUsers.ShowDialog();
            this.Close();
        }

        private void buttonOfLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var authForm = new AuthorizationForm();
            authForm.ShowDialog();
            this.Close();
        }

        private void buttonOfClients_Click(object sender, EventArgs e)
        {
            this.Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            this.Close();
        }

        private void buttonOfProductCatalog_Click(object sender, EventArgs e)
        {
            this.Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            this.Close();
        }
    }
}