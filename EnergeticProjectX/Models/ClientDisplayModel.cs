using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Отображение клиента и его данных в таблице.
    /// </summary>
    public class ClientDisplayModel
    {
        /// <summary>
        /// Имя клиента: организация, компания, частное лицо.
        /// </summary>
        [DisplayName("Клиент")]
        public required string Name { get; set; }

        /// <summary>
        /// Контрагент: Физ. лицо, Юр. лицо или ИП.
        /// </summary>
        [DisplayName("Контрагент")]
        public required string Contractor { get; set; }

        /// <summary>
        /// ИНН клиента.
        /// </summary>
        [DisplayName("ИНН")]
        public required string INN { get; set; }

        /// <summary>
        /// Контактная информация: телефон, email, адрес.
        /// </summary>
        [DisplayName("Контактные данные")]
        public string? ContactInfo { get; set; }
    }
}
