using System.Reflection;
using EnergeticProjectX.Enums;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Статический класс с методами для реализованных перечислений.
    /// </summary>
    public static class EnumMethod
    {
        /// <summary>
        /// Метод для получения строкового значения из описания - атрибут Description.
        /// </summary>
        /// <param name="value">Переменная перечисления.</param>
        /// <returns>Строковое значение из атрибута описания.</returns>
        public static string GetDescriptionOfEnumValue(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field?.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();

            var result = attribute?.Description ?? value.ToString();

            return result;
        }

        /// <summary>
        /// Метод, который преобразует строковое описание - атрибут Description - в соответствующее
        /// значение перечисления Contractors.
        /// </summary>
        /// <param name="description">Текстовое описание контрагента</param>
        /// <returns>Объект Contractors, если соответствие найдено, иначе - null</returns>
        public static Contractors? ParseDescriptionOfPotentialContractorsValue(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return null;

            foreach (var field in typeof(Contractors).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
                if (attribute != null && string.Equals(attribute.Description, description, StringComparison.OrdinalIgnoreCase))
                    return (Contractors)field.GetValue(null)!;
            }

            return null;
        }
    }
}
