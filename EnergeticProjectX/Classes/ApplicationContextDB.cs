using EnergeticProjectX.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Создаёт среду для подключения к БД
    /// </summary>
    public class ApplicationContextDB : DbContext
    {
        /// <summary>
        /// Подключается к таблице Users внутри БД
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Подключается к таблице Clients внутри БД
        /// </summary>
        public DbSet<Client> Clients { get; set; } = null!;

        /// <summary>
        /// Подключается к таблице Products внутри БД
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Подключается к таблице Categories внутри БД
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Подключается к таблице Shipments внутри БД
        /// </summary>
        public DbSet<Shipment> Shipments { get; set; }

        /// <summary>
        /// Подключается к таблице ShipmentItems внутри БД
        /// </summary>
        public DbSet<ShipmentItems> ShipmentItems { get; set; }

        /// <summary>
        /// Подключается к таблице Units внутри БД
        /// </summary>
        public DbSet<Unit> Units { get; set; } = null!;

        /// <summary>
        /// Является базовым конструктором при создании БД (без параметров)
        /// </summary>
        public ApplicationContextDB() => Database.EnsureCreated();

        /// <summary>
        /// Создаётся перегрузка. Конструктор при передаче параметра options
        /// </summary>
        public ApplicationContextDB(DbContextOptions<ApplicationContextDB> options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guidToStringConverter = new ValueConverter<Guid, string>(
                v => v.ToString(),
                v => Guid.Parse(v)
            );

            modelBuilder.Entity<Client>()
                .Property(c => c.Client_Id)
                .HasConversion(guidToStringConverter);

            modelBuilder.Entity<User>()
                .Property(u => u.User_Id)
                .HasConversion(guidToStringConverter);

            modelBuilder.Entity<Product>()
                .Property(p => p.Product_Id)
                .HasConversion(guidToStringConverter);

            modelBuilder.Entity<Category>()
                .Property(c => c.Category_Id)
                .HasConversion(guidToStringConverter);

            modelBuilder.Entity<Shipment>()
                .Property(s => s.Shipment_Id)
                .HasConversion(guidToStringConverter);

            modelBuilder.Entity<ShipmentItems>()
                .Property(si => si.ShipmentItem_Id)
                .HasConversion(guidToStringConverter);

            modelBuilder.Entity<Unit>()
                .Property(u => u.Unit_Id)
                .HasConversion(guidToStringConverter);

            base.OnModelCreating(modelBuilder);
        }
    }
}