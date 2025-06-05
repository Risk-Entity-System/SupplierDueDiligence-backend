using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class SupplierNotFoundException(int supplierId) : AppException(
        errorType: ErrorType.NOT_FOUND,
        details: $"Supplier with ID {supplierId} was not found.",
        errorCode: 404,
        message: "Supplier not found."
          )
{
}
