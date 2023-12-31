namespace SuaRevenda.Models;

public class Supplier
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    public CommissionTable CommissionTable { get; set; } = null!;
}
