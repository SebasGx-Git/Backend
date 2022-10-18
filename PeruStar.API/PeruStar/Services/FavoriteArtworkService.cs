using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class FavoriteArtworkService : IFavoriteArtworkService
{
    private readonly IFavoriteArtworkRepository _favoriteArtworkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FavoriteArtworkService(IFavoriteArtworkRepository favoriteArtworkRepository, IUnitOfWork unitOfWork)
    {
        _favoriteArtworkRepository = favoriteArtworkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<FavoriteArtwork>> ListAsync()
    {
        return await _favoriteArtworkRepository.ListAsync();
    }

    public async Task<IEnumerable<FavoriteArtwork>> ListByHobbyistIdAsync(long id)
    {
        return await _favoriteArtworkRepository.ListByHobbyistIdAsync(id);
    }

    public async Task<FavoriteArtworkResponse> AssignFavoriteArtworkAsync(long hobbyistId, long artworkId)
    {
        try {
            await _favoriteArtworkRepository.AssignFavoriteArtwork(hobbyistId, artworkId);
            await _unitOfWork.CompleteAsync();

            FavoriteArtwork favoriteArtwork = await _favoriteArtworkRepository.FindByHobbyistIdAndArtworkId(hobbyistId, artworkId);
            return new FavoriteArtworkResponse(favoriteArtwork);
        } catch (Exception ex) {
            return new FavoriteArtworkResponse($"An error ocurred while assigning favorite artwork: {ex.Message}");
        }
    }

    public async Task<FavoriteArtworkResponse> UnassignFavoriteArtworkAsync(long hobbyistId, long artworkId)
    {
        try {
            FavoriteArtwork favoriteArtwork = await _favoriteArtworkRepository.FindByHobbyistIdAndArtworkId(hobbyistId, artworkId);
            _favoriteArtworkRepository.Remove(favoriteArtwork);
            await _unitOfWork.CompleteAsync();

            return new FavoriteArtworkResponse(favoriteArtwork);
        } catch (Exception ex) {
            return new FavoriteArtworkResponse($"An error ocurred while unassigning favorite artwork: {ex.Message}");
        }
    }
}