using Microsoft.EntityFrameworkCore;
using Cappic.Models;


namespace Cappic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Lens> Lenses { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
