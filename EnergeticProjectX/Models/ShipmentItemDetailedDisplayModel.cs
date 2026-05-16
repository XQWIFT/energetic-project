using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Модель для отображения деталей позиции отгрузки.
    /// </summary>
    public class ShipmentItemDetailModel
    {
        /// <summary>
        /// Название товара.
        /// </summary>
        [DisplayName("Название")]
        public required string Name { get; set; }

        /// <summary>
        /// Категория товара.
        /// </summary>
        [DisplayName("Категория")]
        public required string Category { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        [DisplayName("Количество")]
        public int Quantity { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        [DisplayName("Единица")]
        public required string Unit { get; set; }

        /// <summary>
        /// Цена продажи.
        /// </summary>
        [DisplayName("Цена продажи")]
        public required string SalePrice { get; set; }
    }
}