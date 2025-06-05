using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;

public class ApiError
{
    public required ErrorType Type { get; set; }
    public required string Details { get; set; } = string.Empty;
    public required int Code { get; set; }
}
