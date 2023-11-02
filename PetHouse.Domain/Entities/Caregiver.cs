using PetHouse.Domain.Shared;

namespace PetHouse.Domain.Entities;

public sealed class Caregiver : EntityCore
{
    /// <summary>
    /// Número do documento
    /// </summary>
    public string Document { get; private set; }
    /// <summary>
    /// Tipo do documento, EX: CPF, CNPJ...
    /// </summary>
    public string DocumentType { get; private set; }
    /// <summary>
    /// Imagens do local que o pet ficará
    /// </summary>
    public byte[][] ImagesPlace { get; private set; }
    /// <summary>
    /// Serviços prestados pelo cuidador
    /// </summary>
    public ICollection<PetServices> Services { get; private set; }
    /// <summary>
    /// Preferencia de cachorro, pegar das constantes gerais
    /// </summary>
    public string DogPreference { get; private set; }
    public bool Accepted { get; private set; }
    public ApplicationUser ApplicationUser { get; private set; }
    internal Caregiver(string document, string documentType, byte[][] imagesPlace,ICollection<PetServices> services,
        string dogPreference, bool accepted) 
     
    {
        Document = document;
        DocumentType = documentType;
        ImagesPlace = imagesPlace;
        Services = services;
        DogPreference = dogPreference;
        Accepted = accepted;
    }
    private Caregiver() { }
}
