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
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        private readonly List<ShipmentItemRow> shipmentItems = [];

        /// <summary>
        /// Конструктор оформления отгрузки
        /// </summary>
        public MakingShipment(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadClients();
            LoadProducts();
        }

        private void LoadClients()
        {
            var clients = db.Clients
                .Select(c => new ClientComboItem { Client_Id = c.Client_Id, Display = c.Name })
                .ToList();

            ComboBoxRecipient.DataSource = clients;
            ComboBoxRecipient.DisplayMember = Resources.RecipientDisplayMember;
            ComboBoxRecipient.ValueMember = Resources.RecipientValueMember;
        }

        private void LoadProducts()
        {
            var products = db.Products
                .Select(p => new ProductComboItem
                {
                    Article = p.Article,
                    Display = $"{p.Article} – {p.Name}",
                    StockQuantity = p.StockQuantity
                })
                .ToList();

            ComboBoxProduct.DataSource = products;
            ComboBoxProduct.DisplayMember = Resources.ProductDisplayMember;
            ComboBoxProduct.ValueMember = Resources.ProductValueMember;
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if (ComboBoxRecipient.SelectedValue == null || ComboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show(Resources.FillRequiredFields,
                    Resources.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string article = ComboBoxProduct.SelectedValue.ToString()!;
            var product = db.Products.FirstOrDefault(p => p.Article == article);

            if (product == null)
            {
                return;
            }

            int quantity = (int)NumericQuantity.Value;

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

            Guid clientId = Guid.Parse(ComboBoxRecipient.SelectedValue.ToString()!);

            
            string clientName = db.Clients
                .FirstOrDefault(c => c.Client_Id == clientId)?.Name ?? "—";

            shipmentItems.Add(new ShipmentItemRow
            {
                Article = article,
                Name = product.Name,
                Quantity = quantity,
                ClientId = clientId,
                ClientName = clientName,
                PriceSnapshot = product.PurchasePrice.ToString()
            });

            RefreshItemsGrid();
            ButtonOfMakingShipment.Enabled = true;
        }

        private void RefreshItemsGrid()
        {
            DataGridOfItems.DataSource = null;
            DataGridOfItems.DataSource = shipmentItems
                .Select(i => new
                {
                    Артикул = i.Article,
                    Название = i.Name,
                    Количество = i.Quantity,
                    Получатель = i.ClientName
                })
                .ToList();
        }

        private void ButtonMakeShipment_Click(object sender, EventArgs e)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

                if (user == null)
                {
                    MessageBox.Show(Resources.UserNotFound, Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var clientId = shipmentItems.First().ClientId;

                var shipment = new Shipment
                {
                    CreationDate = DateTime.Now,
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
                        FixedSalePrice = decimal.Parse(item.PriceSnapshot!),
                        Quantity = item.Quantity
                    });

                    product.StockQuantity -= item.Quantity;
                }

                if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                    return;

                MessageBox.Show($"{Resources.ShipmentSuccessfullyProcessed}\nДата: {shipment.CreationDate:dd.MM.yy}",
                                Resources.TitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                var warehousemanPanel = new WarehousemanPanel(userLogin);
                warehousemanPanel.ShowDialog();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.ErrorSave}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var warehousemanPanel = new WarehousemanPanel(userLogin);
            warehousemanPanel.ShowDialog();
            Close();
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