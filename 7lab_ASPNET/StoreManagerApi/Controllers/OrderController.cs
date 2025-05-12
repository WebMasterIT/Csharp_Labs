using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Data;
using StoreManagerApi.Models;

namespace StoreManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public OrderController(StoreDbContext context)
        {
            _context = context;
        }

        // Только для авторизованных пользователей
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        // Только для авторизованных пользователей
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            if (order == null || order.Items == null || !order.Items.Any())
                return BadRequest("Пустой заказ или отсутствуют товары.");

            var productIds = order.Items.Select(i => i.ProductId).Distinct().ToList();
            var existingProducts = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToListAsync();

            if (existingProducts.Count != productIds.Count)
                return BadRequest("Один или несколько ProductId не найдены.");

            foreach (var item in order.Items)
            {
                item.Product = null;
                item.Order = null;
            }

            _context.Orders.Add(order);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Ошибка сохранения заказа: {ex.InnerException?.Message ?? ex.Message}");
            }

            var savedOrder = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            return CreatedAtAction(nameof(Get), new { id = savedOrder.Id }, savedOrder);
        }

        // Удаление заказов — только для админа
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
