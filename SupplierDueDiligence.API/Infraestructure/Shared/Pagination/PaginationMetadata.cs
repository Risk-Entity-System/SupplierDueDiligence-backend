namespace SupplierDueDiligence.API.Infraestructure.Shared.Pagination;

public class PaginationMetadata
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalItems { get; }
    public bool HasNextPage => Page < TotalPages;
    public bool HasPreviousPage => Page > 1;
    public int? NextPage => HasNextPage ? Page + 1 : null;
    public int? PreviousPage => HasPreviousPage ? Page - 1 : null;

    public PaginationMetadata(int totalItems, int page, int pageSize)
    {
        TotalItems = totalItems;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        Page = Math.Clamp(page, 1, TotalPages == 0 ? 1 : TotalPages);
    }
}