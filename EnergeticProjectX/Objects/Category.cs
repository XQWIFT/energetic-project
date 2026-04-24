using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий категорию товара.
    /// </summary>
    [Table("categories")]
    public class Category
    {
        /// <summary>
        /// ID категории.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Category_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Название категории. Например, «Ноутбуки», «Смартфоны».
        /// </summary>
        [Column("name")]
        [StringLength(25)]
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// Статус категории: Active - категория активна, Hidden - категория удалена
        /// пользователем и скрыта для использования. Если не существует товара, за
        /// которым закрепляется категория и при этом она скрыта, то данная категория
        /// удаляется безвозвратно.
        /// </summary>
        [Column("status")]
        public CategoryStatus Status { get; set; } = CategoryStatus.Active;

        /// <summary>
        /// ID закреплённой единицы измерения.
        /// </summary>
        [Column("unit_id")]
        [ForeignKey(nameof(Unit))]
        public Guid Unit_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: единица измерения.
        /// </summary>
        public virtual Unit? Unit { get; set; }
    }
}
