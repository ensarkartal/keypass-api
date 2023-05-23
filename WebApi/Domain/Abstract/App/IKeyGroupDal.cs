using WebApi.Entity.DataTransfers.App.KeyGroup;

namespace WebApi.Domain.Abstract.App;

public interface IKeyGroupDal
{
    Task<string> AddKeyGroup(AddKeyGroupDto? keyGroup);
    Task UpdateKeyGroyp(string? keyGroupId, UpdateKeyGroupDto? keyGroup);
    Task DeleteKeyGroup(string? keyGroupId);
    Task<GetKeyGroupDto?> GetKeyGroup(string? keyGroupId);
    Task<List<GetKeyGroupDto>> GetKeyGroups();
}