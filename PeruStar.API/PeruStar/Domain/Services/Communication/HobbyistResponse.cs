using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class HobbyistResponse : BaseResponse<Hobbyist>
{
    public HobbyistResponse(Hobbyist resource) : base(resource)
    {
    }

    public HobbyistResponse(string message) : base(message)
    {
    }
}