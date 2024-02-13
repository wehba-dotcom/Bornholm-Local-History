using FeallesBaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FeallesBaseApi.Data
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
