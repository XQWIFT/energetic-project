using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using CHK = EnergeticProjectX.Classes.Chekouts;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using System.Text.RegularExpressions;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Класс для редактирования данных клиента.
    /// </summary>
    public partial class EditClientForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

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
        public EditClientForm(string userLogin, Guid clientId, string name, string contractor, string iNN,
            string contactInfo, IClientService clientService, IUserService userService, IProductService productService)
        {
            InitializeComponent();

            _clientService = clientService;

            _userService = userService;

            _productService = productService;

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
            if (_userService.EnsureUserActive == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            if (!UIHelper.ValidateINN(TextBoxOfINN.Text.Trim(), ComboBoxOfContractor.Text))
            {
                EH.ShowWarning(UIHelper.GetINNErrorMessage(ComboBoxOfContractor.Text), true);

                TextBoxOfINN.Focus();
            }
            else if (iNN != TextBoxOfINN.Text.ToString())
            {
                if (_clientService.FindClientByINN(iNN) != null)
                {
                    EH.ShowWarning(Resources.InnAlreadyExists, true);

                    TextBoxOfINN.Focus();
                }
                else
                {
                    ChangeUser();
                }
            }
            else
            {
                ChangeUser();
            }
        }

        private void ButtonOfDeleteClient_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            var answer = EH.ShowConfirmation($"{Resources.SureWantToDeleteClient} {name}?");

            if (answer == DialogResult.Yes)
            {
                var client = _clientService.FindClientById(clientId);

                client?.Status = Status.Hidden;

                if (_userService.DbSaveChangesErrorCheck())
                {
                    EH.ShowError(Resources.UniversalErrorDatabase, true);
                    return;
                }

            }
            else
            {
                OpenListOfClients();
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }
            OpenListOfClients();
        }

        private void OpenListOfClients()
        {
            var listOfClients = new TableOfClients(userLogin, _userService, _clientService, _productService);
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

        private void TextBoxOfINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            CHK.CheckOnlyNumber(e);
        }

        private void ChangeUser()
        {
            var client = _clientService.FindClientById(clientId);

            if (client == null)
            {
                EH.ShowError(Resources.ClientsLoadError, true);

                return;
            }

            client.Name = Regex.Replace(TextBoxOfName.Text, @"\s+", " ");
            client.Contractor = EnumHandler.SetContractorType(ComboBoxOfContractor.Text);
            client.INN = TextBoxOfINN.Text.Trim();
            client.Status = Status.Active;
            client.ContactInfo = Regex.Replace(TextBoxOfContactInfo.Text, @"\s+", " ");

            if (_userService.DbSaveChangesErrorCheck())
            {
                EH.ShowError(Resources.UniversalErrorDatabase, true);
                return;
            }

            OpenListOfClients();
        }

        private void ButtonOfCheckByINN_Click(object sender, EventArgs e)
        {
            EH.ShowAlert(Resources.NewFuncIsInProgress);

            return;
        }
    }
}