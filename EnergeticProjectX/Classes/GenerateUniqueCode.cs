using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для создания уникального кода пользователя
    /// </summary>
    public class GenerateUniqueCode
    {
        /// <summary>
        /// Генератор уникального кода пользователя - 5 цифр.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <returns>Уникальный код формата 00001</returns>
        public static string? GenerateUniqueUserCode(ApplicationContextDB db)
        {
            var maxCodeString = db.Users
                                  .Select(u => u.UserCode)
                                  .Where(code => !string.IsNullOrWhiteSpace(code))
                                  .OrderByDescending(code => code)
                                  .FirstOrDefault();

            var maxCode = string.IsNullOrEmpty(maxCodeString) ? 0 : int.Parse(maxCodeString);

            if (maxCode >= 99999)
                throw new InvalidOperationException(Resources.MaxNumberOfUsers);

            return (maxCode + 1).ToString("D5");
        }

        /// <summary>
        /// Генератор уникального клиентского кода — латинская буква K и 6 цифр.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <returns>Уникальный код формата K000001</returns>
        public static string GenerateUniqueClientCode(ApplicationContextDB db)
        {
            var maxCodeString = db.Clients
                                  .Select(u => u.ClientCode)
                                  .Where(code => !string.IsNullOrWhiteSpace(code))
                                  .OrderByDescending(code => code)
                                  .FirstOrDefault();

            var maxCode = string.IsNullOrEmpty(maxCodeString) ? 0 : int.Parse(maxCodeString![1..]);

            if (maxCode >= 999999)
                throw new InvalidOperationException(Resources.MaxNumberOfClients);

            return "K" + (maxCode + 1).ToString("D6");
        }

        /// <summary>
        ///  Генератор артикула для товара - латинская буква A и 6 цифр.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <returns>Уникальный код формата A000001</returns>
        public static string? GenerateUniqueProductArticle(ApplicationContextDB db)
        {
            var maxArticleString = db.Products
                                     .Select(u => u.Article)
                                     .Where(article => !string.IsNullOrWhiteSpace(article))
                                     .OrderByDescending(article => article)
                                     .FirstOrDefault();

            var maxCode = string.IsNullOrEmpty(maxArticleString) ? 0 : int.Parse(maxArticleString![1..]);

            if (maxCode >= 999999)
                throw new InvalidOperationException(Resources.MaxNumberOfProducts);

            return "A" + (maxCode + 1).ToString("D6");
        }
    }
}
