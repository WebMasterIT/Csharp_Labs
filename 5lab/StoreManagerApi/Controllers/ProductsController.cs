using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Data;
using StoreManagerApi.Models;

namespace StoreManagerApi.Controllers;

[ApiController]
[Route("api/[controller]")] // api/product
public class ProductController : ControllerBase
{
    private readonly StoreDbContext _context;

    public ProductController(StoreDbContext context)
    {
        _context = context;
    }

    // GET: api/product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll() =>
        await _context.Products.ToListAsync();

    // GET: api/product/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    // POST: api/product
    [HttpPost]
    public async Task<ActionResult> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // PUT: api/product/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest("ID mismatch");

        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/product/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
