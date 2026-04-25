using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Enums;
using ListOfClientsForm;
using Microsoft.EntityFrameworkCore;

namespace EditClientForm
{
    /// <summary>
    /// Класс для редактирования данных клиента.
    /// </summary>
    public partial class EditClient : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;
        private readonly Guid clientId;
        private readonly string name;
        private readonly string contractor;
        private readonly string iNN;
        private readonly string contactInfo;

        /// <summary>
        /// Конструктор для редактирования данных клиента.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        /// <param name="name">Название клиентской организации, ФИО клиента и т.п.</param>
        /// <param name="contractor">Контрагент.</param>
        /// <param name="iNN">Идентификационный номер клиента.</param>
        /// <param name="contactInfo">Контактная информация.</param>
        public EditClient(string userLogin, Guid clientId, string name, string contractor, string iNN, string contactInfo)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            this.clientId = clientId;
            this.name = name;
            this.contractor = contractor;
            this.iNN = iNN;
            this.contactInfo = contactInfo;

            TextBoxOfName.Text = this.name;
            ComboBoxOfContractor.Text = this.contractor;
            TextBoxOfINN.Text = this.iNN;
            TextBoxOfContactInfo.Text = this.contactInfo;

            TextBoxOfName.TextChanged += TextBox_TextChanged!;
            ComboBoxOfContractor.TextChanged += TextBox_TextChanged!;
            TextBoxOfINN.TextChanged += TextBox_TextChanged!;
            TextBoxOfContactInfo.TextChanged += TextBox_TextChanged!;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                  !string.IsNullOrWhiteSpace(ComboBoxOfContractor.Text) &&
                                  !string.IsNullOrWhiteSpace(TextBoxOfINN.Text);

            var hasChanges = TextBoxOfName.Text != name ||
                             ComboBoxOfContractor.Text != contractor ||
                             TextBoxOfINN.Text != iNN ||
                             TextBoxOfContactInfo.Text != contactInfo;

            ButtonOfSaveChanges.Enabled = allFieldsFilled && hasChanges;
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (!Client.ValidateINN(TextBoxOfINN.Text.Trim(), ComboBoxOfContractor.Text))
            {
                EH.ShowWarning($"{Client.GetINNErrorMessage(ComboBoxOfContractor.Text)}\n{Resources.TryAgain}");

                TextBoxOfINN.Focus();
            }
            else if (db.Clients.Any(u => u.INN == TextBoxOfINN.Text.Trim()))
            {
                EH.ShowWarning($"{Resources.INNAlreadyInDB}\n{Resources.TryAgain}");

                TextBoxOfINN.Focus();
            }
            else
            {
                var client = db.Clients.FirstOrDefault(u => u.Client_Id == clientId)!;
                client.Name = TextBoxOfName.Text.Trim();
                client.Contractor = (Contractors)EnumMethod.ParseDescriptionOfPotentialContractorsValue(ComboBoxOfContractor.Text)!;
                client.INN = TextBoxOfINN.Text.Trim();
                client.ContactInfo = TextBoxOfContactInfo.Text.Trim();

                EH.DBSaveChangesUniversalErrorCheck(db);

                Hide();
                var listOfClients = new ListOfClients(userLogin);
                listOfClients.ShowDialog();
                Close();
            }
        }

        private void ButtonOfDeleteClient_Click(object sender, EventArgs e)
        {
            var answer = EH.ShowConfirmation($"{Resources.SureWantToDeleteClient}\n{name}?\n\n{Resources.ConsequencesIfDeleteClient}");

            if (answer == DialogResult.Yes)
            {
                try
                {
                    var client = db.Clients.Where(u => u.Client_Id == clientId)!.ExecuteDelete();

                    Hide();
                    var listOfClients = new ListOfClients(userLogin);
                    listOfClients.ShowDialog();
                    Close();
                }
                catch (Exception)
                {
                    EH.ShowError(Resources.ErrorClientDelete);

                    return;
                }
            }
            else
            {
                Hide();
                var listOfClients = new ListOfClients(userLogin);
                listOfClients.ShowDialog();
                Close();
            }
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
