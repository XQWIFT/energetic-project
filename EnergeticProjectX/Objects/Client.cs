using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EnergeticProjectX.Properties;
using System.Text.RegularExpressions;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Класс, связанный с базой данных и описывающий клиента.
    /// </summary>
    [Table("clients")]
    public class Client
    {
        /// <summary>
        /// ID клиента.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Client_Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Название компании или ФИО физического лица или ИП.
        /// </summary>
        [Column("name")]
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// Тип контрагента.
        /// </summary>
        [Column("contractor")]
        [Required]
        public required Contractors Contractor { get; set; }

        /// <summary>
        /// ИНН организации, физического лица или ИП.
        /// </summary>
        [Column("inn")]
        [StringLength(12)]
        [Required]
        public required string INN { get; set; }

        /// <summary>
        /// Контактная информация. Например, номер телефона, почтовый адрес.
        /// </summary>
        [Column("contact_info")]
        public string? ContactInfo { get; set; }

        /// <summary>
        /// Валидация вводимого пользователем ИНН в зависимости от заданного контрагента.
        /// Юр. лицо - комбинация из 10 цифр, Физ. лицо или ИП - комбинация из 12 цифр.
        /// </summary>
        /// <param name="iNN">Идентификационный номер нового клиента.</param>
        /// <param name="contractorType">Контрагент.</param>
        /// <returns>Подтверждение валидации.</returns>
        [SuppressMessage("Performance", "SYSLIB1045:Преобразовать в \"GeneratedRegexAttribute\".", Justification = "<Ожидание>")]
        public static bool ValidateINN(string iNN, string contractorTypeString)
        {
            if (string.IsNullOrWhiteSpace(iNN)) return false;

            iNN = iNN.Replace(" ", "");

            if (!Regex.IsMatch(iNN, @"^\d+$")) return false;

            var contractorType = EnumMethod.ParseDescriptionOfPotentialContractorsValue(contractorTypeString);

            return contractorType switch
            {
                Contractors.LegalEntity => iNN.Length == 10,
                Contractors.PhysicalPerson or Contractors.IndividualEntrepreneur => iNN.Length == 12,
                _ => false
            };
        }

        /// <summary>
        /// Получение ошибки, связанной с валидацией ИНН.
        /// Юр. лицо - комбинация из 10 цифр, Физ. лицо или ИП - комбинация из 12 цифр.
        /// </summary>
        /// <param name="contractorTypeString">Тип контрагента в строком представлении.</param>
        /// <returns>Сообщение об ошибке.</returns>
        public static string GetINNErrorMessage(string contractorTypeString)
        {
            var contractorType = EnumMethod.ParseDescriptionOfPotentialContractorsValue(contractorTypeString);
            if (contractorType == Contractors.LegalEntity)
                return Resources.INNRequirementsTenDigits;
            else if (contractorType == Contractors.PhysicalPerson || contractorType == Contractors.IndividualEntrepreneur)
                return Resources.INNRequirementsTwelveDigits;
            else
                return Resources.INNFormatError;
        }
    }
}
