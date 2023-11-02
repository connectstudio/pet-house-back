using PetHouse.Application.DTOs.Address;

namespace PetHouse.Application.DTOs.User;

public sealed class UserAdminInsertRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Office { get; set; }
    public IEnumerable<Permissions> Permissions { get; set; }
    public AddressInsertRequest Address { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
   
}


