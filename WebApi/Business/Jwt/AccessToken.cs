namespace Business.Jwt;
public class AccessToken : IAccessToken
{
    public AccessToken(string token)
    {
        Token = token;
        //Claims = claims;
    }

    public AccessToken()
    {

    }
    //public List<DevNetClaim> Claims { get; set; }
    public string Token { get; set; }

}
