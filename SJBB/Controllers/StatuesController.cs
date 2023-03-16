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
    public class StatuesController : ControllerBase
    {
        private readonly SJBBDbContext _context;

        public StatuesController(SJBBDbContext context)
        {
            _context = context;
        }

        // GET: api/Statues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statue>>> GetStatues()
        {
          if (_context.Statues == null)
          {
              return NotFound();
          }
            return await _context.Statues.ToListAsync();
        }

        // GET: api/Statues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statue>> GetStatue(int id)
        {
          if (_context.Statues == null)
          {
              return NotFound();
          }
            var statue = await _context.Statues.FindAsync(id);

            if (statue == null)
            {
                return NotFound();
            }

            return statue;
        }

        // PUT: api/Statues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatue(int id, Statue statue)
        {
            if (id != statue.Id)
            {
                return BadRequest();
            }

            _context.Entry(statue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueExists(id))
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

        // POST: api/Statues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statue>> PostStatue(Statue statue)
        {
          if (_context.Statues == null)
          {
              return Problem("Entity set 'SJBBDbContext.Statues'  is null.");
          }
            _context.Statues.Add(statue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatue", new { id = statue.Id }, statue);
        }

        // DELETE: api/Statues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatue(int id)
        {
            if (_context.Statues == null)
            {
                return NotFound();
            }
            var statue = await _context.Statues.FindAsync(id);
            if (statue == null)
            {
                return NotFound();
            }

            _context.Statues.Remove(statue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatueExists(int id)
        {
            return (_context.Statues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
