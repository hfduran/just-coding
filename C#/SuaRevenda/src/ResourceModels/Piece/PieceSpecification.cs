namespace SuaRevenda.ResourceModels;

public class PieceSpecification
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? Type { get; set; }
    public long UserId { get; set; }
}
