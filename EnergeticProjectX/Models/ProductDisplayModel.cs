using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Отображение товаров и их данных в таблице.
    /// </summary>
    public class ProductDisplayModel
    {
        /// <summary>
        /// Уникальный артикул товара.
        /// </summary>
        [DisplayName("Артикул товара")]
        public required string Article { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        [DisplayName("Название товара")]
        public required string Name { get; set; }

        /// <summary>
        /// Категория товара.
        /// </summary>
        [DisplayName("Категория товара")] 
        public required string Category { get; set; }

        /// <summary>
        /// Остаток товара.
        /// </summary>
        [DisplayName("Текущий остаток")]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Единица измерения товаров.
        /// </summary>
        [DisplayName("Единица измерения")]
        public required string Unit { get; set; }

        /// <summary>
        /// Цена продажи товара.
        /// </summary>
        [DisplayName("Цена продажи")]
        public required string SalePrice {  get; set; }

        /// <summary>
        /// Дата снижения цены.
        /// </summary>
        [DisplayName("Снижение цены")]
        public required DateOnly DiscountDate { get; set; }
    }
}
