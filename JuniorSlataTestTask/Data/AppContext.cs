using JuniorSlataTestTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JuniorSlataTestTask
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Data.Models.Task> Tasks { get; set; }
        public DbSet<Jobseaker> Jobseakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Slata");
        }
    }
}