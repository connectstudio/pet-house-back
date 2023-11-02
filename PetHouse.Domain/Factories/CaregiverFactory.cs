using PetHouse.Domain.Entities;

namespace PetHouse.Domain.Factories;

public static class CaregiverFactory
{
    public static Caregiver Create(string document, string documentType,
        string[] imagesPlace, ICollection<PetServices> services, string dogPreference, bool accepted)
    {
        byte[][] arraysDeBytes = new byte[imagesPlace.Length][];

        for (int i = 0; i < imagesPlace.Length; i++)
        {
            arraysDeBytes[i] = Convert.FromBase64String(imagesPlace[i]);
        }

        var caregiver = new Caregiver(document, documentType, arraysDeBytes, services, dogPreference, accepted);

        return caregiver;
    }
}
