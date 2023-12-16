using Microsoft.EntityFrameworkCore;
using Phoenix.UI.Models;

namespace Phoenix.UI.Data;

public class PhoenixDbContext : DbContext
{

    public DbSet<UserComment> Comments{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=PhoenixDb");
    }
}