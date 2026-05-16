using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий позицию в поставке.
    /// </summary>
    [Table("delivery_items")]
    public class DeliveryItems
    {
        /// <summary>
        /// ID позиции поставки.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid DeliveryItem_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Ссылка на поставку.
        /// </summary>
        [Column("delivery_id")]
        [ForeignKey(nameof(Delivery))]
        public Guid Delivery_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: поставка.
        /// </summary>
        public virtual Delivery? Delivery { get; set; }

        /// <summary>
        /// Ссылка на товар.
        /// </summary>
        [Column("product_id")]
        [ForeignKey(nameof(Product))]
        public Guid Product_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: товар.
        /// </summary>
        public virtual Product? Product { get; set; }

        /// <summary>
        /// Количество поставленного товара.
        /// </summary>
        [Column("quantity")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// Закупочная цена товара на момент поставки.
        /// </summary>
        [Column("purchase_price", TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        [Required]
        public decimal PurchasePrice { get; set; }
    }
}