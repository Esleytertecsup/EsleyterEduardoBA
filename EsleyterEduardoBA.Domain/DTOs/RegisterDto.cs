using System.Text.Json.Serialization;

namespace EsleyterEduardoBA.Domain.DTOs;

public class RegisterDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [JsonIgnore]
    public string Role { get; set; } = string.Empty;
}