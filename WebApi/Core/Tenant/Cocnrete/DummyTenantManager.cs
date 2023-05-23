using WebApi.Core.Tenant.Abstract;

namespace WebApi.Core.Tenant.Cocnrete;

public class DummyTenantManager : ITenantService
{
    public string GetCurrentTenant()
    {
        return "345346";
    }
}