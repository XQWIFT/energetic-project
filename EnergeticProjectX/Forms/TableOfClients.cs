using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using System.Data;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Models;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для работы с таблицей клиентов.
    /// </summary>
    public partial class TableOfClients : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации работы формы с таблицей клиентов.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public TableOfClients(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                bindingSource.DataSource = Db.Clients.Where(c => c.Status == Status.Active)
                    .Select(u => new ClientDisplayModel
                    {
                        Name = u.Name!,
                        Contractor = EnumHandler.GetContractorType(u.Contractor!),
                        INN = u.INN!,
                        ContactInfo = u.ContactInfo,
                    })
                    .ToList();

                DGVOfClients.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                EH.ShowInformation($"{Resources.HowMuchClientsUploaded} {Db.Clients.Where(c => c.Status == Status.Active).Count()}");
            }
            catch (Exception)
            {
                EH.ShowError(Resources.ErrorUploadData, true);

                return;
            }
        }

        private void DGVOfClients_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DGVOfClients.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var cellValue = cell.Value?.ToString() ?? string.Empty;
                var columnName = DGVOfClients.Columns[e.ColumnIndex].HeaderText;

                var toolTipText = $"{columnName}: {cellValue}";
                cell.ToolTipText = toolTipText;
            }
        }

        private void DGVOfClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGVOfClients.Rows.Count)
            {
                DGVOfClients.ClearSelection();

                DGVOfClients.Rows[e.RowIndex].Selected = true;

                DGVOfClients.CurrentCell = DGVOfClients.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void DGVOfClients_SelectionChanged(object sender, EventArgs e)
        {
            var isFullRowSelected = false;

            if (DGVOfClients.SelectedRows.Count > 0)
            {
                var selectedRow = DGVOfClients.SelectedRows[0];

                var allCellsSelected = true;
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (!cell.Selected)
                    {
                        allCellsSelected = false;
                        break;
                    }
                }
                isFullRowSelected = allCellsSelected;
            }

            ButtonOfClient.Enabled = isFullRowSelected;
        }

        private void ButtonOfClient_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (DGVOfClients.CurrentRow != null)
            {
                var selectedRow = DGVOfClients.CurrentRow;

                var Name = selectedRow.Cells[nameof(Client.Name)].Value!.ToString()!;
                var Contractor = selectedRow.Cells[nameof(Client.Contractor)].Value!.ToString()!;
                var Inn = selectedRow.Cells[nameof(Client.INN)].Value!.ToString()!;
                var ClientId = Db.Clients.FirstOrDefault(u => u.INN == Inn)!.Client_Id;
                var ContactInfo = selectedRow.Cells[nameof(Client.ContactInfo)].Value!.ToString()!;

                var editClient = new EditClientForm(userLogin, ClientId, Name, Contractor, Inn, ContactInfo);
                FH.OpenForm(this, editClient);
            }
            else
            {
                EH.ShowAlert(Resources.ChooseClientToEditFirst);
            }
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var administratorMainMenu = new AdministratorMainMenu(userLogin);
            FH.OpenForm(this, administratorMainMenu);
        }

        private void ButtonOfAddClient_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var addClient = new AddClientForm(userLogin);
            FH.OpenForm(this, addClient);
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
