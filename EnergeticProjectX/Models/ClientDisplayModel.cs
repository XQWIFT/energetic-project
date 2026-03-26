using System.ComponentModel;

namespace SelectClientDataForTable
{
    /// <summary>
    /// Создаёт отображение клиента 
    /// и его данных в таблице
    /// </summary>
    public class ClientDisplayModel
    {
        /// <summary>
        /// Уникальный ID клиента
        /// </summary>
        [DisplayName("Id")]
        public long Client_Id { get; set; }

        /// <summary>
        /// Имя клиента (компании)
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Физ.лицо, юр.лицо или ИП
        /// </summary>
        [DisplayName("Контрагент")]
        public string Contractor { get; set; }

        /// <summary>
        /// ИНН клиента
        /// </summary>
        [DisplayName("ИНН")]
        public string? INN { get; set; }

        /// <summary>
        /// Контактная информация (телефон, email, адрес) 
        /// </summary>
        [DisplayName("Контактная информация")]
        public string? ContactInfo { get; set; }
    }
}
