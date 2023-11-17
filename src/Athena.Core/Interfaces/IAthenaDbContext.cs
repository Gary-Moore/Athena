using Athena.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Core.Interfaces
{
    public interface IAthenaDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
