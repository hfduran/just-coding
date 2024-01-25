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
    public class PurchasesController : ControllerBase
    {
        private readonly DataContext _context;

        public PurchasesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseSpecification>>> GetPurchase([FromHeader] long userId)
        {
            var purchases = _context.Purchases
                .Select(p => new PurchaseSpecification
                {
                    Id = p.Id,
                    Price = p.Price,
                    Date = p.Date,
                    Pieces = p.Pieces.Select(p => new PieceSpecification
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Type = p.Type,
                        UserId = p.UserId
                    }).ToArray()
                });
            return await purchases.ToListAsync();
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseSpecification>> GetPurchase([FromHeader] long userId, long id)
        {
            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return new PurchaseSpecification
            {
                Id = purchase.Id,
                Price = purchase.Price,
                Date = purchase.Date,
                Pieces = purchase.Pieces.Select(p => new PieceSpecification
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    UserId = p.UserId
                }).ToArray()
            };
        }

        // PUT: api/Purchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(long id, PurchaseSpecification purchase)
        {
            if (id != purchase.Id)
            {
                return BadRequest();
            }

            var purchaseToUpdate = await _context.Purchases.FindAsync(id);
            if (purchaseToUpdate == null)
            {
                return NotFound();
            }

            purchaseToUpdate.Price = purchase.Price;
            purchaseToUpdate.Date = purchase.Date;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }

            return NoContent();
        }

        // POST: api/Purchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseSpecification>> PostPurchase(PurchaseSpecification purchase)
        {
            var purchaseToCreate = new Purchase
            {
                Price = purchase.Price,
                Date = purchase.Date,
                Pieces = purchase.Pieces.Select(p => new Piece
                {
                    Name = p.Name,
                    Type = p.Type,
                    UserId = p.UserId
                }).ToList()
            };
            _context.Add(purchaseToCreate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtAction("GetPurchase", new { id = purchaseToCreate.Id }, purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(long id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseExists(long id)
        {
            return _context.Purchases.Any(e => e.Id == id);
        }
    }
}
