using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupplierDueDiligence.API.Config.Exceptions;
using SupplierDueDiligence.API.Config.Settings;
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

    [HttpGet]
    [Authorize]
    public IActionResult Me()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier) ?? throw new UnauthorizedException("No user ID claim");

        var userId = userIdClaim.Value;

        var user = _context.Users
            .Where(u => u.Id.ToString() == userId)
            .Select(u => new UserDto { Username = u.Username, Email = u.Email })
            .SingleOrDefault() ?? throw new UnauthorizedException("User not found or unauthorized.");

        return Ok(ApiResponse<UserDto>.Success("User retrieved successfully", user));
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserDto dto)
    {
        var user = _context.Users.SingleOrDefault(u => u.Email == dto.Email) ?? throw new InvalidCredentialsException();

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed) throw new InvalidCredentialsException();

        var token = _jwtService.GenerateToken(user);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false, // TODO: SECURE HTTPS
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(_jwtService.ExpiresInMinutes)
        };

        Response.Cookies.Append(_jwtService.CookieKey, token, cookieOptions);

        UserDto auth = new()
        {
            Username = user.Username,
            Email = user.Email
        };


        return Ok(ApiResponse<UserDto>.Success("Login successful", auth));
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
