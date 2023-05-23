using WebApi.Core.Entity.Abstract;

namespace WebApi.Core.Entity.Concrete;

public class BaseEntity : ITable
{
    public string? Id { get; set; }
}