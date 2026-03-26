using System.ComponentModel;

namespace SelectUserDataForTable
{
    /// <summary>
    /// Создаёт отображение пользователя 
    /// и его данных в таблице
    /// </summary>
    public class UserDisplayModel
    {
        /// <summary>
        /// Уникальный ID пользователя
        /// </summary>
        [DisplayName("ID")]
        public long User_Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество пользователя (может быть NULL)
        /// </summary>
        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Роль пользователя: 
        /// Admin (админ) и Warehouseman (Кладовщик)
        /// </summary>
        [DisplayName("Роль")]
        public string UserRole { get; set; }
    }
}
