namespace PeruStar.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}