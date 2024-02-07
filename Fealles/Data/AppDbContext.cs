using Fealles.Models;
using Microsoft.EntityFrameworkCore;

namespace Fealles.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Feallesbase> Feallesbases { get; set; }
    }
}
