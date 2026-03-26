using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientControl
{
    /// <summary>
    /// Создаётся клиент
    /// </summary>
    [Table("Clients")]
    public class Client
    {
        /// <summary>
        /// Уникальный ID клиента
        /// </summary>
        [Key]
        [Column("Id")]
        public long Client_Id { get; set; }

        /// <summary>
        /// Код клиента (формат: буква K + 6 цифр)
        /// </summary>
        [Column("ClientCode")]
        public string ClientCode { get; set; }

        /// <summary>
        /// Название компании или ФИО физического лица
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Тип контрагента
        /// </summary>
        [Column("Type")]
        public string Contractor {  get; set; }

        /// <summary>
        /// ИНН организации или физического лица 
        /// </summary>
        [Column("INN")]
        public string? INN {  get; set; }

        /// <summary>
        /// Контактная информация (телефон, email, адрес) 
        /// </summary>
        [Column("ContactInfo")]
        public string? ContactInfo { get; set; }
    }
}
