using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class InternalServerException(
    string details = "An unexpected error occurred on the server.",
    int errorCode = 500,
    string message = "Internal Server Error"
    ) : AppException(ErrorType.INTERNAL_SERVER, details, errorCode, message)
{
}