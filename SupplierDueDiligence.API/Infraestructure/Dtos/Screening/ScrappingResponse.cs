namespace SupplierDueDiligence.API.Infraestructure.Dtos.Screening;

public class ScrappingResponse
{
    public required string Query { get; set; }
    public required int TotalHits { get; set; }
    public required List<ScrappingSource> Sources { get; set; }
}
