using UserChangePasswordForm;
using EnergeticProjectX;

namespace WarehousemanPanelForm
{
    public partial class WarehousemanPanel : Form
    {
        string userLogin;
        public WarehousemanPanel(string UserLogin)
        {
            InitializeComponent();
            userLogin = UserLogin;
        }

        private void buttonOfChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserChangePassword userChangePassword = new UserChangePassword(userLogin);
            userChangePassword.ShowDialog();
            this.Close();
        }

        private void buttonOfLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm authForm = new AuthorizationForm();
            authForm.ShowDialog();
            this.Close();
        }
    }
}
