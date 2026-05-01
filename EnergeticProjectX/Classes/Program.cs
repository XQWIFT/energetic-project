using EnergeticProjectX.Properties;
using EnergeticProjectX.Forms;

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

                ApplicationMethod.Initialize(db);

                Application.Run(new AuthorizationForm());
            }
            catch (Exception)
            {
                ErrorHandler.ShowError(Resources.CriticalError);
            }
        }
    }
}