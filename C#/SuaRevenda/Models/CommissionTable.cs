namespace SuaRevenda.Models;

public class CommissionTable
{
    public long Id { get; set; }
    public long SupplierId { get; set; }
    public long ConsignedId { get; set; }

    public long Ratio { get; set; }
    public Supplier Supplier { get; set; } = null!;
    public Consigned Consigned { get; set; } = null!;
}
