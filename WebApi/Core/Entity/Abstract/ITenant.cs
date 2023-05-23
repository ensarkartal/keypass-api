namespace WebApi.Core.Entity.Abstract;

public interface ITenant<TPropTenant>
{
    public TPropTenant? TenantId { get; set; }
}