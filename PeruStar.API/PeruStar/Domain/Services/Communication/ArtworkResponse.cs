using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class ArtworkResponse : BaseResponse<Artwork>
{
    public ArtworkResponse(Artwork resource) : base(resource)
    {
    }

    public ArtworkResponse(string message) : base(message)
    {
    }
}