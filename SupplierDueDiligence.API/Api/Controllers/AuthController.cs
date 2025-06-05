using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupplierDueDiligence.API.Config.Exceptions;
using SupplierDueDiligence.API.Data;
using SupplierDueDiligence.API.Domain.Models;
using SupplierDueDiligence.API.Domain.Services;
using SupplierDueDiligence.API.Infraestructure.Dtos.Users;
using SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;

namespace SupplierDueDiligence.API.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(AppDbContext context, IJwtService jwtService) : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly PasswordHasher<User> _hasher = new();
    private readonly IJwtService _jwtService = jwtService;


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserDto dto)
    {
        var errorMessage = "Email or password is incorrect.";
        var user = _context.Users.SingleOrDefault(u => u.Email == dto.Email) ?? throw new UnauthorizedException(errorMessage, errorMessage);

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed) throw new UnauthorizedException(errorMessage, errorMessage);

        var token = _jwtService.GenerateToken(user);

        return Ok(ApiResponse<string>.Success("Login successful", token));
    }


    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserDto dto)
    {
        var email = dto.Email;
        if (_context.Users.Any(u => u.Email == email)) throw new EmailAlreadyRegisteredException(email);

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
        };
        user.PasswordHash = _hasher.HashPassword(user, dto.Password);

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(ApiResponse<bool>.Success("User was created successfully", true));
    }
}
