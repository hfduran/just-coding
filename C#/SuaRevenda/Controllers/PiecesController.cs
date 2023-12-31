using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuaRevenda.Data;
using SuaRevenda.Models;

namespace SuaRevenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesController : ControllerBase
    {
        private readonly DataContext _context;

        public PiecesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Pieces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piece>>> GetPieces()
        {
            return await _context.Pieces.ToListAsync();
        }

        // GET: api/Pieces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piece>> GetPiece(long id)
        {
            var piece = await _context.Pieces.FindAsync(id);

            if (piece == null)
            {
                return NotFound();
            }

            return piece;
        }

        // PUT: api/Pieces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiece(long id, Piece piece)
        {
            if (id != piece.Id)
            {
                return BadRequest();
            }

            _context.Entry(piece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceExists(id))
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

        // POST: api/Pieces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Piece>> PostPiece(Piece piece)
        {
            _context.Pieces.Add(piece);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiece", new { id = piece.Id }, piece);
        }

        // DELETE: api/Pieces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiece(long id)
        {
            var piece = await _context.Pieces.FindAsync(id);
            if (piece == null)
            {
                return NotFound();
            }

            _context.Pieces.Remove(piece);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PieceExists(long id)
        {
            return _context.Pieces.Any(e => e.Id == id);
        }
    }
}
