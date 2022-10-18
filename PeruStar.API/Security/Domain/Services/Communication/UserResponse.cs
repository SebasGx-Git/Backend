using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Security.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(User resource) : base(resource)
    {
    }

    public UserResponse(string message) : base(message)
    {
    }
}