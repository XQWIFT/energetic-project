using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Отображение позиции поставки в таблице.
    /// </summary>
    public class DeliveryItemDisplayModel
    {
        /// <summary>
        /// Индекс товара.
        /// </summary>
        [Browsable(false)]
        public int Index { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        [DisplayName("Название")]
        public required string Name { get; set; }

        /// <summary>
        /// Количество товара.
        /// </summary>
        [DisplayName("Количество")]
        public int Quantity { get; set; }

        /// <summary>
        /// Закупочная цена товара.
        /// </summary>

        [DisplayName("Цена закупки")]
        public required string PurchasePrice { get; set; }

        /// <summary>
        /// Категория товара.
        /// </summary>
        [DisplayName("Категория")]
        public required string Category { get; set; }

        /// <summary>
        /// Единица измерения товара.
        /// </summary>
        [DisplayName("Единица")]
        public required string Unit { get; set; }

        /// <summary>
        /// Прибыль с товара.
        /// </summary>
        [DisplayName("Сумма")]
        public required string TotalPrice { get; set; }
    }
}