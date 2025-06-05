namespace SupplierDueDiligence.API.Domain.Models;

public class Supplier
{
    public int Id { get; set; }
    public required string BusinessName { get; set; }
    public string? CommercialName { get; set; }
    public required string TaxId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Address { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
    public decimal? AnnualRevenue { get; set; }
    public DateTime LastUpdated { get; set; }
}