using Microsoft.EntityFrameworkCore;

namespace JuniorSlataTestTask
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Slata");
        }
    }
}