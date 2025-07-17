namespace SupplierDueDiligence.API.Config.Settings;

public class JwtSettings
{
    public required string Key { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string CookieKey { get; init; }
    public required int ExpiresInMinutes { get; init; }

}
