using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий единицу измерения товара.
    /// </summary>
    [Table("units")]
    public class Unit
    {
        /// <summary>
        /// ID единицы измерения.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Unit_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Название единицы измерения.
        /// </summary>
        [Column("name")]
        [StringLength(10)]
        [Required]
        public required string Name { get; set; }
    }
}
