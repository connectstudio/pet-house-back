namespace PetHouse.Domain.Shared;

public class EntityCore
{
    public long Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
}
