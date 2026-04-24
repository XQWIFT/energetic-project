using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Отображение позиции отгрузки в таблице.
    /// </summary>
    public class ShipmentItemDisplayModel
    {
        /// <summary>
        /// Артикул товара.
        /// </summary>
        [DisplayName("Артикул")]
        public required string Article { get; set; }

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
        /// Клиент.
        /// </summary>
        [DisplayName("Получатель")]
        public required string ClientName { get; set; }
    }
}