using Microsoft.AspNetCore.Identity;
using PetHouse.Application.DTOs.Address;
using PetHouse.Application.DTOs.Shared;
using PetHouse.Application.DTOs.User;
using PetHouse.Application.Interfaces.User;
using PetHouse.Domain.Entities;
using PetHouse.Domain.Factories;
using System.Security.Claims;

namespace PetHouse.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<UserRegisterResponse> CreateUserCaregiverAsync(CaregiverInsertRequest caregiverInsertRequest)
    {
        var userRegisterResponse = new UserRegisterResponse();
        var address = await PrepareAddressAsync(caregiverInsertRequest.Address);
        var caregiver = await PrepareCaregiverAsync(caregiverInsertRequest);

        var userCaregiver = new ApplicationUser(address, caregiverInsertRequest.Name, caregiver)
        {
            UserName = caregiverInsertRequest.Email,
            Email = caregiverInsertRequest.Email,
            Office = "Caregiver" //Trocar pela constante depois
        };

        var result = await _userManager.CreateAsync(userCaregiver);

        if (!result.Succeeded)
        {
            ValidateUser(result.Errors, userRegisterResponse);

            return userRegisterResponse;
        }

        return userRegisterResponse;
    }

    public async Task<UserRegisterResponse> CreateUserAdminAsync(UserAdminInsertRequest userAdmin)
    {
        var userRegisterResponse = new UserRegisterResponse();

        var address = await PrepareAddressAsync(userAdmin.Address);
        var user = new ApplicationUser(address, userAdmin.Name)
        {
            UserName = userAdmin.Email,
            Email = userAdmin.Email,
            Office = userAdmin.Office
        };

        var result = await _userManager.CreateAsync(user, userAdmin.ConfirmPassword);
        if (!result.Succeeded)
        {
            ValidateUser(result.Errors, userRegisterResponse);

            return userRegisterResponse;
        }

        foreach(var currentPermission in userAdmin.Permissions)
        {
            await _userManager.AddClaimAsync(user, new Claim(currentPermission.Type, currentPermission.Value));
        }
     
        return userRegisterResponse;
    }

    public async Task<DefaultResponse> DeleteUserAsync(string id)
    {
        var response = new DefaultResponse();
        var user = await _userManager.FindByNameAsync("Marcosfelipehd777@gmail.com");

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            response.Sucess = false;
            return response;
        }

        return response;
    }

    public async Task<IEnumerable<UsersResponse>> GetUsersAsync()
    {
        var result = (from users in _userManager.Users
                      select new UsersResponse()
                      {
                          Email = users.Email,
                          Name = users.Name,
                          Office = users.Office,

                      });

        return result;
    }

    #region AUX
    private async Task<Caregiver> PrepareCaregiverAsync(CaregiverInsertRequest model)
    {
        var services = (from currentPetService in model.Services
                    select PetServiceFactory.Create
                    (currentPetService.Name,
                    currentPetService.AvaragePrice,
                    true,
                    currentPetService.CancellationPolicy)).ToList();

        var caregiver = CaregiverFactory.Create
            (model.Document,
            model.DocumentType,
            model.ImagesPlace,
            services,
            model.DogPreference,
            false);

        return caregiver;
    }

    private async Task<Address> PrepareAddressAsync(AddressInsertRequest model)
    {
        var address = AddressFactory.Create
                                    (model.Number,
                                    model.PublicPlace,
                                    model.PublicPlaceType,
                                    model.Complement,
                                    model.PostalCode,
                                    model.Neighborhood,
                                    model.City,
                                    model.State);
        return address;
    }
    #endregion

    #region Validator
    private UserRegisterResponse ValidateUser(IEnumerable<IdentityError> errors, UserRegisterResponse userRegisterResponse)
    {
        foreach (var currentError in errors)
        {
            switch (currentError.Code)
            {
                case "PasswordRequiresNonAlphanumeric":
                    userRegisterResponse.Errors.AddError("A senha precisa conter pelo menos um caracter especial - ex( * | ! ).");
                    break;

                case "PasswordRequiresDigit":
                    userRegisterResponse.Errors.AddError("A senha precisa conter pelo menos um número (0 - 9).");
                    break;

                case "PasswordRequiresUpper":
                    userRegisterResponse.Errors.AddError("A senha precisa conter pelo menos um caracter em maiúsculo.");
                    break;

                case "DuplicateUserName":
                    userRegisterResponse.Errors.AddError("O email informado já foi cadastrado!");
                    break;

                default:
                    userRegisterResponse.Errors.AddError("Erro ao criar usuário.");
                    break;
            }

        }

        return userRegisterResponse;
    }
    #endregion
}
