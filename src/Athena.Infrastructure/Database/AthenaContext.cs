using Athena.Core.Entities;
using Athena.Core.Interfaces;
using Athena.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Athena.Infrastructure.Database;

public class AthenaContext : DbContext, IAthenaDbContext
{
    public AthenaContext(DbContextOptions<AthenaContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
    }
}