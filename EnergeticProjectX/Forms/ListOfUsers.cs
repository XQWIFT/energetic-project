using AdministratorPanelForm;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Models;
using EnergeticProjectX.Classes;

namespace ListOfUsersForm
{
    /// <summary>
    /// Класс для просмотра списка пользователей системы
    /// </summary>
    public partial class ListOfUsers : Form
    {
        private readonly ApplicationContextDB contextOfUser = new();
        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для просмотра таблицы пользователей системыv
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public ListOfUsers(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUsers();
        }

        /// <summary>
        /// Загрузка данных пользователей в таблицу
        /// </summary>
        public void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = contextOfUser.Users
                    .Select(u => new UserDisplayModel
                    {
                        Surname = u.Surname,
                        Name = u.Name,
                        Patronymic = u.Patronymic,
                        UserRole = u.UserRole.GetDescriptionOfEnumValue()
                    })
                    .ToList();

                DataGridOfUsers.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                MessageBox.Show($"{Resources.HowMuchUsersUploaded} {contextOfUser.Users.Count()}", Resources.TitleInformation,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.ErrorUploadData}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ReturnToAdministratorPanel_Click(object sender, EventArgs e)
        {
            Hide();
            var administratorPanel = new AdministratorPanel(userLogin);
            administratorPanel.ShowDialog();
            Close();
        }
    }
}
