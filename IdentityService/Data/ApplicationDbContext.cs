using IdentityApi.Data;
using IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IdentityApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
   
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
    }
}

