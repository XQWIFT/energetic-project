using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Создаёт отображение пользователя и его данных в таблице
    /// </summary>
    public class UserDisplayModel
    {
        /// <summary>
        /// Уникальный ID пользователя
        /// </summary>
        [DisplayName("ID")]
        public required string UserCode { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Имя")]
        public required string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [DisplayName("Фамилия")]
        public required string Surname { get; set; }

        /// <summary>
        /// Отчество пользователя (при наличии)
        /// </summary>
        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Роль пользователя: Администратор или Кладовщик
        /// </summary>
        [DisplayName("Роль")]
        public required string UserRole { get; set; }
    }
}
