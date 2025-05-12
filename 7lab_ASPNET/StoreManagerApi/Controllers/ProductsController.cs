using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Data;
using StoreManagerApi.Models;

namespace StoreManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public ProductController(StoreDbContext context) => _context = context;

        // Доступен всем
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() =>
            await _context.Products.ToListAsync();

        // Доступен всем
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        // Только для админа
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // Только для админа
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Только для админа
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
