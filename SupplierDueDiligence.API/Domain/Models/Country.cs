namespace SupplierDueDiligence.API.Domain.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Iso { get; set; }
    public List<Supplier> Suppliers { get; set; } = new();
}
