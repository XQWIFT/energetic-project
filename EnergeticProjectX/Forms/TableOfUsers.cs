using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Properties;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для просмотра списка пользователей системы.
    /// </summary>
    public partial class TableOfUsers : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы просмотра таблицы пользователей системы.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public TableOfUsers(string userLogin, IClientService clientService, IUserService userService, IProductService productService)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            _userService = userService;

            _productService = productService;

            _clientService = clientService;

            ActiveControl = DGVOfUsers;

            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = _userService.DisplayUsers();

                DGVOfUsers.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                EH.ShowInformation($"{Resources.HowMuchUsersUploaded} {_userService.GetAllUsersCount()}");
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
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted);
                return;
            }

            var administratorMainMenu = new AdministratorMainMenu(userLogin, _userService, _clientService, _productService);
            FH.OpenForm(this, administratorMainMenu);
        }

        private void ButtonOfUserData_Click(object sender, EventArgs e)
        {
            EH.ShowAlert(Resources.NewFuncIsInProgress);

            return;
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
