using WarehousemanPanelForm;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Classes;

namespace MakingShipmentForm
{
    /// <summary>
    /// Форма оформления отгрузки
    /// </summary>
    public partial class MakingShipment : Form
    {
        readonly ApplicationContextDB db = new();

        readonly string userLogin;

        private readonly List<ShipmentItemRow> shipmentItems = [];

        /// <summary>
        /// Конструктор оформления отгрузки
        /// </summary>
        public MakingShipment(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            dataGridOfItems.EnableHeadersVisualStyles = false;

            LoadClients();
            LoadProducts();

            buttonMakeShipment.Enabled = false;
        }

        private void LoadClients()
        {
            var clients = db.Clients
                .Select(c => new ClientComboItem { Client_Id = c.Client_Id, Display = c.Name })
                .ToList();

            comboBoxRecipient.DataSource = clients;
            comboBoxRecipient.DisplayMember = Resources.RecipientDisplayMember;
            comboBoxRecipient.ValueMember = Resources.RecipientValueMember;
        }

        private void LoadProducts()
        {
            var products = db.Products
                .Select(p => new ProductComboItem
                {
                    Article = p.Article,
                    Display = $"{p.Article} – {p.Name}",
                    StockQuantity = p.StockQuantity,
                    PurchasePrice = p.PurchasePrice
                })
                .ToList();

            comboBoxProduct.DataSource = products;
            comboBoxProduct.DisplayMember = Resources.ProductDisplayMember;
            comboBoxProduct.ValueMember = Resources.ProductValueMember;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (comboBoxRecipient.SelectedValue == null || comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show(Resources.FillRequiredFields,
                    Resources.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string article = comboBoxProduct.SelectedValue.ToString()!;
            var product = db.Products.FirstOrDefault(p => p.Article == article);

            if (product == null)
            {
                return;
            }

            int quantity = (int)numericQuantity.Value;

            int alreadyAdded = shipmentItems
                .Where(i => i.Article == article)
                .Sum(i => i.Quantity);

            if (alreadyAdded + quantity > product.StockQuantity)
            {
                MessageBox.Show(
                    $"{Resources.NotEnoughProductInStock}.\nДоступно: {product.StockQuantity - alreadyAdded} шт.",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Guid clientId = Guid.Parse(comboBoxRecipient.SelectedValue.ToString()!);

            
            string clientName = db.Clients
                .FirstOrDefault(c => c.Client_Id == clientId)?.Name ?? "—";

            shipmentItems.Add(new ShipmentItemRow
            {
                Article = article,
                Name = product.Name,
                Quantity = quantity,
                ClientId = clientId,
                ClientName = clientName,
                PriceSnapshot = product.PurchasePrice
            });

            RefreshItemsGrid();
            buttonMakeShipment.Enabled = true;
        }

        private void RefreshItemsGrid()
        {
            dataGridOfItems.DataSource = null;
            dataGridOfItems.DataSource = shipmentItems
                .Select(i => new
                {
                    Артикул = i.Article,
                    Название = i.Name,
                    Количество = i.Quantity,
                    Получатель = i.ClientName
                })
                .ToList();
        }

        private void buttonMakeShipment_Click(object sender, EventArgs e)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

                if (user == null)
                {
                    MessageBox.Show(Resources.UserNotFound,
                        Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var clientId = shipmentItems.First().ClientId;

                var shipment = new Shipment
                {
                    Date = DateTime.Now,
                    Client_Id = clientId,
                    User_Id = user.User_Id
                };
                db.Shipments.Add(shipment);

                foreach (var item in shipmentItems)
                {
                    var product = db.Products.First(p => p.Article == item.Article);

                    db.ShipmentItems.Add(new ShipmentItems
                    {
                        Shipment_Id = shipment.Shipment_Id,
                        Product_Id = product.Product_Id,
                        PriceSnapshot = item.PriceSnapshot,
                        Quantity = item.Quantity
                    });

                    product.StockQuantity -= item.Quantity;
                }

                db.SaveChanges();

                MessageBox.Show(
                    $"{Resources.ShipmentSuccessfullyProcessed}\nДата: {shipment.Date:dd.MM.yy}",
                    Resources.TitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.ErrorSave} {ex.Message}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var warehousemanPanel = new WarehousemanPanel(userLogin);
            warehousemanPanel.ShowDialog();
            this.Close();
        }
    }

    /// <summary>
    /// Класс для работы с отгрузками
    /// </summary>
    public class ShipmentItemRow
    {
        public string Article { get; set; } = "";
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; } = "";
        public string? PriceSnapshot { get; set; }
    }

    /// <summary>
    /// Класс для работы с клиентами
    /// </summary>
    public class ClientComboItem
    {
        public Guid Client_Id { get; set; }
        public string Display { get; set; } = "";
    }

    /// <summary>
    /// Класс для работы с товарами
    /// </summary>
    public class ProductComboItem
    {
        public string Article { get; set; } = "";
        public string Display { get; set; } = "";
        public int StockQuantity { get; set; }
        public string? PurchasePrice { get; set; }
    }
}