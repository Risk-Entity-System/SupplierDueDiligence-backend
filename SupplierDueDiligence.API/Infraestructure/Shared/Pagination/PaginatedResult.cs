namespace SupplierDueDiligence.API.Infraestructure.Shared.Pagination;

public class PaginatedResult<T>(List<T> data, int totalItems, int page, int pageSize)
{
    public List<T> Data { get; set; } = data;
    public PaginationMetadata Pagination { get; set; } = new PaginationMetadata(totalItems, page, pageSize);
}