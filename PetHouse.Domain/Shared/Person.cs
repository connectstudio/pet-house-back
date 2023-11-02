using Microsoft.AspNetCore.Identity;
using PetHouse.Domain.Entities;

namespace PetHouse.Domain.Shared;

public abstract class Person : IdentityUser
{
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public long AddressId { get; private set; }

    internal Person(string name = null, Address address = null)
    {
        Name = name;
        Address = address;
    }
}
