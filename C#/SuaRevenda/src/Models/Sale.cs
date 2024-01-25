namespace SuaRevenda.Models;

public class Sale
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }

    public ICollection<Piece> Pieces { get; set; } = null!;
}
