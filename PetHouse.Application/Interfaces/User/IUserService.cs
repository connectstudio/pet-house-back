using PetHouse.Application.DTOs.Shared;
using PetHouse.Application.DTOs.User;

namespace PetHouse.Application.Interfaces.User;

public interface IUserService
{
    Task<UserRegisterResponse> CreateUserCaregiverAsync(CaregiverInsertRequest caregiverInsertRequest);
    Task<UserRegisterResponse> CreateUserAdminAsync(UserAdminInsertRequest userAdmin);
    Task<DefaultResponse> DeleteUserAsync(string id);
    Task<IEnumerable<UsersResponse>> GetUsersAsync();
}
