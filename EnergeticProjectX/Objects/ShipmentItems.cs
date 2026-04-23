using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий товар в отгрузке.
    /// </summary>
    [Table("shipment_items")]
    public class ShipmentItems
    {
        /// <summary>
        /// ID предмета отгрузки.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid ShipmentItem_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Ссылка на связанную отгрузку.
        /// </summary>
        [Column("shipment_id")]
        [ForeignKey(nameof(Shipment))]
        public Guid Shipment_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: отгрузка
        /// </summary>
        public virtual Shipment? Shipment { get; set; }

        /// <summary>
        /// Ссылка на отгруженный товар.
        /// </summary>
        [Column("product_id")]
        [ForeignKey(nameof(Product))]
        public Guid Product_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: товар.
        /// </summary>
        public virtual Product? Product { get; set; }

        /// <summary>
        /// Количество отгруженного товара.
        /// </summary>
        [Column("quantity")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// Цена товара на момент отгрузки.
        /// </summary>
        [Column("sale_price", TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        [Required]
        public required decimal FixedSalePrice { get; set; }
    }
}
