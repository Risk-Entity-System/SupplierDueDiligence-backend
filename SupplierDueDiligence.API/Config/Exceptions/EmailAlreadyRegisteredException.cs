using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class EmailAlreadyRegisteredException(string email) : AppException(
        errorType: ErrorType.CONFLICT,
        details: $"The email '{email}' is already registered in the system.",
        errorCode: 409,
        message: "The email is already in use."
        )
{
}
