using Athena.Core.Entities;
using Athena.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Core.Services
{
    public  class ProductsService : IProductsService
    {
        private readonly IAthenaDbContext _athenaDbContext;

        //ctor
        public ProductsService(IAthenaDbContext athenaDbContext)
        {
            _athenaDbContext = athenaDbContext;
        }

        //create products
        public async Task<Product> CreateProductAsync(Product product)
        {
            _athenaDbContext.Products.Add(product);
            await _athenaDbContext.SaveChangesAsync();
            return product;
        }
    }
}
