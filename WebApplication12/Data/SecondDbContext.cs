using Microsoft.EntityFrameworkCore;
using WebApplication12.Data.Models;

namespace WebApplication12.Data;

public class SecondDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    
    public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
    {
    }
    
    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Name=SecondDbConnection");
        }
    } */
}