using PeruStar.API.Security.Domain.Models;

namespace PeruStar.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}