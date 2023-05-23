using MediatR;
using WebApi.Business.Jwt;
using WebApi.Core.Exceptions;
using WebApi.Core.Security.Hashing;
using WebApi.Domain.Abstract.IDentity;

namespace WebApi.Business.Handlers.Identity.Auth.Query;

public class LoginQuery : IRequest<AccessToken>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

class LoginQueryHandler: IRequestHandler<LoginQuery,AccessToken>
{
    private IAppUserDal _appUserDal;
    ITokenHelper _tokenHelper;

    public LoginQueryHandler(IAppUserDal appUserDal, ITokenHelper tokenHelper)
    {
        _appUserDal = appUserDal;
        _tokenHelper = tokenHelper;
    }

    public async Task<AccessToken> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
       var result = await _appUserDal.GetUser(request.Email);
       if (result == null)
           throw new AppUnauthorizedException("Kullanıcıadı veya Şifre Yanlış");
       if (!HashingHelper.VerifyPasswordHash(request.Password, result.PasswordHash, result.PasswordSalt))
       {
           throw new AppUnauthorizedException("Kullanıcıadı veya Şifre Yanlış");
       }
       var accessToken = _tokenHelper.CreateToken<AccessToken>(result);
       return accessToken;
    }
}