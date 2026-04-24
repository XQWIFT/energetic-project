using EnergeticProjectX.Classes;
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
        public required UserRole UserRole { get; set; }

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

        /// <summary>
        /// Проверка указанных данных на соответствие: пароль соответствует требованиям безопасности -
        /// минимум 8 символов, наличие заглавной латинской буквы и цифры и совпадает с паролем для
        /// подтверждения - повторным вводом пароля.
        /// </summary>
        /// <param name="password">Пароль от пользователя</param>
        /// <param name="passwordConfirmation">Повторный ввод пароля от пользователя</param>
        /// <returns>Подтверждение соответствия паролей и соответствие требования безопасности</returns>
        public static (bool, bool) IsPasswordRelevant(string password, string passwordConfirmation)
        {
            var charPasswordArray = password.Trim().ToCharArray();

            var hasDigit = false;
            var hasCapitalLetter = false;

            foreach (char symbol in charPasswordArray)
            {
                if (char.IsDigit(symbol))
                    hasDigit = true;
                else if (char.IsLetter(symbol) && char.IsUpper(symbol))
                    hasCapitalLetter = true;

                if (hasDigit && hasCapitalLetter)
                    break;
            }

            return (password.Trim() == passwordConfirmation.Trim(),
                   hasDigit && hasCapitalLetter && charPasswordArray.Length >= 8);
        }

        /// <summary>
        /// Проверка указанных личных данных на соответствие: отсутствие цифр.
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns>При успешной проверке выводится строка с заглавным первым элементом и
        /// строчными остальными, иначе - null</returns>
        public static string? IsUserPersonalDataRelevant(string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData))
                return null;

            char[] charInputDataArray = inputData.Trim().ToCharArray();

            foreach (char symbol in charInputDataArray)
            {
                if (!char.IsLetter(symbol))
                    return null;
            }

            return char.ToUpper(inputData[0]) + inputData[1..].ToLower();
        }
    }
}
