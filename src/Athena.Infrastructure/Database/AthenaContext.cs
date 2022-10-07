using Athena.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Athena.Infrastructure.Database;

public class AthenaContext : DbContext
{
    public AthenaContext(DbContextOptions<AthenaContext> options) : base(options)
    {
    }

    private DbSet<Product> Products { get; set; }
}