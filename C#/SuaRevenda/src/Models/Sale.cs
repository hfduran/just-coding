using SuaRevenda.ResourceModels;
namespace SuaRevenda.Models;

public class Sale
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }

    public ICollection<Piece> Pieces { get; set; } = null!;

    public SaleSpecification ToSaleSpecification()
    {
        return new SaleSpecification
        {
            Id = Id,
            Price = Price,
            Date = Date,
            PiecesSold = Pieces.Select(p => p.ToPieceSpecification()).ToArray()
        };
    }
}
