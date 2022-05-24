using Microsoft.AspNetCore.Mvc;
using API.Data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase

    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}