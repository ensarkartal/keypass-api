namespace WebApi.Entity.DataTransfers.Identity.AppUser;

public class GetAppUserDto
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
}