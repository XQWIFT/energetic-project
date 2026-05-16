using EnergeticProjectX.Properties;
using EnergeticProjectX.Forms;
using Microsoft.Extensions.DependencyInjection;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.interfaces;
using EnergeticProjectX.RepositoriesAndServices;


namespace EnergeticProjectX.Classes
{
    internal static class Program
    {
        public static ApplicationContext AppContext { get; private set; }
        public static ApplicationContextDB Database { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var services = new ServiceCollection();
                
                services.AddSingleton<ApplicationContextDB>();

                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IProductRepository,  ProductRepository>();
                services.AddScoped<IProductService,  ProductService>();
                services.AddScoped<IClientService, ClientService>();
                services.AddScoped<IClientRepository, ClientRepository>();

                services.AddTransient<AuthorizationForm>();

                ServiceProvider = services.BuildServiceProvider();

                ApplicationConfiguration.Initialize();

                Database = new ApplicationContextDB();

                ApplicationMethod.Initialize(Database);

                var authorizationForm = ServiceProvider.GetService<AuthorizationForm>();

                AppContext = new ApplicationContext(authorizationForm);

                Application.Run(AppContext);
            }
            catch (Exception)
            {
                ErrorHandler.ShowError(Resources.CriticalError);
            }
        }
    }
}