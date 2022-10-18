using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class FavoriteArtworkResponse : BaseResponse<FavoriteArtwork>
{
    public FavoriteArtworkResponse(FavoriteArtwork resource) : base(resource)
    {
    }

    public FavoriteArtworkResponse(string message) : base(message)
    {
    }
}