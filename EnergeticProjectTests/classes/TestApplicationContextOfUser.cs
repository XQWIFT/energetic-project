using Microsoft.EntityFrameworkCore;
using UserControl;

namespace TestDbOfUser
{
    public class TestApplicationContextOfUser : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public TestApplicationContextOfUser() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        }
    }
}