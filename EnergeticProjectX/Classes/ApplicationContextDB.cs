using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для создания среды для подключения базы данных.
    /// </summary>
    public class ApplicationContextDB : DbContext
    {
        /// <summary>
        /// Подключение к таблице Users внутри базы данных.
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Подключение к таблице Clients внутри базы данных.
        /// </summary>
        public DbSet<Client> Clients { get; set; } = null!;

        /// <summary>
        /// Подключение к таблице Products внутри базы данных.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Подключение к таблице Categories внутри базы данных.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Подключение к таблице Shipments внутри базы данных.
        /// </summary>
        public DbSet<Shipment> Shipments { get; set; }

        /// <summary>
        /// Подключение к таблице ShipmentItems внутри базы данных.
        /// </summary>
        public DbSet<ShipmentItems> ShipmentItems { get; set; }

        /// <summary>
        /// Подключение к таблице Units внутри базы данных.
        /// </summary>
        public DbSet<Unit> Units { get; set; }

        /// <summary>
        /// Подключается к таблице Currencies внутри базы данных.
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Подключается к таблице Deliveries внутри базы данных.
        /// </summary>
        public DbSet<Delivery> Deliveries { get; set; } = null!;

        /// <summary>
        /// Подключается к таблице DeliveryItems внутри базы данных.
        /// </summary>
        public DbSet<DeliveryItems> DeliveryItems { get; set; } = null!;

        /// <summary>
        /// Базовый конструктор без параметров для создания контекста базы данных.
        /// </summary>
        /// 
        public ApplicationContextDB()
        {
            {
                try
                {
                    Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"{Resources.EnsureCreatedError}:\n{ex.Message}");
                }
            }
        }

        /// <summary>
        /// Конструктор при передаче параметра options.
        /// </summary>
        public ApplicationContextDB(DbContextOptions<ApplicationContextDB> options)
            : base(options)
        {

        }

        /// <summary>
        /// Настройка подключения к базе данных.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = HiddenDataManager.GetConnectionString();

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        /// <summary>
        /// Настройка моделей.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Product>().ToTable("products");

            modelBuilder.Entity<Category>().ToTable("categories");

            modelBuilder.Entity<Unit>().ToTable("units");

            modelBuilder.Entity<Client>().ToTable("clients");

            modelBuilder.Entity<Shipment>().ToTable("shipments");

            modelBuilder.Entity<ShipmentItems>().ToTable("shipment_items");

            modelBuilder.Entity<Currency>().ToTable("currencies");

            // Категория ⟶ Единица измерения.
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Unit)
                .WithMany()
                .HasForeignKey(c => c.Unit_Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Товар ⟶ Категория.
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Отгрузка ⟶ Клиент.
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Отгрузка ⟶ Пользователь.
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.User_Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Позиция отгрузки ⟶ Отгрузка.
            modelBuilder.Entity<ShipmentItems>()
                .HasOne(si => si.Shipment)
                .WithMany()
                .HasForeignKey(si => si.Shipment_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Позиция отгрузки ⟶ Товар.
            modelBuilder.Entity<ShipmentItems>()
               .HasOne(si => si.Product)
               .WithMany()
               .HasForeignKey(si => si.Product_Id)
               .OnDelete(DeleteBehavior.Restrict);

            // Пользователь ⟶ Валюта.
            modelBuilder.Entity<User>()
                .HasOne(u => u.Currency)
                .WithMany()
                .HasForeignKey(u => u.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Роль пользователя ⟶ String.
            modelBuilder.Entity<User>()
                .Property(u => u.UserRole)
                .HasConversion<string>()
                .IsRequired();

            // Контрагент клиента ⟶ String.
            modelBuilder.Entity<Client>()
                .Property(u => u.Contractor)
                .HasConversion<string>()
                .IsRequired();

            // Статус продукта ⟶ String.
            modelBuilder.Entity<Product>()
                .Property(u => u.Status)
                .HasConversion<string>()
                .IsRequired();


            // Статус категории ⟶ String.
            modelBuilder.Entity<Category>()
                .Property(u => u.Status)
                .HasConversion<string>()
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}