using AdministratorPanelForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;

namespace ShipmentJournalForm
{
    /// <summary>
    /// Форма для журнала отгрузок
    /// </summary>
    public partial class ShipmentJournal : Form
    {
        ApplicationContextDB context = new();

        string userLogin;

        private Guid? selectedShipmentId = null;

        /// <summary>
        /// Конструктор для журнала отгрузок
        /// </summary>
        public ShipmentJournal(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            dataGridOfShipments.EnableHeadersVisualStyles = false;

            LoadShipments();
        }

        private void LoadShipments()
        {
            try
            {
                var shipments = context.Shipments
                    .Select(s => new
                    {
                        s.Shipment_Id,
                        Оформил = context.Users
                            .Where(u => u.User_Id == s.User_Id)
                            .Select(u => u.Surname + " " + u.Name)
                            .FirstOrDefault() ?? "—",
                        Получатель = context.Clients
                            .Where(c => c.Client_Id == s.Client_Id)
                            .Select(c => c.Name)
                            .FirstOrDefault() ?? "—",
                        Дата = s.Date.ToString("dd.MM.yy")
                    })
                    .ToList();

                dataGridOfShipments.DataSource = shipments;

                if (dataGridOfShipments.Columns.Contains(Resources.ShipmentId))
                    dataGridOfShipments.Columns[Resources.ShipmentId]!.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridOfShipments_SelectionChanged(object sender, EventArgs e)
        {
            buttonOfContent.Enabled = dataGridOfShipments.SelectedRows.Count > 0;
        }

        private void dataGridOfShipments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridOfShipments.Rows.Count)
            {
                dataGridOfShipments.ClearSelection();
                dataGridOfShipments.Rows[e.RowIndex].Selected = true;
                dataGridOfShipments.CurrentCell =
                    dataGridOfShipments.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var idCell = dataGridOfShipments.Rows[e.RowIndex].Cells[Resources.ShipmentId];
                if (idCell.Value != null)
                {
                    if (Guid.TryParse(idCell.Value.ToString(), out Guid guidIdCell))
                    {
                        selectedShipmentId = guidIdCell;
                    }
                    else
                    {
                        MessageBox.Show(Resources.InvalidGUIDFormat, Resources.TitleError, 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonOfContent_Click(object sender, EventArgs e)
        {
            if (selectedShipmentId == null) return;

            try
            {
                var items = context.ShipmentItems
                    .Where(i => i.Shipment_Id == selectedShipmentId)
                    .Select(i => new
                    {
                        Название = context.Products
                            .Where(p => p.Product_Id == i.Product_Id)
                            .Select(p => p.Name)
                            .FirstOrDefault() ?? "—",
                        Количество = i.Quantity
                    })
                    .ToList();

                dataGridOfContent.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки содержимого: {ex.Message}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOfMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdministratorPanel administratorPanel = new(userLogin);
            administratorPanel.ShowDialog();
            this.Close();
        }
    }
}