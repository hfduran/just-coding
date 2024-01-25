namespace SuaRevenda.ResourceModels;

public class CreateSaleSpecification
{
    public double Price { get; set; }
    public DateTime Date { get; set; }

    public IdEntity[] PiecesIds { get; set; } = null!;
}
