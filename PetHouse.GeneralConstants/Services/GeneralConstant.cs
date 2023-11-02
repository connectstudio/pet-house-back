using PetHouse.Application.DTOs.GeneralConstant;

namespace PetHouse.GeneralConstants.Services;

public static class GeneralConstant
{
    #region Office
    public static Constante TypeOfficeSupport()
    {
        return new Constante()
        {
            Id = 1,
            Name = "SUPORTE",
            Description = "Cargo de suporte para usuário administrador",
        };
    }

    public static IEnumerable<Constante> ListOfficeType()
    {
        yield return TypeOfficeSupport();
    }
    #endregion

    #region PetServices
    public static Constante TypePetServiceAccommodation()
    {
        return new Constante()
        {
            Id = 1,
            Name = "HOSPEDAGEM",
            Description = "Tipo de serviço hospedagem para usuários cuidadores",
        };
    }

    public static Constante TypePetServiceNursery()
    {
        return new Constante()
        {
            Id = 2,
            Name = "CRECHE",
            Description = "Tipo de serviço creche para usuários cuidadores - o pet passa o dia na casa do usuário",
        };
    }

    public static Constante TypePetServicePetSitter()
    {
        return new Constante()
        {
            Id = 3,
            Name = "PET SITTER",
            Description = "Tipo de serviço pet sitter para usuários cuidadores - o cuidador vai a casa do usuário tutor",
        };
    }

    public static IEnumerable<Constante> ListTypePetServices()
    {
        yield return TypePetServiceAccommodation();
        yield return TypePetServiceNursery();
        yield return TypePetServicePetSitter();
    }
    #endregion

    #region PublicPlacesType
    public static Constante PublicPlaceTypeStreet()
    {
        return new Constante()
        {
            Id = 1,
            Name = "RUA",
            Description = "Tipo de logradouro: rua",
        };
    }
    public static Constante PublicPlaceTypeAlameda()
    {
        return new Constante()
        {
            Id = 2,
            Name = "ALAMEDA",
            Description = "Tipo de logradouro: alameda",
        };
    }
    public static Constante PublicPlaceTypeAvenue()
    {
        return new Constante()
        {
            Id = 3,
            Name = "AVENIDA",
            Description = "Tipo de logradouro: AVENIDA",
        };
    }
    public static Constante PublicPlaceTypeCondominium()
    {
        return new Constante()
        {
            Id = 4,
            Name = "Condominio",
            Description = "Tipo de logradouro: Condominio",
        };
    }
    public static Constante PublicPlaceTypeChacara()
    {
        return new Constante()
        {
            Id = 5,
            Name = "Chácara",
            Description = "Tipo de logradouro: Chácara",
        };
    }

    public static IEnumerable<Constante> ListPublicPlaceType()
    {
        yield return PublicPlaceTypeStreet();
        yield return PublicPlaceTypeAlameda();
        yield return PublicPlaceTypeAvenue();
        yield return PublicPlaceTypeCondominium();
        yield return PublicPlaceTypeChacara();
    }
    #endregion
}
