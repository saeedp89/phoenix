using Microsoft.EntityFrameworkCore;
using Phoenix.Infrastructure.Models.Entities;

namespace Phoenix.Infrastructure.Data;

public class PhoenixDbContext : DbContext
{

    public DbSet<UserComment> Comments{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=PhoenixDb");
    }
}