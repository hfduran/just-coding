using Microsoft.EntityFrameworkCore;

namespace GreatApi.Models;

public class GreatContext : DbContext
{
    public GreatContext(DbContextOptions<GreatContext> options)
        : base(options)
    {
    }

    public DbSet<GreatItem> GreatItem { get; set; } = null!; // not a good idea, but I guess it works
}
