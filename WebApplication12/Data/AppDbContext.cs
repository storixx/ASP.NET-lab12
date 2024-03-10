using Microsoft.EntityFrameworkCore;
using WebApplication12.Data.Models;

namespace WebApplication12.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Name=DefaultConnection");
        }
    } */
}
