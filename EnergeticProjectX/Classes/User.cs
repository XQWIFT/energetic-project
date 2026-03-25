using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserControl
{
    /// <summary>
    /// Создаётся пользователь
    /// </summary>
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Id")]
        public long User_Id { get; set; }
        [Column("UserCode")]
        public string UserCode { get; set; }
        [Column("Login")]
        public string Login { get; set; }
        [Column("PasswordHash")]
        public string Password { get; set; }
        [Column("LastName")]
        public string Surname { get; set; }
        [Column("FirstName")]
        public string Name { get; set; }
        [Column("Patronymic")]
        public string? Patronymic { get; set; }
        [Column("Role")]
        public string UserRole { get; set; }
    }
}
