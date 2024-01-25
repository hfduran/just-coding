using SuaRevenda.ResourceModels;
using SuaRevenda.Models;
using SuaRevenda.Data;
namespace SuaRevenda.Services;

public class PieceAlreadySoldException : Exception
{
    public PieceAlreadySoldException(Piece piece) : base(
        $"Piece of id = '{piece.Id}' has already been sold"
    )
    { }
}

public class SalesServices
{
    private readonly DataContext _context;

    public SalesServices(DataContext context)
    {
        _context = context;
    }

    public async Task<Sale> SellPieces(CreateSaleSpecification sale, List<Piece> pieces)
    {
        ValidatePiecesToSell(pieces);

        var newSale = new Sale
        {
            Price = sale.Price,
            Date = sale.Date,
            Pieces = pieces
        };

        _context.Sales.Add(newSale);
        await _context.SaveChangesAsync();

        return newSale;
    }

    private void ValidatePiecesToSell(List<Piece> pieces)
    {
        foreach (var piece in pieces)
        {
            ValidatePieceToSell(piece);
        }
    }

    private void ValidatePieceToSell(Piece piece)
    {
        if (piece.SaleId != null)
        {
            throw new PieceAlreadySoldException(piece);
        }
    }
}
