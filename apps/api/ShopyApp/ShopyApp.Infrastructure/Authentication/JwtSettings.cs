namespace ShopyApp.Infrastructure;

public class JwtSettings
{
    public string? Audience { get; init; }
    public string? Issuer { get; init; }
    public int ExpiringMinutes { get; init; }
    public string? Secret { get; init; }
}
