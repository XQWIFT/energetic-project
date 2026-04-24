using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий отгрузку товара.
    /// </summary>
    [Table("shipments")]
    public class Shipment
    {
        /// <summary>
        /// ID отгрузки товара.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Shipment_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Дата оформления отгрузки.
        /// </summary>
        [Column("creation_date")]
        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Ссылка на клиента, которому отгружен товар.
        /// </summary>
        [Column("client_id")]
        [ForeignKey(nameof(Client))]
        public Guid Client_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: клиент.
        /// </summary>
        public virtual Client? Client { get; set; }

        /// <summary>
        /// Ссылка на пользователя, который оформил отгрузку.
        /// </summary>
        [Column("user_id")]
        [ForeignKey(nameof(User))]
        public Guid User_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: пользователь.
        /// </summary>
        public virtual User? User { get; set; }
    }
}
