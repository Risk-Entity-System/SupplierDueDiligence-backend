using SupplierDueDiligence.API.Domain.Models;

namespace SupplierDueDiligence.API.Infraestructure.Dtos.Suppliers;

public class CountryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Iso { get; set; }

    public static CountryDto FromEntity(Country country)
    {
        return new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
            Iso = country.Iso
        };
    }
}
