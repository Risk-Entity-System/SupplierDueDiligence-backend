namespace SupplierDueDiligence.API.Infraestructure.Dtos.Screening;

public class ScrappingSource
{
    public required string Name { get; set; }
    public required int Hits { get; set; }
    public required List<ScrappingResult> Results { get; set; }
}