using UserChangePasswordForm;
using ListOfUsersForm;
using EnergeticProjectX;

namespace AdministratorPanelForm
{
    public partial class AdministratorPanel : Form
    {
        string userLogin;
        public AdministratorPanel(string UserLogin)
        {
            InitializeComponent();
            userLogin = UserLogin;
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
    }
}