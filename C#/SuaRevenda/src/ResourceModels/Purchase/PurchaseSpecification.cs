namespace SuaRevenda.ResourceModels;

public class PurchaseSpecification
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }

    public PieceSpecification[] Pieces { get; set; } = null!;
}
