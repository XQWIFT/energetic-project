using System.ComponentModel;

namespace SelectDataForTable
{
    public class UserDisplayModel
    {
        [DisplayName("ID")]
        public long User_Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }
        [DisplayName("Роль")]
        public string UserRole { get; set; }
    }
}
