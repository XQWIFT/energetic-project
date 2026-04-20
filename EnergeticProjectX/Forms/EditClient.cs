using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using ListOfClientsForm;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EditClientForm
{
    /// <summary>
    /// Класс для редактирования данных клиента
    /// </summary>
    public partial class EditClient : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;
        private readonly string clientCode;
        private readonly string name;
        private readonly string contractor;
        private readonly string iNN;
        private readonly string contactInfo;

        /// <summary>
        /// Конструктор для редактирования данных клиента
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
        /// <param name="clientCode">Уникальный код клиента, пример K10000</param>
        /// <param name="name">Название клиентской организации, ФИО клиента и т.п.</param>
        /// <param name="contractor">Контрагент</param>
        /// <param name="iNN">Идентификационный номер клиента</param>
        /// <param name="contactInfo">Контактная информация</param>
        public EditClient(string userLogin, string clientCode, string name,
                          string contractor, string iNN, string contactInfo)
        {
            InitializeComponent();

            this.userLogin = userLogin;
            this.clientCode = clientCode;
            this.name = name;
            this.contractor = contractor;
            this.iNN = iNN;
            this.contactInfo = contactInfo;

            textBoxOfName.Text = this.name;
            comboBoxOfContractor.Text = this.contractor;
            textBoxOfINN.Text = this.iNN;
            textBoxOfContactInfo.Text = this.contactInfo;

            textBoxOfName.TextChanged += TextBox_TextChanged!;
            comboBoxOfContractor.TextChanged += TextBox_TextChanged!;
            textBoxOfINN.TextChanged += TextBox_TextChanged!;
            textBoxOfContactInfo.TextChanged += TextBox_TextChanged!;
        }

        /// <summary>
        /// Валидация ИНН. 10 цифр для юридического лица, 12 цифр для физического лица или ИП.
        /// </summary>
        /// <param name="INN">ИНН клиента</param>
        /// <param name="ContractorType">Контрагент</param>
        /// <returns>Подтверждение валидации</returns>
        public static bool ValidateINN(string INN, string ContractorType)
        {
            if (string.IsNullOrWhiteSpace(INN))
                return false;

            INN = INN.Replace(" ", "");

#pragma warning disable SYSLIB1045 // Преобразовать в "GeneratedRegexAttribute".
            if (!Regex.IsMatch(INN, @"^\d+$"))
                return false;
#pragma warning restore SYSLIB1045 // Преобразовать в "GeneratedRegexAttribute".

            if (ContractorType == Resources.ClientContractorLegalEntity)
                return INN.Length == 10;
            else if (ContractorType == Resources.ClientContractorPhysicalPerson ||
                     ContractorType == Resources.ClientContractorIndEntrepreneur)
                return INN.Length == 12;

            return false;
        }

        /// <summary>
        /// Получение ошибки ИНН
        /// </summary>
        /// <param name="contractorType">Контрагент</param>
        /// <returns>Сообщение об ошибке</returns>
        public static string GetINNErrorMessage(string contractorType)
        {
            if (contractorType == Resources.ClientContractorLegalEntity)
                return Resources.INNRequirementsTenDigits;
            else if (contractorType == Resources.ClientContractorPhysicalPerson ||
                     contractorType == Resources.ClientContractorIndEntrepreneur)
                return Resources.INNRequirementsTwelveDigits;
            else
                return Resources.INNFormatError;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfContractor.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfINN.Text);

            bool hasChanges = textBoxOfName.Text != name ||
                              comboBoxOfContractor.Text != contractor ||
                              textBoxOfINN.Text != iNN ||
                              textBoxOfContactInfo.Text != contactInfo;

            ButtonOfSaveChanges.Enabled = allFieldsFilled && hasChanges;
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var listOfClients = new ListOfClients(userLogin);
            listOfClients.ShowDialog();
            Close();
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (!ValidateINN(textBoxOfINN.Text, comboBoxOfContractor.Text))
            {
                MessageBox.Show(GetINNErrorMessage(comboBoxOfContractor.Text), Resources.ErrorValidation,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                var client = db.Clients.FirstOrDefault(u => u.ClientCode == clientCode)!;
                client.Name = textBoxOfName.Text;
                client.Contractor = comboBoxOfContractor.Text;
                client.INN = textBoxOfINN.Text;
                client.ContactInfo = textBoxOfContactInfo.Text;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Resources.ErrorClientSaveChanges}\n{Resources.TryAgain}\n\n" +
                                    $"Текст ошибки: {ex.Message}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Hide();
                var listOfClients = new ListOfClients(userLogin);
                listOfClients.ShowDialog();
                Close();
            }
        }

        private void ButtonOfDeleteClient_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show($"Вы действительно хотите удалить клиента: {name}?", Resources.TitleConfirmation,
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    var client = db.Clients.Where(u => u.ClientCode == clientCode)!.ExecuteDelete();

                    Hide();
                    var listOfClients = new ListOfClients(userLogin);
                    listOfClients.ShowDialog();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Resources.ErrorClientDelete}\n\nТекст ошибки: {ex.Message}", Resources.TitleError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

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
    }
}
