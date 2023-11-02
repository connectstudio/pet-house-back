using PetHouse.Domain.Entities;

namespace PetHouse.Domain.Factories
{
    public static class AddressFactory
    {
        public static Address Create(int number, string publicPlace, string publicPlaceType, string complement, string postalCode, string neighborhood, string city, string state)
        {
            var address = new Address(number, publicPlace, publicPlaceType, complement, postalCode, neighborhood, city, state);

            return address;
        }
    }
}
