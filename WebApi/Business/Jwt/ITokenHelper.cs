using WebApi.Entity.Tables.Identity;

namespace WebApi.Business.Jwt;

public interface ITokenHelper
{
    TAccessToken CreateToken<TAccessToken>(AppUser? user) where TAccessToken : IAccessToken, new();

}