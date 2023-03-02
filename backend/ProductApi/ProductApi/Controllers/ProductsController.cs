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

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] Product productRequest)
        {
            var product = await _productDbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productRequest.Name;
            product.Description = productRequest.Description;
            product.Price = productRequest.Price;
            product.Brand = productRequest.Brand;

            await _productDbContext.SaveChangesAsync();

            return Ok(product);
        }
    }
}
