using EnergeticProjectX.Properties;
using System.Diagnostics;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для вычисления частых ошибок в работе программы
    /// </summary>
    public class ErrorHandler
    {
        /// <summary>
        /// Метод, который при удалении предмета из таблицы базы данных осуществляет проверку на сохранение
        /// соответствующих изменений. При ошибке сохранения в отладке выводится сообщение с описанием ошибки.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <param name="messageIfError">Сообщение в случае ошибки</param>
        public static void DBSaveChangesCleanUpHiddenItemsError(ApplicationContextDB db, string messageIfError)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{messageIfError}: {ex}");
            }
        }

        /// <summary>
        /// Метод, который осуществляет проверку на сохранение изменений в базе данных. При ошибке выводится
        /// соответствующее сообщение.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <returns>Подтверждение сохранения данных</returns>
        public static bool DBSaveChangesUniversalErrorCheck(ApplicationContextDB db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}", Resources.TitleErrorBD,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}
