using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext _productDbContext;

        public ProductsController(ProductsDbContext productsDbContext)
        {
            _productDbContext = productsDbContext;
        }

        public ProductsDbContext ProductsDbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products =await _productDbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts([FromBody] Product productRequest)
        {
            productRequest.Id = Guid.NewGuid();

            await _productDbContext.Products.AddAsync(productRequest);
            await _productDbContext.SaveChangesAsync();

            return Ok(productRequest);
        }
    }
}
