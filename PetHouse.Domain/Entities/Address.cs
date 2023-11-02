using PetHouse.Domain.Shared;

namespace PetHouse.Domain.Entities;

public sealed class Address : EntityCore
{
    /// <summary>
    /// Número da residência
    /// </summary>
    public int Number { get; private set; }
    /// <summary>
    /// Logradouro da residencia
    /// </summary>
    public string PublicPlace { get; private set; }
    /// <summary>
    /// Tipo de logradouro, EX: Alameda, Avenida, Rua
    /// </summary>
    public string PublicPlaceType { get; private set; }
    /// <summary>
    /// Complemento do endereço, Ex: Bloco, Torre...
    /// </summary>
    public string Complement { get; private set; }
    /// <summary>
    /// Código postal da residencia
    /// </summary>
    public string PostalCode { get; private set; }
    /// <summary>
    /// Bairro da residencia
    /// </summary>
    public string Neighborhood { get; private set; }
    /// <summary>
    /// Cidade da residencia
    /// </summary>
    public string City { get; private set; }
    /// <summary>
    /// Estado da residencia
    /// </summary>
    public string State { get; private set; }

    public ApplicationUser User { get; private set; }
    public string UserId { get; private set; }

    internal Address(int number, string publicPlace, string publicPlaceType, string complement, string postalCode, string neighborhood, string city, string state)
    {
        Number = number;
        PublicPlace = publicPlace;
        PublicPlaceType = publicPlaceType;
        Complement = complement;
        PostalCode = postalCode;
        Neighborhood = neighborhood;
        City = city;
        State = state;
    }

    private Address() { }
}
