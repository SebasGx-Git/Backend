using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services;

public interface IFavoriteArtworkService
{
    Task<IEnumerable<FavoriteArtwork>> ListAsync();
    Task<IEnumerable<FavoriteArtwork>> ListByHobbyistIdAsync(long id); 
    Task<FavoriteArtworkResponse> AssignFavoriteArtworkAsync(long hobbyistId, long artworkId);
    Task<FavoriteArtworkResponse> UnassignFavoriteArtworkAsync(long hobbyistId, long artworkId);
}