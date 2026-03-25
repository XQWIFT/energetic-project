using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientControl
{
    /// <summary>
    /// Создаётся клиент
    /// </summary>
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Column("ID")]
        public long Client_Id { get; set; }
        [Column("ClientCode")]
        public string ClientCode { get; set; }
        [Column("Название")]
        public string Name { get; set; }
        [Column("Type")]
        public string Contractor {  get; set; }
        [Column("ИНН")]
        public string? INN {  get; set; }
        [Column("Контактная информация")]
        public string? ContactInfo { get; set; }
    }
}
