using PetHouse.Domain.Shared;

namespace PetHouse.Domain.Entities;

public class ApplicationUser : Person
{
    public Caregiver? Caregiver { get; set; }
    public long? CaregiverId { get; set; }
    public string Office { get; set; }

    public ApplicationUser(Address address, string name, Caregiver? caregiver = null) : base(name, address)
    {
        Caregiver = caregiver;
    }

    private ApplicationUser() { }
}

public enum OfficeEnum
{
    Caregiver,
    Tutor,
    Suport,
    Master
}