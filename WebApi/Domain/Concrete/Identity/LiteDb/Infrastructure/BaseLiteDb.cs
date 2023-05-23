using LiteDB.Async;
using WebApi.Core.Tenant.Abstract;

namespace WebApi.Domain.Concrete.Identity.LiteDb.Infrastructure;

public class BaseLiteDb
{
    public LiteDatabaseAsync Db;
    private ITenantService _tenantService;
    IConfiguration _configuration;
    public BaseLiteDb(ITenantService tenantService, IConfiguration configuration)
    {
        _tenantService = tenantService;
        _configuration = configuration;
        Db = new LiteDatabaseAsync("KeyPass_" + _tenantService.GetCurrentTenant());
    }
}