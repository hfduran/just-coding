using SuaRevenda.ResourceModels;
namespace SuaRevenda.Models;

public class Piece
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? Type { get; set; }

    public long OriginId { get; set; }
    public Origin Origin { get; set; } = null!;
    public long UserId { get; set; }
    public User User { get; set; } = null!;
    public long? SaleId { get; set; } = null!;
    public Sale? Sale { get; set; } = null!;

    public PieceSpecification ToPieceSpecification()
    {
        return new PieceSpecification
        {
            Id = Id,
            Name = Name,
            Type = Type,
            UserId = UserId
        };
    }
}
