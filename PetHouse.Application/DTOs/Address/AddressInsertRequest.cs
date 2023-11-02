namespace PetHouse.Application.DTOs.Address;

public sealed record AddressInsertRequest
{
    /// <summary>
    /// Número da residência
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// Logradouro da residencia
    /// </summary>
    public string PublicPlace { get; set; }
    /// <summary>
    /// Tipo de logradouro, EX: Alameda, Avenida, Rua
    /// </summary>
    public string PublicPlaceType { get; set; }
    /// <summary>
    /// Complemento do endereço, Ex: Bloco, Torre...
    /// </summary>
    public string Complement { get; set; }
    /// <summary>
    /// Código postal da residencia
    /// </summary>
    public string PostalCode { get; set; }
    /// <summary>
    /// Bairro da residencia
    /// </summary>
    public string Neighborhood { get; set; }
    /// <summary>
    /// Cidade da residencia
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Estado da residencia
    /// </summary>
    public string State { get; set; }
}
