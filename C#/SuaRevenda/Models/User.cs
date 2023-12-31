namespace SuaRevenda.Models;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<Piece> Pieces { get; set; } = null!;
    public ICollection<Sale> Sales { get; set; } = null!;
}
