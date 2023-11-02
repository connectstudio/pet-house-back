
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetHouse.Application.Interfaces.GeneralConstant;
using PetHouse.Application.Interfaces.Identity;
using PetHouse.Application.Interfaces.User;
using PetHouse.Domain.Entities;
using PetHouse.GeneralConstants.Repositories;
using PetHouse.Identity.Services;
using PetHouse.Infrastructure.Context;

namespace PetHouse.Api.Ioc;

public static class NativeInjectorConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context
        services.AddDbContext<PetHouseDbContext>
            (opts =>
             opts.UseNpgsql
             (configuration
             .GetConnectionString("connection")));

        services.AddDefaultIdentity<ApplicationUser>()
          .AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<PetHouseDbContext>()
          .AddDefaultTokenProviders();

        #endregion

        #region Services
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IUserService, UserService>();
        #endregion

        #region Repositories
        services.AddScoped<IGeneralConstantRepository, GeneralConstantRepository>();

        #endregion

    }
}
