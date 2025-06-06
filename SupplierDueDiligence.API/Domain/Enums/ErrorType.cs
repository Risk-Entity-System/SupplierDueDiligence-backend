namespace SupplierDueDiligence.API.Domain.Enums;

public enum ErrorType
{
    INVALID_CREDENTIALS,
    CONFLICT,
    METHOD_NOT_ALLOWED,
    VALIDATION,
    UNAUTHORIZED,
    BAD_REQUEST,
    NOT_FOUND,
    INTERNAL_SERVER,
    UNKNOWN_ERROR,
}