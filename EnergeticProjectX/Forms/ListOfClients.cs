using AdministratorPanelForm;
using System.Data;
using AddClientForm;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Models;
using EditClientForm;
using EnergeticProjectX.Classes;

namespace ListOfClientsForm
{
    /// <summary>
    /// Класс для работы с таблицей клиентов
    /// </summary>
    public partial class ListOfClients : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly BindingSource bindingSource = [];

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для работы с таблицей клиентов
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public ListOfClients(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUsers();

            DataGridOfClients.SelectionChanged += DataGridOfClients_SelectionChanged!;
        }

        private void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = db.Clients
                    .Select(
                    u => new ClientDisplayModel
                    {
                        ClientCode = u.ClientCode!,
                        Name = u.Name!,
                        Contractor = u.Contractor!,
                        INN = u.INN!,
                        ContactInfo = u.ContactInfo,
                    }
                    ).ToList();

                DataGridOfClients.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                MessageBox.Show($"{Resources.HowMuchClientsUploaded} {db.Clients.Count()}", Resources.TitleInformation,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.ErrorUploadData}\n\nТекст ошибки: {ex.Message}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
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

        private void DataGridOfClients_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = DataGridOfClients.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string cellValue = cell.Value?.ToString() ?? Resources.Empty;
                string columnName = DataGridOfClients.Columns[e.ColumnIndex].HeaderText;

                string toolTipText = $"{columnName}: {cellValue}";
                cell.ToolTipText = toolTipText;
            }
        }

        private void DataGridOfClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridOfClients.Rows.Count)
            {
                DataGridOfClients.ClearSelection();

                DataGridOfClients.Rows[e.RowIndex].Selected = true;

                DataGridOfClients.CurrentCell = DataGridOfClients.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void DataGridOfClients_SelectionChanged(object sender, EventArgs e)
        {
            bool isFullRowSelected = false;

            if (DataGridOfClients.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridOfClients.SelectedRows[0];

                bool allCellsSelected = true;
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
            if (DataGridOfClients.CurrentRow != null)
            {
                DataGridViewRow selectedRow = DataGridOfClients.CurrentRow;

                string ClientCode = selectedRow.Cells[Resources.ClientRowCode].Value!.ToString()!;
                string Name = selectedRow.Cells[Resources.ClientRowName].Value!.ToString()!;
                string Contractor = selectedRow.Cells[Resources.ClientRowContractor].Value!.ToString()!;
                string Inn = selectedRow.Cells[Resources.ClientINN].Value!.ToString()!;
                string ContactInfo = selectedRow.Cells[Resources.ClientContactInfo].Value!.ToString()!;

                Hide();
                var editClient = new EditClient(userLogin, ClientCode, Name, Contractor, Inn, ContactInfo);
                editClient.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show(Resources.ChooseClientForEdit);
            }
        }
    }
}
