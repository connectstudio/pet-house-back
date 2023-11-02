using PetHouse.Domain.Entities;

namespace PetHouse.Domain.Factories;

public static class PetServiceFactory 
{
    public static PetServices Create(string name, decimal avaragePrice, bool active, string cancellationPolicy)
    {
        return new PetServices(name, avaragePrice, active, cancellationPolicy);
    }
}
