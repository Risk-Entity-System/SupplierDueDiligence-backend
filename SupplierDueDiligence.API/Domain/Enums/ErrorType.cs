namespace SupplierDueDiligence.API.Domain.Enums;

public enum ErrorType
{
    CONFLICT,
    METHOD_NOT_ALLOWED,
    VALIDATION,
    UNAUTHORIZED,
    BAD_REQUEST,
    NOT_FOUND,
    INTERNAL_SERVER,
    UNKNOWN_ERROR,
}