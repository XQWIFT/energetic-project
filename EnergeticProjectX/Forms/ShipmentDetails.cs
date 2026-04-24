using EnergeticProjectX.Classes;

namespace EnergeticProjectX.Forms
{
    public partial class ShipmentDetails : Form
    {
        private readonly ApplicationContextDB db = new();
        private readonly string userLogin;

        public ShipmentDetails(string userLogin, Guid selectedShipmentId)
        {
            InitializeComponent();

            this.userLogin = userLogin;
        }
    }
}
