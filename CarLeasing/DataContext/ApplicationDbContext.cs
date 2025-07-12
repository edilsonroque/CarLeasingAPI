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
    }
}
