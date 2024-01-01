namespace SuaRevenda.Models;

public class Sale
{
    public long Id { get; set; }
    public double Price { get; set; }

    public ICollection<PieceSold> PiecesSold { get; } = new List<PieceSold>();
    public long UserId { get; set; }
    public User User { get; set; } = null!;
}
