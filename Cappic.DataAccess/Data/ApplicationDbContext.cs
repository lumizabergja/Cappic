using Microsoft.EntityFrameworkCore;
using Cappic.Models;


namespace Cappic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }


    }
}
