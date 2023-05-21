using Core.Entity.Abstract;

namespace Core.Entity.Identity;

public class DevNetClaim : ITable
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Alias { get; set; }
    public string? Description { get; set; }

}