using Core.Entity.Abstract;

namespace Core.Entity.Identity;

public class DevNetUserRole : ITable
{
    public string Id { get; set; }
    public string? UserId { get; set; }
    public string? RoleId { get; set; }

}