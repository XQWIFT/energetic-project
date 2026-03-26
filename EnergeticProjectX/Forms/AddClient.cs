using ClientControl;
using DBControl;
using ListOfClientsForm;
using GeneratedCode;

namespace AddClientForm
{
    /// <summary>
    /// Добавление клиента в БД
    /// </summary>
    public partial class AddClient : Form
    {
        string userLogin;
        public AddClient(string UserLogin)
        {
            InitializeComponent();

            userLogin = UserLogin;

            textBoxOfName.TextChanged += TextBox_TextChanged!;
            comboBoxOfContractor.TextChanged += TextBox_TextChanged!;
            textBoxOfINN.TextChanged += TextBox_TextChanged!;
            textBoxOfContactInfo.TextChanged += TextBox_TextChanged!;

            buttonOfAdd.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfContractor.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfINN.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfContactInfo.Text);

            buttonOfAdd.Enabled = allFieldsFilled;
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            this.Close();
        }

        private void buttonOfAdd_Click(object sender, EventArgs e)
        {
            var name = textBoxOfName.Text;
            var contractor = comboBoxOfContractor.Text;
            var inn = textBoxOfINN.Text;
            var contactInfo = textBoxOfContactInfo.Text;

            var db = new ApplicationContextDB();
            var client = new Client();
            var generateUniqueCode = new GenerateUniqueCode();

            client.Name = name;
            for (int i = 0; i < 100; i++)
            {
                var codes = "K" + generateUniqueCode.Generate6();
                if (!client.ClientCode.Contains(codes))
                {
                    break;
                }

                client.ClientCode = codes;
            }
            
            client.Contractor = contractor;
            client.INN = inn;
            client.ContactInfo = contactInfo;

            db.Clients.Add(client);
            db.SaveChanges();

            this.Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            this.Close();
        }
    }
}
