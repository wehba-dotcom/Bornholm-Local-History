using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace productApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<FastningBook> FastningBooks { get; set; }
    }
}
