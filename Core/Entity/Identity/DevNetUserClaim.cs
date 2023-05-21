using Core.Entity.Abstract;

namespace Core.Entity.Identity;

public class DevNetUserClaim : ITable
{
    public string Id { get; set; }
    public string? UserId { get; set; }
    public string? ClaimId { get; set; }

}