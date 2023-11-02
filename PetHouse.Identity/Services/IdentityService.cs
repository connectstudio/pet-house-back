using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PetHouse.Application.DTOs.User;
using PetHouse.Application.Interfaces.Identity;
using PetHouse.Domain.Entities;
using PetHouse.Identity.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PetHouse.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly JwtOptions _jwtOptions;

    public IdentityService(UserManager<ApplicationUser> userManager,
                           IOptions<JwtOptions> jwtOptions,
                           SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
        _signInManager = signInManager;
    }
    public async Task<UserLoginResponse> GenerateCredentials(string email)
    {
        var user = await _userManager.FindByNameAsync(email);

        var accessTokenClaims = await GetClaims(user, addClaimsInUser: true);
        var refreshTokenClaims = await GetClaims(user, addClaimsInUser: false);

        var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = GenerateToken(accessTokenClaims, dataExpiracaoAccessToken);
        var refreshToken = GenerateToken(refreshTokenClaims, dataExpiracaoRefreshToken);

        return new UserLoginResponse
        (
            accessToken: accessToken,
            refreshToken: refreshToken
        );
    }
    public async Task<UserLoginResponse> LoginAsync(UserLoginRequest model)
    {
        SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: true);
      
        
        if (signInResult.Succeeded)
        {
            var credenciais = await GenerateCredentials(model.Email);
            return credenciais;
        }

        UserLoginResponse userLoginResponse = new UserLoginResponse(signInResult.Succeeded);
        if (!signInResult.Succeeded)
        {
            if (signInResult.IsLockedOut)
            {
                userLoginResponse.Errors.AddError("Esta conta está bloqueada.");
            }
            else if (signInResult.IsNotAllowed)
            {
                userLoginResponse.Errors.AddError("Esta conta não tem permissão para entrar.");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                userLoginResponse.Errors.AddError("Confirme seu email.");
            }
            else
            {
                userLoginResponse.Errors.AddError("Nome de usuário ou senha estão incorretos.");
            }
        }

        return userLoginResponse;
    }
    public string GenerateToken(IEnumerable<Claim> claims, DateTime expirationDate)
    {
        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
        notBefore: DateTime.Now,
            expires: expirationDate,
            signingCredentials: _jwtOptions.SigningCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    private async Task<IList<Claim>> GetClaims(ApplicationUser user, bool addClaimsInUser)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (addClaimsInUser)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));
        }

        return claims;
    }
}