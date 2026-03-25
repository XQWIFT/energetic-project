using ClientControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserControl;
namespace DBControl
{
    /// <summary>
    /// Создаёт среду для подключения к БД
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Создаёт таблицу Users внутри БД
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;
        /// <summary>
        /// Создаёт таблицу Clients внутри БД
        /// </summary>
        public DbSet<Client> Clients { get; set; } = null!;
        /// <summary>
        /// Является базовым конструктором при создании БД (без параметров)
        /// </summary>
        public ApplicationContext() => Database.EnsureCreated();

        /// <summary>
        /// Создаётся перегрузка. Конструктор при передаче параметра options
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFile("logs/ef-core.log");
                builder.SetMinimumLevel(LogLevel.Information);
            });
            if (!optionsBuilder.IsConfigured)
            {
                var projectDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
                var dbPath = Path.Combine(projectDir, "Databases", "Energetic.db");
                optionsBuilder
                    .UseSqlite($"Data Source={dbPath}")
                    .UseLoggerFactory(loggerFactory);
            }
        }
    }
}