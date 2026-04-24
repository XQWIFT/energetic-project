using System.Text.Json;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для получения данных из файла для подключения к базе данных
    /// </summary>
    public class HiddenDataManager
    {
        /// <summary>
        /// Метод для получения информации для подключения к базе данных
        /// </summary>
        /// <returns>Информация для подключения</returns>
        public static string GetConnectionString()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "secrets.json");

            string json = File.ReadAllText(filePath);

            var options = JsonSerializer.Deserialize<OptionsDB>(json);

            return $"Host={options!.Host};Port={options.Port};Database={options.Database};Username={options.Username};Password={options.Password};Include Error Detail=true";
        }
    }
}
