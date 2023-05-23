namespace WebApi.Core.Tenant.Abstract;

public interface ITenantService
{
    string GetCurrentTenant();
}