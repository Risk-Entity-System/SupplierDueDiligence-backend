
using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class UnauthorizedException(string details, string message = "Unauthorized access.") : AppException(ErrorType.UNAUTHORIZED, details, 401, message)
{
}
