using Entity.Tables.Identity;

namespace Business.Jwt;

public interface ITokenHelper
{
    TAccessToken CreateToken<TAccessToken>(AppUser? user) where TAccessToken : IAccessToken, new();

}