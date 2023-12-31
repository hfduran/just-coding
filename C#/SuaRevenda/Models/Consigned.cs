namespace SuaRevenda.Models;

public class Consigned : Origin
{
    public CommissionTable CommissionTable { get; set; } = null!;
    public override void makeSell()
    {
        throw new NotImplementedException();
    }
}
