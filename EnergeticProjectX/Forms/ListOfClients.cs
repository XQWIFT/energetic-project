using EH = EnergeticProjectX.Classes.ErrorHandler;
using System.Data;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Models;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для работы с таблицей клиентов.
    /// </summary>
    public partial class ListOfClients : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации работы формы с таблицей клиентов.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public ListOfClients(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = db.Clients
                    .Select(u => new ClientDisplayModel
                    {
                        Name = u.Name!,
                        Contractor = u.Contractor!.GetDescriptionOfEnumValue(),
                        INN = u.INN!,
                        ContactInfo = u.ContactInfo,
                    })
                    .ToList();

                DGVOfClients.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                EH.ShowInformation($"{Resources.HowMuchClientsUploaded} {db.Clients.Count()}");
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
            if (DGVOfClients.CurrentRow != null)
            {
                var selectedRow = DGVOfClients.CurrentRow;

                var Name = selectedRow.Cells[nameof(Client.Name)].Value!.ToString()!;
                var Contractor = selectedRow.Cells[nameof(Client.Contractor)].Value!.ToString()!;
                var Inn = selectedRow.Cells[nameof(Client.INN)].Value!.ToString()!;
                var ClientId = db.Clients.FirstOrDefault(u => u.INN == Inn)!.Client_Id;
                var ContactInfo = selectedRow.Cells[nameof(Client.ContactInfo)].Value!.ToString()!;

                Hide();
                var editClient = new EditClient(userLogin, ClientId, Name, Contractor, Inn, ContactInfo);
                editClient.ShowDialog();
                Close();
            }
            else
            {
                EH.ShowAlert(Resources.ChooseClientToEditFirst);
            }
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            var administratorPanel = new AdministratorPanel(userLogin);
            administratorPanel.ShowDialog();
            Close();
        }

        private void ButtonOfAddClient_Click(object sender, EventArgs e)
        {
            Hide();
            var addClient = new AddClient(userLogin);
            addClient.ShowDialog();
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
