using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuaRevenda.Services;
using SuaRevenda.Data;
using SuaRevenda.Models;
using SuaRevenda.ResourceModels;

namespace SuaRevenda.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly SalesServices _salesServices;

    public SalesController(DataContext context)
    {
        _context = context;
        _salesServices = new SalesServices(context);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleSpecification>>> GetSales()
    {
        var sales = _context.Sales.Select(
            s =>
                new SaleSpecification
                {
                    Id = s.Id,
                    Price = s.Price,
                    Date = s.Date,
                    PiecesSold = s.Pieces.Select(
                        p =>
                            new PieceSpecification
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Type = p.Type,
                                UserId = p.UserId
                            }
                    )
                        .ToArray()
                }
        );

        return await sales.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleSpecification>> GetSale(long id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale == null)
        {
            return NotFound();
        }
        return new SaleSpecification
        {
            Id = sale.Id,
            Price = sale.Price,
            Date = sale.Date,
            PiecesSold = sale.Pieces.Select(
                p =>
                    new PieceSpecification
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Type = p.Type,
                        UserId = p.UserId
                    }
            )
                .ToArray()
        };
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSale(long id, SaleUpdateSpecification sale)
    {
        if (id != sale.Id)
        {
            return BadRequest();
        }
        var saleToUpdate = await _context.Sales.FindAsync(id);
        if (saleToUpdate == null)
        {
            return NotFound();
        }
        saleToUpdate.Price = sale.Price;
        saleToUpdate.Date = sale.Date;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SaleExists(id))
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

    [HttpPost]
    public async Task<ActionResult<SaleSpecification>> PostSale(CreateSaleSpecification sale)
    {
        long[] piecesInSale = sale.PiecesIds.Select(p => p.Id).ToArray();
        List<Piece> pieces = await _context.Pieces.Where(p => piecesInSale.Contains(p.Id)).ToListAsync();

        try
        {
            return await TryToSellPieces(sale, pieces);
        }
        catch (PieceAlreadySoldException e)
        {
            return BadRequest(e.Message);
        }
    }

    private async Task<ActionResult<SaleSpecification>> TryToSellPieces(CreateSaleSpecification sale, List<Piece> pieces)
    {
        var newSale = await _salesServices.SellPieces(sale, pieces);
        return CreatedAtAction(nameof(GetSale), new { id = newSale.Id }, new SaleSpecification
        {
            Id = newSale.Id,
            Price = newSale.Price,
            Date = newSale.Date,
            PiecesSold = newSale.Pieces.Select(
                p =>
                    new PieceSpecification
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Type = p.Type,
                        UserId = p.UserId
                    }
            )
                .ToArray()
        });
    }

    private bool SaleExists(long id)
    {
        return _context.Sales.Any(e => e.Id == id);
    }
}

