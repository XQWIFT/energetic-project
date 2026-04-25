using EnergeticProjectX.Properties;
using System.Diagnostics;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для работы с частыми ошибками в программе.
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
                ShowError($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}");

                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для вывода сообщения с информацией пользователю.
        /// </summary>
        /// <param name="message">Информация для пользователя.</param>
        public static void ShowInformation(string message)
        {
            MessageBox.Show(message, Resources.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Метод для вывода уведомления пользователю.
        /// </summary>
        /// <param name="message">Текст уведомления.</param>
        public static void ShowAlert(string message)
        {
            MessageBox.Show(message, Resources.TitleAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Метод для вывода сообщения об ошибке пользователю.
        /// </summary>
        /// <param name="message">Текст ошибки.</param>
        public static void ShowError(string message)
        {
            MessageBox.Show(message, Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Метод для вывода сообщения для подтверждения какого-либо действия пользователем.
        /// </summary>
        /// <param name="message">Текст для подтверждения.</param>
        public static DialogResult ShowConfirmation(string message)
        {
            var answer = MessageBox.Show(message, Resources.TitleConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return answer;
        }

        /// <summary>
        /// Метод для вывода предупреждения пользователю.
        /// </summary>
        /// <param name="message">Текст предупреждения.</param>
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, Resources.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
