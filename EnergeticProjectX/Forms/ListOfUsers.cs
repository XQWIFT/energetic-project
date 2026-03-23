using AdministratorPanelForm;
using DbOfUser;
using SelectDataForTable;

namespace ListOfUsersForm
{
    public partial class ListOfUsers : Form
    {
        ApplicationContextOfUser contextOfUser = new ApplicationContextOfUser();
        BindingSource bindingSource = new BindingSource();
        string userLogin;

        public ListOfUsers(string UserLogin)
        {
            InitializeComponent();
            userLogin = UserLogin;
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = contextOfUser.Users
                    .Select(u => new UserDisplayModel
                    {
                        User_Id = u.User_Id,
                        Name = u.Name,
                        Surname = u.Surname,
                        Patronymic = u.Patronymic,
                        UserRole = u.UserRole
                    })
                    .ToList();
                dataGridOfUsers.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                MessageBox.Show($"Загружено {contextOfUser.Users.Count()} пользователей",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnToAdministratorPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdministratorPanel administratorPanel = new(userLogin);
            administratorPanel.ShowDialog();
            this.Close();
        }
    }
}
