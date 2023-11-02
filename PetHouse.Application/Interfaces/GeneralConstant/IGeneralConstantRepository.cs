using PetHouse.Application.DTOs.GeneralConstant;

namespace PetHouse.Application.Interfaces.GeneralConstant;

public interface IGeneralConstantRepository
{
    IEnumerable<Constante> GetConstantPetService();
    IEnumerable<Constante> GetConstantPublicPlaceType();
    IEnumerable<Constante> GetConstantOffice();
}
