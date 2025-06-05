using SupplierDueDiligence.API.Domain.Enums;

namespace SupplierDueDiligence.API.Config.Exceptions;

public class AppException(
    ErrorType errorType,
    string details,
    int errorCode = 500,
    string message = "An error occurred while processing your request. Please try again or contact support."
    ) : Exception(message)
{
    public ErrorType Type { get; } = errorType;
    public string Details { get; } = details;
    public int ErrorCode { get; } = errorCode;
}