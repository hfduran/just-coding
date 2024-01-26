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
        var salesSpecs = sales.Select(s => s.ToSaleSpecification()).ToList();
        return Ok(salesSpecs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleSpecification>> GetSale(long id)
    {
        try
        {
            var sale = await TryGetSale(id);
            return Ok(sale);
        }
        catch (NoSuchSaleException e)
        {
            return NotFound(e.Message);
        }
    }

    private async Task<SaleSpecification> TryGetSale(long id)
    {
        var sale = await _salesServices.GetSale(id);
        SaleSpecification spec = sale.ToSaleSpecification();
        return spec;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSale(long id, SaleUpdateSpecification saleSpec)
    {
        if (id != saleSpec.Id)
        {
            return BadRequest("Id specified in the URL does not match the one in the body");
        }
        try
        {
            return Ok(await TryEditSale(saleSpec));
        }
        catch (NoSuchSaleException e)
        {
            return NotFound(e.Message);
        }
    }

    private async Task<Sale> TryEditSale(SaleUpdateSpecification saleSpec)
    {
        return await _salesServices.EditSale(saleSpec);
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

