using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Entities;

public class UserEntity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfileImage { get; set; } = "avatar.jpg";
    public bool IsExternal { get; set; }
    public string? Bio { get; set; }

    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}