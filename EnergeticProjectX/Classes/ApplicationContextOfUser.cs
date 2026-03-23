using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserControl;

namespace DbOfUser
{
    public class ApplicationContextOfUser : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContextOfUser() => Database.EnsureCreated();

        public ApplicationContextOfUser(DbContextOptions<ApplicationContextOfUser> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var projectDir = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
                var dbPath = Path.Combine(projectDir, "Databases", "Users.db");
                optionsBuilder
                    .UseSqlite($"Data Source={dbPath}")
                    .LogTo(Console.WriteLine, LogLevel.Information);
            }
        }
    }
}