using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Phoenix.Infrastructure.Models.Entities;

namespace Phoenix.Infrastructure.Data;

public class PhoenixDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public PhoenixDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<UserComment> Comments{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("Default"));
        base.OnConfiguring(optionsBuilder);
    }
}