using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class NotFoundException(string details) : AppException(ErrorType.NOT_FOUND, details, 404, "Resource not found.")
{
}
