using PetHouse.Application.DTOs.GeneralConstant;
using PetHouse.Application.Interfaces.GeneralConstant;
using PetHouse.GeneralConstants.Services;

namespace PetHouse.GeneralConstants.Repositories;

public class GeneralConstantRepository : IGeneralConstantRepository
{
    public IEnumerable<Constante> GetConstantPetService()
    {
        return GeneralConstant.ListTypePetServices().OrderBy(x => x.Id);
    }

    public IEnumerable<Constante> GetConstantPublicPlaceType()
    {
        return GeneralConstant.ListPublicPlaceType().OrderBy(x => x.Id);
    }

    public IEnumerable<Constante> GetConstantOffice()
    {
        return GeneralConstant.ListOfficeType().OrderBy(x => x.Id);
    }
}
