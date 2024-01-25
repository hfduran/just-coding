namespace SuaRevenda.ResourceModels;

public class SaleSpecification
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }

    public PieceSpecification[] PiecesSold { get; set; } = null!;
}
