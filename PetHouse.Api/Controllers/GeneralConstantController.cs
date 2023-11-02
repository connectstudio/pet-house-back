using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHouse.Api.Atributtes;
using PetHouse.Application.DTOs.GeneralConstant;
using PetHouse.Application.Interfaces.GeneralConstant;
using System.Security.Claims;

namespace PetHouse.Api.Controllers;

[ApiController]
public class GeneralConstantController : Controller
{
    private readonly IGeneralConstantRepository _generalConstantRepository;

    public GeneralConstantController(IGeneralConstantRepository generalConstantRepository)
    {
        _generalConstantRepository = generalConstantRepository;
    }

    [HttpGet("api/generalConstant/pet_service")]

    public async Task<ActionResult<IEnumerable<Constante>>> GetConstantPetServices()
    {
        return Ok(_generalConstantRepository.GetConstantPetService());
    }

    [HttpGet("api/generalConstant/office")]
    public async Task<ActionResult<IEnumerable<Constante>>> GetConstantOffice()
    {
        return Ok(_generalConstantRepository.GetConstantOffice());
    }

    [HttpGet("api/generalConstant/public_place_type")]
    public async Task<ActionResult<IEnumerable<Constante>>> GetConstantPublicPlaceType()
    {
        return Ok(_generalConstantRepository.GetConstantPublicPlaceType());
    }
}
