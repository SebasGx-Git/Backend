using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class ArtistResponse : BaseResponse<Artist>
{
    public ArtistResponse(Artist resource) : base(resource)
    {
    }

    public ArtistResponse(string message) : base(message)
    {
    }
}