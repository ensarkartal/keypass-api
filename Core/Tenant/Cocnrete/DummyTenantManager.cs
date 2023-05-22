using Core.Tenant.Abstract;

namespace Core.Tenant.Cocnrete;

public class DummyTenantManager : ITenantService
{
    public string GetCurrentTenant()
    {
        return "345346";
    }
}