using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using System.Text.RegularExpressions;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для добавления нового клиента.
    /// </summary>
    public partial class AddClientForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы добавления нового клиента.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AddClientForm(string userLogin)
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
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            var name = Regex.Replace(TextBoxOfName.Text.Trim(), @"\s+", " ");
            var contractor = Regex.Replace(ComboBoxOfContractor.Text.Trim(), @"\s+", " ");
            var iNN = Regex.Replace(TextBoxOfINN.Text.Trim(), @"\s+", " ");
            var contactInfo = Regex.Replace(TextBoxOfContactInfo.Text.Trim(), @"\s+", " ");

            if (!UIHelper.ValidateINN(iNN, contractor))
            {
                EH.ShowWarning(UIHelper.GetINNErrorMessage(contractor), true);

                return;
            }

            if (Db.Clients.Any(u => u.INN == iNN))
            {
                EH.ShowWarning(Resources.InnAlreadyExists, true);

                return;
            }

            var client = new Client
            {
                Name = name,
                Contractor = EnumHandler.SetContractorType(contractor),
                INN = iNN,
                ContactInfo = contactInfo
            };

            Db.Clients.Add(client);
            if (EH.DBSaveChangesUniversalErrorCheck(Db))
                return;

            OpenListOfClients();
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
