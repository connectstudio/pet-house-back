using Microsoft.AspNetCore.Mvc;
using PetHouse.Application.DTOs.Shared;
using PetHouse.Application.DTOs.User;
using PetHouse.Application.Interfaces.Identity;
using PetHouse.Application.Interfaces.User;

namespace PetHouse.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IIdentityService _identityService;

    public UserController(IUserService userService, IIdentityService identityService)
    {
        _userService = userService;
        _identityService = identityService;
    }

    /// <summary>
    /// Cadastra um novo usuário cuidador.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns></returns>
    /// <response code="201">Retorna sucesso em caso de um cadastro bem sucedido</response>
    /// <response code="400">Retorna erros caso ocorram</response>
    [ProducesResponseType(typeof(IEnumerable<UserRegisterResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserRegisterResponse>> CaregiverInsertAsync(CaregiverInsertRequest request)
    {
        var response = await _userService.CreateUserCaregiverAsync(request);

        if (!response.Errors.Message.Any())
            return StatusCode(201);

        return BadRequest(response);
    }

    /// <summary>
    /// Cadastra um novo usuário administrador.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns></returns>
    /// <response code="201">Retorna sucesso em caso de um cadastro bem sucedido</response>
    /// <response code="400">Retorna erros caso ocorram</response>
    [ProducesResponseType(typeof(IEnumerable<UserRegisterResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost("/admin")]
    public async Task<ActionResult<UserRegisterResponse>> UserAdminInsertAsync(UserAdminInsertRequest request)
    {
        var response = await _userService.CreateUserAdminAsync(request);

        if (!response.Errors.Message.Any())
            return StatusCode(201);

        return BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync(UserLoginRequest request)
    {
        var response = await _identityService.LoginAsync(request);

        if (!response.Errors.Message.Any())
            return Ok(response);

        return BadRequest(response);
    }

}