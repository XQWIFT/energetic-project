using AdministratorPanelForm;
using DBControl;
using SelectUserDataForTable;

namespace ListOfUsersForm
{
    /// <summary>
    /// Работа с таблицей пользователей
    /// </summary>
    public partial class ListOfUsers : Form
    {
        DBControl.ApplicationContextDB contextOfUser = new();
        BindingSource bindingSource = new BindingSource();
        string userLogin;

        public ListOfUsers(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
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
