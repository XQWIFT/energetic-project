using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoryControl
{
    /// <summary>
    /// Создаётся категория
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        /// <summary>
        /// Уникальный ID категории
        /// </summary>
        [Key]
        [Column("Id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Название категории (например, «Ноутбуки», «Смартфоны»)
        /// </summary>
        [Column("Name")]
        public string Name{  get; set; }

    }
}
