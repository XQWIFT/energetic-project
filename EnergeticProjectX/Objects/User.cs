using EnergeticProjectX.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий пользователя системы.
    /// </summary>
    [Table("users")]
    public class User
    {
        /// <summary>
        /// ID пользоваля.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid User_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [Column("login")]
        [StringLength(50)]
        [Required]
        public required string Login { get; set; }

        /// <summary>
        /// Хешированный пароль.
        /// </summary>
        [Column("password_hash")]
        [StringLength(100)]
        [Required]
        public required string Password { get; set; }

        /// <summary>
        /// Роль пользователя в системе.
        /// </summary>
        [Column("user_role")]
        [StringLength(15)]
        [Required]
        public UserRoles UserRole { get; set; } = UserRoles.Warehouseman;

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        [Column("last_name")]
        [StringLength(15)]
        [Required]
        public required string Surname { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Column("first_name")]
        [StringLength(15)]
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        [Column("patronymic")]
        [StringLength(15)]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Ссылка на выбранную пользователем валюту.
        /// </summary>
        [Column("currency_id")]
        [ForeignKey(nameof(Currency))]
        [Required]
        public required Guid CurrencyId { get; set; }

        /// <summary>
        /// Навигационное свойство: выбранная валюта.
        /// </summary>
        public virtual Currency? Currency { get; set; }
    }
}
