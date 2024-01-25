namespace SuaRevenda.Models {
public class Purchase : Origin {
  public double Price { get; set; }

  public override void makeSell() { throw new NotImplementedException(); }
}
}
