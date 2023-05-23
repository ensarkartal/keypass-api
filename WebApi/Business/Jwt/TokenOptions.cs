namespace WebApi.Business.Jwt;

public class DevNetTokenOptions
{
    public string? Audience { get; set; }
    public string? Issuer { get; set; }
    public string SecurityKey { get; set; }
}