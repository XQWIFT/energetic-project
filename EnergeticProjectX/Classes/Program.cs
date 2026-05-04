using EnergeticProjectX.Properties;
using EnergeticProjectX.Forms;

namespace EnergeticProjectX.Classes
{
    internal static class Program
    {
        public static ApplicationContext AppContext { get; private set; }
        public static ApplicationContextDB Database { get; private set; }

        /// <summary>
        ///  Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();

                Database = new ApplicationContextDB();

                ApplicationMethod.Initialize(Database);

                AppContext = new ApplicationContext(new AuthorizationForm());

                Application.Run(AppContext);
            }
            catch (Exception)
            {
                ErrorHandler.ShowError(Resources.CriticalError);
            }
        }
    }
}