using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    [Table("ShipmentItems")]
    public class ShipmentItems
    {
        /// <summary>
        /// Уникальный ID отгрузки
        /// </summary>
        [Key]
        [Column("Id")]
        public Guid ShipmentItem_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Ссылка на родительскую (связанную) отгрузку
        /// </summary>
        [ForeignKey(nameof(Shipment))]
        [Column("ShipmentId")]
        public Guid Shipment_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: отгрузка
        /// </summary>
        public Shipment? Shipment { get; set; }

        /// <summary>
        /// Ссылка на родительскую (связанную) отгрузку
        /// </summary>
        [ForeignKey(nameof(Product))]
        [Column("ProductId")]
        public Guid Product_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: товар
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Количество отгруженного товара
        /// </summary>
        [Column("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Цена товара на момент отгрузки (снимок цены) 
        /// </summary>
        [Column("PriceSnapshot")]
        public string? PriceSnapshot { get; set; }
    }
}
