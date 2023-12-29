using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreatApi.Models;

namespace GreatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreatItemsController : ControllerBase
    {
        private readonly GreatContext _context;

        public GreatItemsController(GreatContext context)
        {
            _context = context;
        }

        // GET: api/GreatItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreatItem>>> GetGreatItem()
        {
            return await _context.GreatItem.ToListAsync();
        }

        // GET: api/GreatItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreatItem>> GetGreatItem(long id)
        {
            var greatItem = await _context.GreatItem.FindAsync(id);

            if (greatItem == null)
            {
                return NotFound();
            }

            return greatItem;
        }

        // PUT: api/GreatItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreatItem(long id, GreatItem greatItem)
        {
            if (id != greatItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(greatItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreatItemExists(id))
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

        // POST: api/GreatItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GreatItem>> PostGreatItem(GreatItem greatItem)
        {
            _context.GreatItem.Add(greatItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreatItem", new { id = greatItem.Id }, greatItem);
        }

        // DELETE: api/GreatItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGreatItem(long id)
        {
            var greatItem = await _context.GreatItem.FindAsync(id);
            if (greatItem == null)
            {
                return NotFound();
            }

            _context.GreatItem.Remove(greatItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GreatItemExists(long id)
        {
            return _context.GreatItem.Any(e => e.Id == id);
        }
    }
}
