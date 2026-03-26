using AdministratorPanelForm;
using SelectClientDataForTable;
using System.Data;
using AddClientForm;
using ClientManagementForm;

namespace ListOfClientsForm
{
    /// <summary>
    /// Работа с таблицей клиентов
    /// </summary>
    public partial class ListOfClients : Form
    {
        DBControl.ApplicationContextDB context = new();
        BindingSource bindingSource = new BindingSource();
        string userLogin;
        public ListOfClients(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
            LoadUsers();

            dataGridOfClients.MultiSelect = false;
            dataGridOfClients.EnableHeadersVisualStyles = false;
            dataGridOfClients.SelectionChanged += DataGridOfClients_SelectionChanged!;
            buttonOfClient.Enabled = false;
        }

        private void LoadUsers()
        {
            try
            {
                bindingSource.DataSource = context.Clients
                    .Select(u => new ClientDisplayModel
                    {
                        Client_Id = u.Client_Id,
                        Name = u.Name,
                        Contractor = u.Contractor,
                        INN = u.INN,
                        ContactInfo = u.ContactInfo,
                    })
                    .ToList();
                dataGridOfClients.DataSource = bindingSource;
                bindingSource.ResetBindings(false);

                MessageBox.Show($"Загружено {context.Clients.Count()} клиентов",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOfMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdministratorPanel administratorPanel = new(userLogin);
            administratorPanel.ShowDialog();
            this.Close();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addClient = new AddClient(userLogin);
            addClient.ShowDialog();
            this.Close();
        }

        private void dataGridOfClients_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridOfClients.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string cellValue = cell.Value?.ToString() ?? "пусто";
                string columnName = dataGridOfClients.Columns[e.ColumnIndex].HeaderText;

                string tooltipText = $"{columnName}: {cellValue}";
                cell.ToolTipText = tooltipText;
            }
        }

        private void dataGridOfClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridOfClients.Rows.Count)
            {
                dataGridOfClients.ClearSelection();

                dataGridOfClients.Rows[e.RowIndex].Selected = true;

                dataGridOfClients.CurrentCell = dataGridOfClients.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void DataGridOfClients_SelectionChanged(object sender, EventArgs e)
        {
            bool isFullRowSelected = false;

            if (dataGridOfClients.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridOfClients.SelectedRows[0];

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

            buttonOfClient.Enabled = isFullRowSelected;
        }

        private void buttonOfClient_Click(object sender, EventArgs e)
        {
            if (dataGridOfClients.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridOfClients.CurrentRow;

                string Client_Id = selectedRow.Cells["Client_Id"].Value!.ToString()!;
                string Name = selectedRow.Cells["Name"].Value!.ToString()!;
                string Contractor = selectedRow.Cells["Contractor"].Value!.ToString()!;
                string Inn = selectedRow.Cells["INN"].Value!.ToString()!;
                string ContactInfo = selectedRow.Cells["ContactInfo"].Value!.ToString()!;

                this.Hide();
                СlientManagement сlientManagement = new СlientManagement(userLogin, Client_Id, Name,
                     Contractor, Inn, ContactInfo);
                сlientManagement.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования");
            }
        }
    }
}
