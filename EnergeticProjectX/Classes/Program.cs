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
            ApplicationConfiguration.Initialize();

            var db = new ApplicationContextDB();

            ApplicationMethod.Initialize(db);

            Application.Run(new AuthorizationForm());
        }
    }
}