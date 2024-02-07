using FeallesBase.Models;
using Microsoft.EntityFrameworkCore;

namespace FeallesBase.Data
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
