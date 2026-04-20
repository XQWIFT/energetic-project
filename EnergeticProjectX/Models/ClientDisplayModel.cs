using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Создаёт отображение клиента и его данных в таблице
    /// </summary>
    public class ClientDisplayModel
    {
        /// <summary>
        /// Уникальный номер клиента для пользовательского интерфейса
        /// </summary>
        [DisplayName("ID")]
        public required string ClientCode { get; set; }

        /// <summary>
        /// Имя клиента (компании)
        /// </summary>
        [DisplayName("Название")]
        public required string Name { get; set; }

        /// <summary>
        /// Физ.лицо, юр.лицо или ИП
        /// </summary>
        [DisplayName("Контрагент")]
        public required string Contractor { get; set; }

        /// <summary>
        /// ИНН клиента
        /// </summary>
        [DisplayName("ИНН")]
        public required string INN { get; set; }

        /// <summary>
        /// Контактная информация (телефон, email, адрес) 
        /// </summary>
        [DisplayName("Контактные данные")]
        public string? ContactInfo { get; set; }
    }
}
