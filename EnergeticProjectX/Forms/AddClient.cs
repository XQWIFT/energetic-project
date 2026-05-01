using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для добавления нового клиента.
    /// </summary>
    public partial class AddClient : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы добавления нового клиента.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AddClient(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfAddClient.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                        !string.IsNullOrWhiteSpace(ComboBoxOfContractor.Text) &&
                                        !string.IsNullOrWhiteSpace(TextBoxOfINN.Text);
        }

        private void ButtonOfAddClient_Click(object sender, EventArgs e)
        {
            var name = TextBoxOfName.Text.Trim();
            var contractor = ComboBoxOfContractor.Text;
            var iNN = TextBoxOfINN.Text.Trim();
            var contactInfo = TextBoxOfContactInfo.Text.Trim();

            if (!Client.ValidateINN(iNN, contractor))
            {
                EH.ShowWarning(Client.GetINNErrorMessage(contractor), true);

                return;
            }

            if (db.Clients.Any(u => u.INN == iNN))
            {
                EH.ShowWarning(Resources.InnAlreadyExists, true);

                return;
            }

            var client = new Client
            {
                Name = name,
                Contractor = (Contractors)EnumMethod.ParseDescriptionOfPotentialContractorsValue(contractor)!,
                INN = iNN,
                ContactInfo = contactInfo
            };

            db.Clients.Add(client);
            if (EH.DBSaveChangesUniversalErrorCheck(db))
                return;

            ReturnToListOfClients();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            ReturnToListOfClients();
        }

        private void ReturnToListOfClients()
        {
            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
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
