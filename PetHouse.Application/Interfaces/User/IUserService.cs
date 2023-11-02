using PetHouse.Application.DTOs.User;

namespace PetHouse.Application.Interfaces.User;

public interface IUserService
{
    Task<UserRegisterResponse> CreateUserCaregiverAsync(CaregiverInsertRequest caregiverInsertRequest);
    Task<UserRegisterResponse> CreateUserAdminAsync(UserAdminInsertRequest userAdmin);
}
