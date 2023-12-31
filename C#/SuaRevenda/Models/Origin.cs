namespace SuaRevenda.Models;

public abstract class Origin
{
    public long Id { get; set; }
    public abstract void makeSell();
    public DateTime Date { get; set; }
    public ICollection<Piece> Pieces { get; set; } = null!; // maybe it will throw error
}
