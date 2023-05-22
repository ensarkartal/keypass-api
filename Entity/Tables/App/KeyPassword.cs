using Core.Entity.Concrete;

namespace Entity.Tables.App;

public class KeyPassword : AggregateEntity
{
    public string? KeyGroupId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}