using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий валюту.
    /// </summary>
    [Table("currencies")]
    public class Currency
    {
        /// <summary>
        /// Уникальный идентификатор валюты. UUID ⟷ GUID.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Currency_Id{ get; set; } = Guid.NewGuid();  

        /// <summary>
        /// Краткая запись валюты: RUB, USD, EUR.
        /// </summary>
        [Column("code")]
        [StringLength(3)]
        [Required]
        public required string Code { get; set; }

        /// <summary>
        /// Полное название валюты: Российский рубль, Доллар США, Евро.
        /// </summary>
        [Column("currency_name")]
        [StringLength(25)]
        [Required]
        public required string CurrencyName { get; set; }

        /// <summary>
        /// Символ валюты: ₽, $, €.
        /// </summary>
        [Column("symbol")]
        [StringLength(5)]
        [Required]
        public required string CurrencySymbol { get; set; }

        /// <summary>
        /// Эквивалент одной единицы валюты в рублях.
        /// </summary>
        [Column("exchange_rate", TypeName = "decimal(10,4)")]
        [Range(0.0001, double.MaxValue)]
        [Required]
        public required decimal ExchangeRate { get; set; }

        /// <summary>
        /// Дата обновления курса валюты.
        /// </summary>
        [Column("updated_at")]
        public required DateTime DataOfUpdate { get; set; } = DateTime.UtcNow;
    }
}
