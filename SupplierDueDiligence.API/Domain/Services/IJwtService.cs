using SupplierDueDiligence.API.Domain.Models;

namespace SupplierDueDiligence.API.Domain.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}
