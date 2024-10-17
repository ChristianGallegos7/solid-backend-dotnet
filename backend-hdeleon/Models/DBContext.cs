using Microsoft.EntityFrameworkCore;

namespace backend_hdeleon.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        { }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<Brand> Brands { get; set; }
        

    }
}
