using Microsoft.Extensions.Options;
using PeruStar.API.Security.Authorization.Handlers.Interfaces;
using PeruStar.API.Security.Authorization.Settings;
using PeruStar.API.Security.Domain.Services;

namespace PeruStar.API.Security.Authorization.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
    {
        _appSettings = appSettings.Value;
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler jwtHandler)
    {
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();
        var userId = jwtHandler.ValidateToken(token);
        if (userId != null)
        {
            // Attach user to context on successful JWT validation
            context.Items["User"] = await userService.FindByIdAsync(userId.Value);
        }

        await _next(context);
    }
}