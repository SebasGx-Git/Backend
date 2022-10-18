using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IFavoriteArtworkRepository
{
    Task<IEnumerable<FavoriteArtwork>> ListAsync();
    Task<IEnumerable<FavoriteArtwork>> ListByHobbyistIdAsync(long hobbyistId);
    Task<IEnumerable<FavoriteArtwork>> ListByArtworkIdAsync(long artworkId);
    Task<FavoriteArtwork> FindByHobbyistIdAndArtworkId( long hobbyistId, long artworkId);
    Task AddAsync(FavoriteArtwork favoriteArtwork);
    void Remove(FavoriteArtwork favoriteArtwork);
    Task AssignFavoriteArtwork(long hobbyistId, long artworkId);
    Task UnassignFavoriteArtwork(long hobbyistId, long artworkId);
}