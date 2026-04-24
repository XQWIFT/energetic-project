using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using ListOfClientsForm;

namespace AddClientForm
{
    /// <summary>
    /// Класс для добавления нового клиента
    /// </summary>
    public partial class AddClient : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор добавления нового клиента
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public AddClient(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            TextBoxOfName.TextChanged += TextBox_TextChanged!;
            ComboBoxOfContractor.TextChanged += TextBox_TextChanged!;
            TextBoxOfINN.TextChanged += TextBox_TextChanged!;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                  !string.IsNullOrWhiteSpace(ComboBoxOfContractor.Text) &&
                                  !string.IsNullOrWhiteSpace(TextBoxOfINN.Text);

            ButtonOfAddClient.Enabled = allFieldsFilled;
        }

        private void ButtonOfAddClient_Click(object sender, EventArgs e)
        {
            var name = TextBoxOfName.Text;
            var contractor = ComboBoxOfContractor.Text;
            var iNN = TextBoxOfINN.Text.Trim();
            var contactInfo = TextBoxOfContactInfo.Text;

            if (!Client.ValidateINN(iNN, contractor))
            {
                MessageBox.Show(Client.GetINNErrorMessage(contractor), Resources.ErrorValidation,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (db.Clients.Any(u => u.INN == iNN))
            {
                MessageBox.Show($"{Resources.INNAlreadyInDB}\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                return;

            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            Close();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            Close();
        }
    }
}
