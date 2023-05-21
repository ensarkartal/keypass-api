using Core.Tenant.Abstract;
using Domain.Abstract;
using Domain.Concrete.MongoDb.Infrastructure;
using Entity.DataTransfers.KeyGroup;
using Microsoft.Extensions.Configuration;

namespace Domain.Concrete.MongoDb.Operations;

public class MongoKeyGroupDal : BaseMongoDb,IKeyGroupDal
{
    public MongoKeyGroupDal(ITenantService tenantService, IConfiguration configuration) : base(tenantService, configuration)
    {
    }

    public Task<string> AddKeyGroup(AddKeyGroupDto keyGroup)
    {
        throw new NotImplementedException();
    }

    public Task UpdateKeyGroyp(string keyGroupId, UpdateKeyGroupDto keyGroup)
    {
        throw new NotImplementedException();
    }

    public Task DeleteKeyGroup(string keyGroupId)
    {
        throw new NotImplementedException();
    }

    public Task<GetKeyGroupDto> GetKeyGroup(string keyGroupId)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetKeyGroupDto>> GetKeyGroups()
    {
        throw new NotImplementedException();
    }
}