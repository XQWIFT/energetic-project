using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий поставку товара.
    /// </summary>
    [Table("deliveries")]
    public class Delivery
    {
        /// <summary>
        /// ID поставки.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Delivery_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Дата поставки.
        /// </summary>
        [Column("delivery_date")]
        [Required]
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Ссылка на пользователя, оформившего поставку.
        /// </summary>
        [Column("user_id")]
        [ForeignKey(nameof(User))]
        public Guid User_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: пользователь.
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Общая сумма поставки.
        /// </summary>
        [Column("total_amount", TypeName = "decimal(15,2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Навигационное свойство: позиции поставки.
        /// </summary>
        public virtual ICollection<DeliveryItems> DeliveryItems { get; set; } = [];
    }
}