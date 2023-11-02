using PetHouse.Application.DTOs.Address;
using PetHouse.Application.DTOs.PetService;

namespace PetHouse.Application.DTOs.User;

public sealed record CaregiverInsertRequest
{
    /// <summary>
    /// Número do documento
    /// </summary>
    public string Document { get; set; } 
    
    /// <summary>
    /// Nome do cuidador
    /// </summary>
    public string Name { get; set; } 
    
    /// <summary>
    /// Email do cuidador
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Tipo do documento, EX: CPF, CNPJ...
    /// </summary>
    public string DocumentType { get; set; }

    /// <summary>
    /// Imagens do local que o pet ficará
    /// </summary>
    public string[] ImagesPlace { get; set; }

    /// <summary>
    /// Serviços prestados pelo cuidador
    /// </summary>
    public ICollection<PetServiceInsertRequest> Services { get; set; }

    /// <summary>
    /// Endereço do cuidador
    /// </summary>
    public AddressInsertRequest Address { get; set; }
    
    /// <summary>
    /// Preferencia de cachorro, pegar das constantes gerais
    /// </summary>
    public string DogPreference { get; set; }
}
