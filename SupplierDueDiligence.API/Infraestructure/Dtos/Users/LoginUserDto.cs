using System;

namespace SupplierDueDiligence.API.Infraestructure.Dtos.Users;

public class LoginUserDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}