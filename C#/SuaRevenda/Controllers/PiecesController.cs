using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuaRevenda.Data;
using SuaRevenda.Models;
using SuaRevenda.ResourceModels;

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
        public async Task<ActionResult<IEnumerable<PieceSpecification>>> GetPieces()
        {
            var pieces = _context.Pieces
                .Select(p => new PieceSpecification
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    UserId = p.UserId
                });
            return await pieces.ToListAsync();
        }

        // GET: api/Pieces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PieceSpecification>> GetPiece(long id)
        {
            var piece = await _context.Pieces.FindAsync(id);

            if (piece == null)
            {
                return NotFound();
            }

            return new PieceSpecification
            {
                Id = piece.Id,
                Name = piece.Name,
                Type = piece.Type,
                UserId = piece.UserId
            };
        }

        // PUT: api/Pieces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiece(long id, PieceSpecification piece)
        {
            var pieceToUpdate = await _context.Pieces.FindAsync(id);

            if (pieceToUpdate == null)
            {
                return NotFound();
            }

            pieceToUpdate.Name = piece.Name;
            pieceToUpdate.Type = piece.Type;
            _context.Entry(pieceToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
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
