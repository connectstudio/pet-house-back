using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;
using PetHouse.Application.DTOs.Shared;

namespace PetHouse.Application.DTOs.User;

public sealed record UserLoginResponse
{

    public bool Success => Errors.Message.Count == 0 ? true : false;

    public string Email { get; private set; }
    public string Name { get; private set; }
    public string UserType { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; }
    public string? ExpirationTimeAccessToken { get; private set; }
    //public DateTime ExpirationDateTimeAccessToken { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; }
    //public string? ExpirationTimeRefreshtoken { get; private set; }
    //public DateTime ExpirationDateTimeRefreshtoken { get; private set; }
    public Errors Errors { get; set; } = new Errors();


    public UserLoginResponse(bool success)
    { }

    public UserLoginResponse(string accessToken, string refreshToken, string expirationTimeRefreshtoken, string expirationTimeAccessToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        ExpirationTimeAccessToken = expirationTimeAccessToken;
    //    ExpirationTimeRefreshtoken = expirationTimeRefreshtoken;
    //    ExpirationDateTimeAccessToken = DateTime.Now.AddSeconds(3000);
    //    ExpirationDateTimeRefreshtoken = DateTime.Now.AddSeconds(10200);
    }

    public UserLoginResponse(string accessToken, string refreshToken, string email, string name, string userType)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        Email = email;
        Name = name;
        UserType = userType;
    }
}

