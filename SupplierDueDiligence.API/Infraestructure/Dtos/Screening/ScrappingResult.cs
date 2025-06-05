namespace SupplierDueDiligence.API.Infraestructure.Dtos.Screening;

public class ScrappingResult
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? SanctionImposed { get; set; }
    public string? Date { get; set; }
    public string? Grounds { get; set; }
    public string? SanctionPrograms { get; set; }
}