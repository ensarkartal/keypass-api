using Core.Tenant.Abstract;
using System.Security.Claims;

namespace Core.Tenant.Cocnrete;

public class HttpTenantManager : ITenantService
{
    // private IHttpContextAccessor _httpContextAccessor;
    // public HttpTenantManager(IHttpContextAccessor httpContextAccessor)
    // {
    //     _httpContextAccessor = httpContextAccessor;
    // }
    //
    // public string GetCurrentTenant()
    // {
    //     var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
    //     return identity.Claims.FirstOrDefault(p => p.Type.Equals("id"))?.Value;
    // }
    public string GetCurrentTenant()
    {
        throw new NotImplementedException();
    }
}