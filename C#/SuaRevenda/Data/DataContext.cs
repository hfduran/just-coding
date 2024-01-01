using Microsoft.EntityFrameworkCore;
using SuaRevenda.Models;

namespace SuaRevenda.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // use the specified configuration overriding the reflection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("SuaRevendaDB"));
    }

    public DbSet<Piece> Pieces { get; set; } = null!;
    public DbSet<Purchase> Purchases { get; set; } = null!;
    public DbSet<Consigned> Consigneds { get; set; } = null!;
    public DbSet<Origin> Origins { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<CommissionTable> CommissionTables { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}
