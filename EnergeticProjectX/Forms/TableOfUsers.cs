using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Models;
using EnergeticProjectX.Classes;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для просмотра списка пользователей системы.
    /// </summary>
    public partial class TableOfUsers : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы просмотра таблицы пользователей системы.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public TableOfUsers(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            ActiveControl = DGVOfUsers;

            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = Db.Users
                    .Select(u => new UserDisplayModel
                    {
                        Surname = u.Surname,
                        Name = u.Name,
                        Patronymic = u.Patronymic,
                        UserRole = EnumHandler.GetUserRole(u.UserRole)
                    })
                    .ToList();

                DGVOfUsers.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                EH.ShowInformation($"{Resources.HowMuchUsersUploaded} {Db.Users.Count()}");
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

        private void ButtonOfAdministratorMainMenu_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var administratorMainMenu = new AdministratorMainMenu(userLogin);
            FH.OpenForm(this, administratorMainMenu);
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
