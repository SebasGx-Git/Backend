namespace PeruStar.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
}