using EnergeticProjectX.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий товар.
    /// </summary>
    [Table("products")]
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор товара. UUID ⟷ GUID.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Product_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Артикул товара (формат: латинская буква A + уникальная комбинация из 6 цифр).
        /// </summary>
        [Column("article")]
        [StringLength(7, MinimumLength = 7)]
        [Required]
        public required string Article { get; set; }

        /// <summary>
        /// Наименование товара.
        /// </summary>  
        [Column("name")]
        [StringLength(30)]
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// Ссылка на категорию товара. UUID ⟷ GUID.
        /// </summary>
        [Column("category_id")]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство: категория товара.
        /// </summary>
        public virtual Category? Category { get; set; }

        /// <summary>
        /// Статус товара: Active - товар активен, Hidden - товар удалён пользователем
        /// и скрыт для использования. Если не существует товара, за которым закрепляется
        /// категория и при этом она скрыта, то данная категория удаляется безвозвратно.
        /// </summary>
        [Column("status")]
        public ProductStatus Status { get; set; } = ProductStatus.Active;

        /// <summary>
        /// Закупочная цена товара.
        /// </summary>
        [Column("purchase_price", TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// Цена продажи товара.
        /// </summary>
        [Column("sale_price", TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Текущий остаток товара на складе.
        /// </summary>
        [Column("stock_quantity")]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } = 0;

        /// <summary>
        /// Дата создания карточки нового товара.
        /// </summary>
        [Column("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Дата назначения скидки для товара.
        /// </summary>
        [Column("discount_date")]
        public DateOnly DiscountDate { get; set; }

        /// <summary>
        /// Константа, которая определяет увеличение цены для продажи относительно цены закупки.
        /// </summary>
        [NotMapped]
        public const decimal priceIncreaseCoefficient = 1.5m; 
    }
}
