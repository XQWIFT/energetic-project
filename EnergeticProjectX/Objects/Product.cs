using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CategoryControl;

namespace ProductControl
{
    /// <summary>
    /// Создаётся продукт
    /// </summary>
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// Уникальный ID товара 
        /// </summary>
        [Key]
        [Column("Id")]
        public long Product_Id { get; set; }

        /// <summary>
        /// Артикул товара (формат: буква A + 6 цифр)
        /// </summary>
        [Column("Article")]
        public string Article { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на категорию товара
        /// </summary>
        [ForeignKey(nameof(Category))]
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство: категория товара
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Цена закупки товара в рублях 
        /// </summary>
        [Column("Price")]
        public double Price { get; set; }

        /// <summary>
        /// Текущий остаток товара на складе
        /// </summary>
        [Column("StockQuantity")]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Единица измерения (шт, кг, м и т.п.)
        /// </summary>
        [Column("Unit")]
        public string Unit {  get; set; }
    }
}
