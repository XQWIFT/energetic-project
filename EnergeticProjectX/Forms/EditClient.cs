using ClientManagementForm;
using DBControl;
using ListOfClientsForm;

namespace EditClientForm
{
    /// <summary>
    /// Редактирование клиента
    /// </summary>
    public partial class EditClient : Form
    {
        string userLogin;
        string client_Id;
        string name;
        string contractor;
        string inn;
        string contactInfo;

        public EditClient(string userLogin, string Client_Id, string Name,
            string Contractor, string Inn, string ContactInfo)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            client_Id = Client_Id;
            name = Name;
            contractor = Contractor;
            inn = Inn;
            contactInfo = ContactInfo;

            textBoxOfName.Text = name;
            comboBoxOfContractor.Text = contractor;
            textBoxOfINN.Text = inn;
            textBoxOfContactInfo.Text = contactInfo;

            textBoxOfName.TextChanged += TextBox_TextChanged!;
            comboBoxOfContractor.TextChanged += TextBox_TextChanged!;
            textBoxOfINN.TextChanged += TextBox_TextChanged!;
            textBoxOfContactInfo.TextChanged += TextBox_TextChanged!;

            buttonOfSaveChanges.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfContractor.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfINN.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfContactInfo.Text);

            bool hasChanges = textBoxOfName.Text != name ||
                      comboBoxOfContractor.Text != contractor ||
                      textBoxOfINN.Text != inn ||
                      textBoxOfContactInfo.Text != contactInfo;

            buttonOfSaveChanges.Enabled = allFieldsFilled && hasChanges;
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            this.Close();
        }

        private void buttonOfSaveChanges_Click(object sender, EventArgs e)
        {
            var db = new ApplicationContextDB();

            if (long.TryParse(client_Id, out long clientId))
            {
                var client = db.Clients.FirstOrDefault(u => u.Client_Id == clientId)!;
                client.Name = textBoxOfName.Text;
                client.Contractor = comboBoxOfContractor.Text;
                client.INN = textBoxOfINN.Text;
                client.ContactInfo = textBoxOfContactInfo.Text;
                
                db.SaveChanges();

                this.Hide();
                var listOfClients = new ListOfClients(userLogin);
                listOfClients.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный ID клиента!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
