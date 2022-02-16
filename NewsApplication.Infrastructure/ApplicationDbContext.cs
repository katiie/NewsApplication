using Microsoft.EntityFrameworkCore;
using NewsApplication.Core;

namespace NewsApplication.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Favourite> Favourites { get; set; }
    }
}
