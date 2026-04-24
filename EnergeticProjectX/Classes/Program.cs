using EnergeticProjectX.Properties;

namespace EnergeticProjectX.Classes
{
    internal static class Program
    {
        /// <summary>
        ///  Главная точка входа в приложение
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggerService.Info(Resources.SLApplicationRun);

            try
            {
                ApplicationConfiguration.Initialize();

                var db = new ApplicationContextDB();
                LoggerService.Debug(Resources.SLContextDBCreated);

                ApplicationMethod.Initialize(db);
                LoggerService.Info(Resources.ProgramInitializationEnd);

                Application.Run(new AuthorizationForm());
            }
            catch (Exception ex)
            {
                LoggerService.Fatal($"{Resources.UnhandledExceptionMessage}, {ex}");

                MessageBox.Show(Resources.CriticalError, Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}