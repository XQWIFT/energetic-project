namespace EnergeticProjectX.Objects
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
        /// Цена на момент совершения отгрузки.
        /// </summary>
        public decimal PriceSnapshot { get; set; }
    }
}
