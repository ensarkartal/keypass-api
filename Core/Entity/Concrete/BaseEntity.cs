using Core.Entity.Abstract;

namespace Core.Entity.Concrete;

public class BaseEntity : ITable
{
    public string? Id { get; set; }
}