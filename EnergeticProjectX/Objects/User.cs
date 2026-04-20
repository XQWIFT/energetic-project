using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Создаётся пользователь
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// Уникальный внутренний ID записи
        /// </summary>
        [Key]
        [Column("Id")]
        public Guid User_Id { get; set; }

        /// <summary>
        /// Уникальный код пользователя (5 цифр)
        /// </summary>
        [Column("UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Логин пользователя для авторизации
        /// </summary>
        [Column("Login")]
        public required string Login { get; set; }

        /// <summary>
        /// Хешированный пароль
        /// </summary>
        [Column("PasswordHash")]
        public required string Password { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Column("LastName")]
        public required string Surname { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Column("FirstName")]
        public required string Name { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        [Column("Patronymic")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Роль пользователя в системе
        /// </summary>
        [Column("Role")]
        public required string UserRole { get; set; }
    }
}
