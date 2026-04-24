namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Класс для работы с отгрузками.
    /// </summary>
    public class ShipmentItemRow
    {
        /// <summary>
        /// Артикул товара.
        /// </summary>
        public string Article { get; set; } = string.Empty;

        /// <summary>
        /// Название товара.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Количество товара.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ID клиента.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string ClientName { get; set; } = string.Empty;

        /// <summary>
        /// Цена на момент совершения отгрузки.
        /// </summary>
        public decimal PriceSnapshot { get; set; }
    }
}
