using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class InvalidCredentialsException()
    : AppException(ErrorType.INVALID_CREDENTIALS, "Email or password is incorrect.", 401, "Email or password is incorrect.")
{

}
