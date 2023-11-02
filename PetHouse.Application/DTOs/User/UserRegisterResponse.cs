using PetHouse.Application.DTOs.Shared;

namespace PetHouse.Application.DTOs.User;

public sealed record UserRegisterResponse
{
    public bool Success => Errors.Message.Count == 0 ? true : false;

    public Errors Errors { get; set; } = new Errors();
    public string SucessMessage { get; set; }

}
