using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Создаёт отображение товаров и их данных в таблице
    /// </summary>
    public class ProductDisplayModel
    {
        /// <summary>
        /// Уникальный артикул товара
        /// </summary>
        [DisplayName("Артикул")]
        public required string Article { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        [DisplayName("Наименование")]
        public required string Name { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        [DisplayName("Категория")] 
        public required string Category { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        [DisplayName("Закупочная цена")]
        public required string PurchasePrice { get; set; }

        /// <summary>
        /// Остаток товара
        /// </summary>
        [DisplayName("Текущий остаток")]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Единица измерения товаров
        /// </summary>
        [DisplayName("Единица измерения")]
        public required Guid UnitId { get; set; }
    }
}
