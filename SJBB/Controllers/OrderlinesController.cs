using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SJBB.Models;

namespace SJBB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderlinesController : ControllerBase
    {
        private readonly SJBBDbContext _context;

        public OrderlinesController(SJBBDbContext context)
        {
            _context = context;
        }

        // GET: api/Orderlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderline>>> GetOrderline()
        {
          if (_context.Orderline == null)
          {
              return NotFound();
          }
            return await _context.Orderline.ToListAsync();
        }

        // GET: api/Orderlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderline>> GetOrderline(int id)
        {
            var order = await _context.Orderline.Include(x => x.Product)
                                 .Include(x => x.Order)
                                 .SingleOrDefaultAsync(x => x.Id == id);

            if (_context.Orderline == null)
          {
              return NotFound();
          }
            var orderline = await _context.Orderline.FindAsync(id);

            if (orderline == null)
            {
                return NotFound();
            }

            return orderline;
        }

        private async Task<IActionResult> RecalculateOrderTotal(int ordersId) {
            var order = await _context.Orders.FindAsync(ordersId);
            order.Total = (
                from ol in _context.Orderline
                join p in _context.Products         // possible group join using book, statue..etc classes and products.
                on ol.OrderId equals p.Id
                where ol.OrderId == ordersId
                select new {linetotal = ol.Quantity * p.Price,
                
                }).Sum(x => x.linetotal);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // PUT: api/Orderlines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderline(int id, Orderline orderline)
        {
            if (id != orderline.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orderlines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orderline>> PostOrderline(Orderline orderline)
        {
          if (_context.Orderline == null)
          {
              return Problem("Entity set 'SJBBDbContext.Orderline'  is null.");
          }
            _context.Orderline.Add(orderline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderline", new { id = orderline.Id }, orderline);
        }

        // DELETE: api/Orderlines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderline(int id)
        {
            if (_context.Orderline == null)
            {
                return NotFound();
            }
            var orderline = await _context.Orderline.FindAsync(id);
            if (orderline == null)
            {
                return NotFound();
            }

            _context.Orderline.Remove(orderline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderlineExists(int id)
        {
            return (_context.Orderline?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
