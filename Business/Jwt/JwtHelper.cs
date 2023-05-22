using System.IdentityModel.Tokens.Jwt;
using Entity.Tables.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.Jwt;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private readonly DevNetTokenOptions? _tokenOptions;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<DevNetTokenOptions>();
    }
    public TAccessToken CreateToken<TAccessToken>(AppUser? user) where TAccessToken : IAccessToken, new()
    {
        var issuer = _tokenOptions!.Issuer!;
        var audience = _tokenOptions!.Audience!;
        var key = Encoding.ASCII.GetBytes(_tokenOptions!.SecurityKey!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user!.Id!),
                new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TAccessToken()
        {
            Token = tokenHandler.WriteToken(token)
        };
    }
}