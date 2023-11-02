using PetHouse.Application.DTOs.User;
using System.Security.Claims;

namespace PetHouse.Application.Interfaces.Identity;

public interface IIdentityService
{
    Task<UserLoginResponse> GenerateCredentials(string email);
    string GenerateToken(IEnumerable<Claim> claims, DateTime expirationDate);
    Task<UserLoginResponse> LoginAsync(UserLoginRequest model);
    Task<IEnumerable<Permissions>> GetPermissionsAsync();
}

public class UserLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}