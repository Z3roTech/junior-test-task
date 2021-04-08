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
        //public DbSet<Jobposition> Jobpositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data.Models.Task>()
                .HasOne(b => b.Jobseaker)
                .WithOne(i => i.Task)
                .HasForeignKey<Jobseaker>(b => b.TaskId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Slata");
        }
    }
}