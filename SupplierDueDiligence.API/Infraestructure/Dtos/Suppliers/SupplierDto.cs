using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierDueDiligence.API.Domain.Models;

namespace SupplierDueDiligence.API.Infraestructure.Dtos.Suppliers;

public class SupplierDto
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Business name is required.")]
    [MaxLength(200, ErrorMessage = "Business name cannot exceed 200 characters.")]
    public required string BusinessName { get; set; }

    [MaxLength(200, ErrorMessage = "Commercial name cannot exceed 200 characters.")]
    public string? CommercialName { get; set; }

    [Required(ErrorMessage = "TaxId is required.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "TaxId must be exactly 11 digits.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "TaxId must contain exactly 11 digits.")]
    public required string TaxId { get; set; } = null!;

    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? PhoneNumber { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [Url(ErrorMessage = "Invalid website URL.")]
    public string? Website { get; set; }

    [MaxLength(300, ErrorMessage = "Address cannot exceed 300 characters.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "CountryId is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "CountryId must be greater than 0.")]
    public required int CountryId { get; set; }
    public string? Country { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Annual revenue must be a positive number.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? AnnualRevenue { get; set; }
    public DateTime? LastUpdated { get; set; }

    public static SupplierDto FromEntity(Supplier supplier)
    {
        return new SupplierDto
        {
            Id = supplier.Id,
            BusinessName = supplier.BusinessName,
            CommercialName = supplier.CommercialName,
            TaxId = supplier.TaxId,
            PhoneNumber = supplier.PhoneNumber,
            Email = supplier.Email,
            Website = supplier.Website,
            Address = supplier.Address,
            CountryId = supplier.Country?.Id ?? 0,
            Country = supplier.Country?.Name,
            AnnualRevenue = supplier.AnnualRevenue,
            LastUpdated = supplier.LastUpdated
        };
    }
}
