using Microsoft.EntityFrameworkCore;

namespace Measurement.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Measurement>? Measurement { get; set; }

    }
}
