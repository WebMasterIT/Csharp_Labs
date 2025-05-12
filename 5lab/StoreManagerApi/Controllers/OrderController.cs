using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Data;
using StoreManagerApi.Models;

namespace StoreManagerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly StoreDbContext _context;
    public OrderController(StoreDbContext context) => _context = context;

    [HttpPost]
    public async Task<ActionResult> Create(Order order)
    {
        if (order == null || order.Items == null || !order.Items.Any())
            return BadRequest("Заказ пуст или не содержит товаров.");

        order.OrderDate = DateTime.Now;

        foreach (var item in order.Items)
        {
            item.Product = null;
            item.Order = null;
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> Get()
    {
        var orders = await _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .ToListAsync();

        return orders;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        return order == null ? NotFound() : Ok(order);
    }
}
