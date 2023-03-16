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
    public class MiscellaneousController : ControllerBase
    {
        private readonly SJBBDbContext _context;

        public MiscellaneousController(SJBBDbContext context)
        {
            _context = context;
        }

        // GET: api/Miscellaneous
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Miscellaneous>>> GetMiscellaneous()
        {
          if (_context.Miscellaneous == null)
          {
              return NotFound();
          }
            return await _context.Miscellaneous.ToListAsync();
        }

        // GET: api/Miscellaneous/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Miscellaneous>> GetMiscellaneous(int id)
        {
          if (_context.Miscellaneous == null)
          {
              return NotFound();
          }
            var miscellaneous = await _context.Miscellaneous.FindAsync(id);

            if (miscellaneous == null)
            {
                return NotFound();
            }

            return miscellaneous;
        }

        // PUT: api/Miscellaneous/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiscellaneous(int id, Miscellaneous miscellaneous)
        {
            if (id != miscellaneous.Id)
            {
                return BadRequest();
            }

            _context.Entry(miscellaneous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiscellaneousExists(id))
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

        // POST: api/Miscellaneous
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Miscellaneous>> PostMiscellaneous(Miscellaneous miscellaneous)
        {
          if (_context.Miscellaneous == null)
          {
              return Problem("Entity set 'SJBBDbContext.Miscellaneous'  is null.");
          }
            _context.Miscellaneous.Add(miscellaneous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiscellaneous", new { id = miscellaneous.Id }, miscellaneous);
        }

        // DELETE: api/Miscellaneous/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiscellaneous(int id)
        {
            if (_context.Miscellaneous == null)
            {
                return NotFound();
            }
            var miscellaneous = await _context.Miscellaneous.FindAsync(id);
            if (miscellaneous == null)
            {
                return NotFound();
            }

            _context.Miscellaneous.Remove(miscellaneous);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiscellaneousExists(int id)
        {
            return (_context.Miscellaneous?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
