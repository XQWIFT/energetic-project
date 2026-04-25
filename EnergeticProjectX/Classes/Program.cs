using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Classes
{
    internal static class Program
    {
        /// <summary>
        ///  Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggerService.Info(Resources.SLApplicationRun);

            try
            {
                ApplicationConfiguration.Initialize();

                var db = new ApplicationContextDB();
                LoggerService.Debug("Контекст базы данных создан.");

                ApplicationMethod.Initialize(db);
                LoggerService.Info("Методы при вызове программы завершены.");

                Application.Run(new AuthorizationForm());
            }
            catch (Exception ex)
            {
                LoggerService.Fatal($"Необработанное исключение: {ex}");

                ErrorHandler.ShowError(Resources.CriticalError);
            }
        }
    }
}