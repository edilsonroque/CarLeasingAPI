using CarLeasing.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CarModel> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CarModel>()
                .Property(e => e.Transmission)
                .HasConversion<string>();

            modelBuilder
                .Entity<CarModel>()
                .Property(e => e.FuelType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
