using DBControl;

namespace GeneratedCode
{
    /// <summary>
    /// Создаёт уникальный код пользователя
    /// </summary>
    public class GenerateUniqueCode
    {
        DBControl.ApplicationContextDB db = new();
        Random random = new Random();
        string? newCode;

        /// <summary>
        /// Генератор уникального кода 
        /// (реализация через Random)
        /// </summary>
        public string Generate5()
        {
            newCode = random.Next(0, 100000).ToString("D5");
            return newCode!;
        }

        public string Generate6()
        {
            newCode = random.Next(0, 100000).ToString("D6");
            return newCode!;
        }

    }
}
