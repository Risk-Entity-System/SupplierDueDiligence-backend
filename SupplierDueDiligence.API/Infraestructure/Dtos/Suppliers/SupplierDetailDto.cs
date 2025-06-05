using SupplierDueDiligence.API.Domain.Models;

namespace SupplierDueDiligence.API.Infraestructure.Dtos.Suppliers;

public class SupplierDetailDto
{
    public required int Id { get; set; }
    public required string BusinessName { get; set; }
    public required string? CommercialName { get; set; }
    public required string TaxId { get; set; } = null!;
    public required string? PhoneNumber { get; set; }
    public required string? Email { get; set; }
    public required string? Website { get; set; }
    public required string? Address { get; set; }
    public required CountryDto Country { get; set; }
    public required decimal? AnnualRevenue { get; set; }
    public required DateTime LastUpdated { get; set; }

    public static SupplierDetailDto FromEntity(Supplier supplier)
    {
        return new SupplierDetailDto
        {
            Id = supplier.Id,
            BusinessName = supplier.BusinessName,
            CommercialName = supplier.CommercialName,
            TaxId = supplier.TaxId,
            PhoneNumber = supplier.PhoneNumber,
            Email = supplier.Email,
            Website = supplier.Website,
            Address = supplier.Address,
            Country = CountryDto.FromEntity(supplier.Country),
            AnnualRevenue = supplier.AnnualRevenue,
            LastUpdated = supplier.LastUpdated
        };
    }
}
