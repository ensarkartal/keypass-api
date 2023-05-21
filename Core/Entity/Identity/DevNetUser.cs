using System.Text.Json.Serialization;
using Core.Entity.Abstract;

namespace Core.Entity.Identity;

public class DevNetUser : ITable
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    [JsonIgnore]
    public byte[]? PasswordHash { get; set; }
    [JsonIgnore]
    public byte[]? PasswordSalt { get; set; }
    public bool IsActive { get; set; }

}