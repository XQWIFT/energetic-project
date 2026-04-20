using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Создаётся отгрузка
    /// </summary>
    [Table("Shipments")]
    public class Shipment
    {
        /// <summary>
        /// Уникальный ID отгрузки
        /// </summary>
        [Key]
        [Column("Id")]
        public Guid Shipment_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Дата операции отгрузки
        /// </summary>
        [Column("Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Ссылка на клиента, который получил товар
        /// </summary>
        [ForeignKey(nameof(Client))]
        [Column("ClientId")]
        public Guid Client_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: клиент
        /// </summary>
        public Client Client { get; set; } = null!;

        /// <summary>
        /// Ссылка на пользователя, который оформил отгрузку
        /// </summary>
        [ForeignKey(nameof(User))]
        [Column("UserId")]
        public Guid User_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: пользователь
        /// </summary>
        public User User { get; set; } = null!;
    }
}
