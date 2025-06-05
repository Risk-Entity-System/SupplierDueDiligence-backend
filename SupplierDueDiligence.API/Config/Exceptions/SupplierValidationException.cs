using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class SupplierValidationException(string details) : AppException(ErrorType.VALIDATION, details, 400, details)
{
}
