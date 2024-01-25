using Microsoft.AspNetCore.Mvc;
using SuaRevenda.Data;
using SuaRevenda.Models;
using SuaRevenda.ResourceModels;

namespace SuaRevenda.Controllers
{
    [Route("api/Purchases/{purchaseId}/[controller]")]
    [ApiController]
    public class PurchasesPiecesController : ControllerBase
    {
        private readonly DataContext _context;

        public PurchasesPiecesController(DataContext context) { _context = context; }

        [HttpPost]
        public async Task<ActionResult<PieceSpecification>>
        PostPiece([FromRoute] long purchaseId, PieceSpecification[] pieces)
        {
            var purchase = await _context.Purchases.FindAsync(purchaseId);
            if (purchase == null)
            {
                return NotFound();
            }
            foreach (var piece in pieces)
            {
                purchase.Pieces.Add(new Piece
                {
                    Name = piece.Name,
                    Type = piece.Type,
                    UserId = piece.UserId
                });
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
