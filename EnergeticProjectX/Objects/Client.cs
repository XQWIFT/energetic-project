using EnergeticProjectX.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий клиента.
    /// </summary>
    [Table("clients")]
    public class Client
    {
        /// <summary>
        /// ID клиента.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Client_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Название компании или ФИО физического лица или ИП.
        /// </summary>
        [Column("name")]
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// Тип контрагента.
        /// </summary>
        [Column("contractor")]
        [Required]
        public required Contractors Contractor { get; set; }

        /// <summary>
        /// ИНН организации, физического лица или ИП.
        /// </summary>
        [Column("inn")]
        [StringLength(12)]
        [Required]
        public required string INN { get; set; }

        /// <summary>
        /// Статус клиент: Active - клиент актуален, Hidden - клиент удалён из системы
        /// пользователем и скрыт для использования. Если не существует отгрузок в системе,
        /// совершённых данному клиенту, то данный клиент удаляется из базы данных окончательно.
        /// удаляется безвозвратно.
        /// </summary>
        [Column("status")]
        [StringLength(6)]
        [Required]
        public Status Status { get; set; } = Status.Active;

        /// <summary>
        /// Контактная информация. Например, номер телефона, почтовый адрес.
        /// </summary>
        [Column("contact_info")]
        public string? ContactInfo { get; set; }
    }
}
