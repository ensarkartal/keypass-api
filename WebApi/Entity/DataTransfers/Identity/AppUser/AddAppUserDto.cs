namespace Entity.DataTransfers.Identity.AppUser;

public class AddAppUserDto
{
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }
}