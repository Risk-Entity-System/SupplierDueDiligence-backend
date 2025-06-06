namespace SupplierDueDiligence.API.Infraestructure.Dtos.Suppliers;

public class SupplierQueryParameters
{
    public string? BusinessName { get; set; }
    public int? CountryId { get; set; }
    public string? TaxId { get; set; }
    public DateTime? LastUpdatedFrom { get; set; }
    public DateTime? LastUpdatedTo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
