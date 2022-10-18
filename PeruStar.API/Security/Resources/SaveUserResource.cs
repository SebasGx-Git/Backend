namespace PeruStar.API.Security.Resources;

public class SaveUserResource
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
}