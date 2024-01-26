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
        var sales = await _salesServices.GetSales();
        return sales.Select(s => s.ToSaleSpecification()).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleSpecification>> GetSale(long id)
    {
        try
        {
            var sale = await TryGetSale(id);
            return sale;
        }
        catch (NoSuchSaleException e)
        {
            return NotFound(e.Message);
        }
    }

    private async Task<ActionResult<SaleSpecification>> TryGetSale(long id)
    {
        var sale = await _salesServices.GetSale(id);
        SaleSpecification spec = sale.ToSaleSpecification();
        return spec;
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
        try
        {
            return await TryCreateSale(sale);
        }
        catch (PieceAlreadySoldException e)
        {
            return BadRequest(e.Message);
        }
    }

    private async Task<ActionResult<SaleSpecification>> TryCreateSale(CreateSaleSpecification sale)
    {
        long[] piecesInSale = sale.PiecesIds.Select(p => p.Id).ToArray();
        List<Piece> pieces = await _context.Pieces.Where(p => piecesInSale.Contains(p.Id)).ToListAsync();
        var newSale = await _salesServices.SellPieces(sale, pieces);
        return CreatedAtAction(nameof(GetSale), new { id = newSale.Id }, newSale.ToSaleSpecification());
    }

    private bool SaleExists(long id)
    {
        return _context.Sales.Any(e => e.Id == id);
    }
}

