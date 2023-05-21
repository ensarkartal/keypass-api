using Core.Entity.Abstract;

namespace Core.Entity.Identity;

public class DevNetRole : ITable
{
    public string Id { get; set; }
    public string? Name { get; set; }

}