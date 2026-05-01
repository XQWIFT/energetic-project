using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Models;
using EnergeticProjectX.Classes;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для просмотра списка пользователей системы.
    /// </summary>
    public partial class ListOfUsers : Form
    {
        private readonly ApplicationContextDB contextOfUser = new();

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы просмотра таблицы пользователей системы.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
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
                        Surname = u.Surname,
                        Name = u.Name,
                        Patronymic = u.Patronymic,
                        UserRole = u.UserRole.GetDescriptionOfEnumValue()
                    })
                    .ToList();

                DGVOfUsers.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                EH.ShowInformation($"{Resources.HowMuchUsersUploaded} {contextOfUser.Users.Count()}");
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void DGVOfUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DGVOfUsers.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? string.Empty;
                var columnName = DGVOfUsers.Columns[e.ColumnIndex].HeaderText;

                var toolTipText = $"{columnName}: {cellValue}";
                cell.ToolTipText = toolTipText;
            }
        }

        private void DGVOfUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGVOfUsers.Rows.Count)
            {
                DGVOfUsers.ClearSelection();

                DGVOfUsers.Rows[e.RowIndex].Selected = true;

                DGVOfUsers.CurrentCell = DGVOfUsers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void ReturnToAdministratorPanel_Click(object sender, EventArgs e)
        {
            Hide();
            var administratorPanel = new AdministratorPanel(userLogin);
            administratorPanel.ShowDialog();
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
