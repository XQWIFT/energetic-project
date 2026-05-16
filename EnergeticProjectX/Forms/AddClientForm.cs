using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;
using CHK = EnergeticProjectX.Classes.Chekouts;
using System.Text.RegularExpressions;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.interfaces;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для добавления нового клиента.
    /// </summary>
    public partial class AddClientForm : Form
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly IClientService _clientService;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации формы добавления нового клиента.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public AddClientForm(string userLogin, IUserService userService, IClientService clientService, IProductService productService)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            _userService = userService;
            _clientService = clientService;
            _productService = productService;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfAddClient.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfName.Text) &&
                                        !string.IsNullOrWhiteSpace(ComboBoxOfContractor.Text) &&
                                        !string.IsNullOrWhiteSpace(TextBoxOfINN.Text);
        }

        private void ButtonOfAddClient_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            var name = Regex.Replace(TextBoxOfName.Text.Trim(), @"\s+", " ");
            var contractor = Regex.Replace(ComboBoxOfContractor.Text.Trim(), @"\s+", " ");
            var iNN = Regex.Replace(TextBoxOfINN.Text.Trim(), @"\s+", " ");
            var contactInfo = Regex.Replace(TextBoxOfContactInfo.Text.Trim(), @"\s+", " ");

            if (!UIHelper.ValidateINN(iNN, contractor))
            {
                EH.ShowWarning(UIHelper.GetINNErrorMessage(contractor), true);

                return;
            }

            if (_clientService.FindClientByINN(iNN) != null)
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

            _clientService.AddClient(client);
            if (_userService.EnsureUserActive(userLogin) == null)
            {
                EH.ShowError(Resources.CurrentSessionWasInterruptedOrUserWasDeleted, true);
                return;
            }

            OpenListOfClients();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            if (_userService.EnsureUserActive(userLogin) == null)
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

        private void TextBoxOfINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            CHK.CheckOnlyNumber(e);
        }

        private void ButtonOfChekByINN_Click(object sender, EventArgs e)
        {
            EH.ShowAlert(Resources.NewFuncIsInProgress);

            return;
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
