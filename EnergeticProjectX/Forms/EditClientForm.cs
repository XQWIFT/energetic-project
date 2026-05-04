using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Класс для редактирования данных клиента.
    /// </summary>
    public partial class EditClientForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

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
        public EditClientForm(string userLogin, Guid clientId, string name, string contractor, string iNN, string contactInfo)
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
        }

        private void IsTextChanged(object sender, EventArgs e)
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
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (!UIHelper.ValidateINN(TextBoxOfINN.Text.Trim(), ComboBoxOfContractor.Text))
            {
                EH.ShowWarning(UIHelper.GetINNErrorMessage(ComboBoxOfContractor.Text), true);

                TextBoxOfINN.Focus();
            }
            else if (Db.Clients.Any(u => u.INN == TextBoxOfINN.Text.Trim()))
            {
                EH.ShowWarning(Resources.InnAlreadyExists, true);

                TextBoxOfINN.Focus();
            }
            else
            {
                var client = Db.Clients.FirstOrDefault(u => u.Client_Id == clientId);

                if (client == null)
                {
                    EH.ShowError(Resources.ClientsLoadError, true);

                    return;
                }

                client.Name = TextBoxOfName.Text.Trim();
                client.Contractor = EnumHandler.SetContractorType(ComboBoxOfContractor.Text);
                client.INN = TextBoxOfINN.Text.Trim();
                client.Status = Status.Active;
                client.ContactInfo = TextBoxOfContactInfo.Text.Trim();

                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;

                OpenListOfClients();
            }
        }

        private void ButtonOfDeleteClient_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var answer = EH.ShowConfirmation($"{Resources.SureWantToDeleteClient} {name}?");

            if (answer == DialogResult.Yes)
            {
                var client = Db.Clients.FirstOrDefault(u => u.Client_Id == clientId);

                client?.Status = Status.Hidden;

                if (EH.DBSaveChangesUniversalErrorCheck(Db))
                    return;
            }
            else
            {
                OpenListOfClients();
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            OpenListOfClients();
        }

        private void OpenListOfClients()
        {
            var listOfClients = new TableOfClients(userLogin);
            FH.OpenForm(this, listOfClients);
        }

        private void TabSelection_Enter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = Color.LightSteelBlue;
            }
        }

        private void TabSelection_Leave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = Color.Transparent;
            }
        }
    }
}
