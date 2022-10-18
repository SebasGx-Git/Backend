using System.Text.Json.Serialization;

namespace PeruStar.API.Security.Domain.Models;

public class User
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public string? PasswordHash { get; set; }
}