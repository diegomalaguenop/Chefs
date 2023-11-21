using Microsoft.EntityFrameworkCore;

namespace Chefs.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Plato> Platos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    }
}
