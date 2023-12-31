namespace SuaRevenda.Models;

public class PieceSold : Piece
{
    public long SaleId { get; set; }
    public Sale Sale { get; set; } = null!;
}
