using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions options): base(options) 
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
