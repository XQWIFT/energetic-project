using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для работы с реализованными перечислениями.
    /// </summary>
    public class EnumHandler
    {
        /// <summary>
        /// Словарь по значениям роли пользователя.
        /// </summary>
        private static readonly Dictionary<UserRoles, string> dictUserRoles = new()
        {
            { UserRoles.Administrator, "Администратор" },
            { UserRoles.Warehouseman, "Кладовщик" }
        };

        /// <summary>
        /// Словарь по значениям типов контрагентов.
        /// </summary>
        private static readonly Dictionary<Contractors, string> dictContractors = new()
        {
            { Contractors.LegalEntity, "Юр. лицо" },
            { Contractors.PhysicalPerson, "Физ. лицо" },
            { Contractors.IndividualEntrepreneur, "ИП" }
        };

        /// <summary>
        /// Метод для получения строкового эквивалента роли пользователя.
        /// </summary>
        /// <param name="role">Роль пользователя из перечисления UserRoles.</param>
        /// <returns>Строковый эквивалент роли пользователя.</returns>
        public static string GetUserRole(UserRoles role)
        {
            return dictUserRoles[role];
        }

        /// <summary>
        /// Метод для получения строкового эквивалента типа контрагента.
        /// </summary>
        /// <param name="contractor">Тип контрагента из перечисления Contractors.</param>
        /// <returns>Строковый эквивалент типа контрагента.</returns>
        public static string GetContractorType(Contractors contractor)
        {
            return dictContractors[contractor];
        }

        /// <summary>
        /// Метод для получения типа контрагента из перечисления Contractors
        /// через строковый эквивалент.
        /// </summary>
        /// <param name="contractor">Тип контрагента на русском.</param>
        /// <returns>Значение типа контрагента из перечисления Contractors.</returns>
        public static Contractors SetContractorType(string contractor)
        {
            return dictContractors.FirstOrDefault(c => c.Value == contractor).Key;
        }
    }
}
