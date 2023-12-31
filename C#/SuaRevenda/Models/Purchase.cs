namespace SuaRevenda.Models
{
    public class Purchase : Origin
    {
        public long Price { get; set; }
        public override void makeSell()
        {
            throw new NotImplementedException();
        }
    }
}
