using AdministratorPanelForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;

namespace ShipmentJournalForm
{
    /// <summary>
    /// Форма для реализации журнала отгрузок.
    /// </summary>
    public partial class ShipmentJournal : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private Guid? selectedShipmentId = null;

        /// <summary>
        /// Конструктор для создания журнала отгрузок.
        /// </summary>
        public ShipmentJournal(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadShipments();
        }

        private void LoadShipments()
        {
            try
            {
                var shipments = db.Shipments
                    .Select(s => new
                    {
                        s.Shipment_Id,
                        Оформил = db.Users
                            .Where(u => u.User_Id == s.User_Id)
                            .Select(u => u.Surname + " " + u.Name)
                            .FirstOrDefault() ?? "—",
                        Получатель = db.Clients
                            .Where(c => c.Client_Id == s.Client_Id)
                            .Select(c => c.Name)
                            .FirstOrDefault() ?? "—",
                        Дата = s.CreationDate.ToString("dd.MM.yy")
                    })
                    .ToList();

                DataGridOfShipments.DataSource = shipments;

                if (DataGridOfShipments.Columns.Contains(Resources.ShipmentId))
                    DataGridOfShipments.Columns[Resources.ShipmentId]!.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show($"Ошибка загрузки:", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridOfShipments_SelectionChanged(object sender, EventArgs e)
        {
            ButtonOfContent.Enabled = DataGridOfShipments.SelectedRows.Count > 0;
        }

        private void DataGridOfShipments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridOfShipments.Rows.Count)
            {
                DataGridOfShipments.ClearSelection();
                DataGridOfShipments.Rows[e.RowIndex].Selected = true;
                DataGridOfShipments.CurrentCell =
                    DataGridOfShipments.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var idCell = DataGridOfShipments.Rows[e.RowIndex].Cells[Resources.ShipmentId];
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

        private void ButtonOfContent_Click(object sender, EventArgs e)
        {
            if (selectedShipmentId == null) return;

            try
            {
                var items = db.ShipmentItems
                    .Where(i => i.Shipment_Id == selectedShipmentId)
                    .Select(i => new
                    {
                        Название = db.Products
                            .Where(p => p.Product_Id == i.Product_Id)
                            .Select(p => p.Name)
                            .FirstOrDefault() ?? "—",
                        Количество = i.Quantity
                    })
                    .ToList();

                DataGridOfContent.DataSource = items;
            }
            catch (Exception)
            {
                MessageBox.Show($"Ошибка загрузки содержимого:", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonOfMainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            var administratorPanel = new AdministratorPanel(userLogin);
            administratorPanel.ShowDialog();
            Close();
        }
    }
}