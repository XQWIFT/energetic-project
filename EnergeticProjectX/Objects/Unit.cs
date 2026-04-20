using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Создаётся единица измерения
    /// </summary>
    [Table("Units")]
    public class Unit
    {
        /// <summary>
        /// ID единицы измерения
        /// </summary>
        [Key]
        [Column("Id")]
        public Guid Unit_Id { get; set; }

        /// <summary>
        /// Значение измерения
        /// </summary>
        [Column("Value")]
        public required string Value { get; set; }
    }
}
