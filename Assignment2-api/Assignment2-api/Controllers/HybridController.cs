using Assignment2_api.Context;
using Assignment2_api.Models;
using Assignment2_api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Assignment2_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HybridController : ControllerBase
    {
        private readonly DataContext _context;

        public HybridController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.ProductCatalog == null)
            {
                return NotFound();
            }
            return await _context.ProductCatalog.ToListAsync();
        }
        [HttpGet("Categories/{Cat}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string Cat)
        {
            var products = new List<ProductResponse>();
            foreach (var product in _context.ProductCatalog.ToList())
            {
                if(product.Category.Name == Cat)
                products.Add(new ProductResponse
                {
                    Artikelnummer = product.Artikelnummer,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Specification = product.Specification,
                    Category = product.Category

                });
            }
            if (_context.ProductCatalog == null)
            {
                return NotFound();
            }
            return new OkObjectResult(products);

        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductRequest product)
        {
            if (_context.ProductCatalog == null)
            {
                return Problem("Entity set 'DataContext.Products'  is null.");
            }
            var productEntity = new Product
            {
                //When posting spec, the json must contain backslashes. Example: "{\"Allmänt\": {\"Tillverkare\": \"Microsoft\",\"Modell\": \"MC-117\"}}"
                //You can use JSON.stringify twice to get this result.
                Artikelnummer = product.Artikelnummer,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Specification = product.Specification,
                Category = product.Category
            };
            _context.Add(productEntity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(productEntity);
        }

    }
}
