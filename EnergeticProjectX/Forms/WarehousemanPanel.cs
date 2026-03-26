using UserChangePasswordForm;
using EnergeticProjectX;

namespace WarehousemanPanelForm
{
    /// <summary>
    /// Главное меню кладовщика
    /// </summary>
    public partial class WarehousemanPanel : Form
    {
        string userLogin;
        public WarehousemanPanel(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
        }

        private void buttonOfChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            var userChangePassword = new UserChangePassword(userLogin);
            userChangePassword.ShowDialog();
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
