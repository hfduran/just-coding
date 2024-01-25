namespace SuaRevenda.ResourceModels;

// without the Pieces relation
public class PurchaseUpdateSpecification
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
}
