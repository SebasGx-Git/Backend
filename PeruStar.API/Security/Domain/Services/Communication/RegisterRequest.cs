using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Email { get; set; }
}