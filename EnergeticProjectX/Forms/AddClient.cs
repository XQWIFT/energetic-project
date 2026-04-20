using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using ListOfClientsForm;
using System.Text.RegularExpressions;

namespace AddClientForm
{
    /// <summary>
    /// Класс для добавления нового клиента
    /// </summary>
    public partial class AddClient : Form
    {
        readonly ApplicationContextDB db = new();

        readonly string userLogin;

        /// <summary>
        /// Конструктор добавления нового клиента
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        public AddClient(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            textBoxOfName.TextChanged += TextBox_TextChanged!;
            comboBoxOfContractor.TextChanged += TextBox_TextChanged!;
            textBoxOfINN.TextChanged += TextBox_TextChanged!;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfContractor.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfINN.Text);

            ButtonOfAddClient.Enabled = allFieldsFilled;
        }

        /// <summary>
        /// Валидация вводимого пользователем ИНН
        /// </summary>
        /// <param name="iNN">Идентификационный номер нового клиента</param>
        /// <param name="contractorType">Контрагент</param>
        /// <returns>Подтверждение валидации</returns>
        public static bool ValidateINN(string iNN, string contractorType)
        {
            if (string.IsNullOrWhiteSpace(iNN))
                return false;

            iNN = iNN.Replace(" ", "");

#pragma warning disable SYSLIB1045 // Преобразовать в "GeneratedRegexAttribute".
            if (!Regex.IsMatch(iNN, @"^\d+$"))
                return false;
#pragma warning restore SYSLIB1045 // Преобразовать в "GeneratedRegexAttribute".

            if (contractorType == Resources.ClientContractorLegalEntity)
                return iNN.Length == 10;
            else if (contractorType == Resources.ClientContractorPhysicalPerson ||
                     contractorType == Resources.ClientContractorIndEntrepreneur)
                return iNN.Length == 12;

            return false;
        }

        private static string GetINNErrorMessage(string contractorType)
        {
            if (contractorType == Resources.ClientContractorLegalEntity)
                return Resources.INNRequirementsTenDigits;
            else if (contractorType == Resources.ClientContractorPhysicalPerson ||
                     contractorType == Resources.ClientContractorIndEntrepreneur)
                return Resources.INNRequirementsTwelveDigits;
            else
                return Resources.INNFormatError;
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            Close();
        }

        private void ButtonOfAddClient_Click(object sender, EventArgs e)
        {
            var name = textBoxOfName.Text;
            var contractor = comboBoxOfContractor.Text;
            var iNN = textBoxOfINN.Text;
            var contactInfo = textBoxOfContactInfo.Text;

            if (!ValidateINN(iNN, contractor))
            {
                MessageBox.Show(GetINNErrorMessage(contractor), Resources.ErrorValidation,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = new Client
            {
                Client_Id = Guid.NewGuid(),
                ClientCode = GenerateUniqueCode.GenerateUniqueClientCode(db),
                Name = name,
                Contractor = contractor,
                INN = iNN,
                ContactInfo = contactInfo
            };

            try
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}\n\n" +
                                $"Текст ошибки: {ex.Message}", Resources.TitleErrorBD,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            Close();
        }
    }
}
