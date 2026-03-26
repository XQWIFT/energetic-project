using ClientControl;
using DBControl;
using EditClientForm;
using ListOfClientsForm;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementForm
{
    /// <summary>
    /// Работа по изменению данных клиента
    /// </summary>
    public partial class СlientManagement : Form
    {
        string userLogin;
        string client_Id;
        string name;
        string contractor;
        string inn;
        string contactInfo;

        public СlientManagement(string userLogin, string Client_Id, string Name,
            string Contractor, string Inn, string ContactInfo)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            client_Id = Client_Id;
            name = Name;
            contractor = Contractor;
            inn = Inn;
            contactInfo = ContactInfo;
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            this.Close();
        }

        private void buttonOfEditClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditClient editClient = new EditClient(userLogin, client_Id, name,
                     contractor, inn, contactInfo);
            editClient.ShowDialog();
            this.Close();
        }

        private void buttonOfDeleteClient_Click(object sender, EventArgs e)
        {
            var db = new ApplicationContextDB();
            var answer = MessageBox.Show($"Вы действительно хотите удалить клиента: {name}?", 
                "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (answer == DialogResult.Yes)
            {
                if (long.TryParse(client_Id, out long clientId))
                {
                    var client = db.Clients.Where(u => u.Client_Id == clientId)!
                        .ExecuteDelete();
                    

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
            else
            {
                this.Hide();
                var listOfClients = new ListOfClients(userLogin);
                listOfClients.ShowDialog();
                this.Close();
            }
        }
    }
}
