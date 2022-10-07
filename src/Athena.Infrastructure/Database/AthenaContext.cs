using Athena.Core.Entities;
using Athena.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Athena.Infrastructure.Database;

public class AthenaContext : DbContext
{
    public AthenaContext(DbContextOptions<AthenaContext> options) : base(options)
    {
    }

    private DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
    }
}