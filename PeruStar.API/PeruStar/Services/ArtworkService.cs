using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class ArtworkService : IArtworkService
{
    
    private readonly IArtworkRepository _artworkRepository;
    private readonly IArtistRepository _artistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtworkService(IArtworkRepository artworkRepository, IUnitOfWork unitOfWork, IArtistRepository artistRepository)
    {
        _artworkRepository = artworkRepository;
        _unitOfWork = unitOfWork;
        _artistRepository = artistRepository;
    }

    public async Task<IEnumerable<Artwork>> ListAsync()
    {
        return await _artworkRepository.ListAsync();
    }

    public async Task<IEnumerable<Artwork>> ListByArtistIdAsync(long id)
    {
        return await _artworkRepository.ListByArtistIdAsync(id);
    }

    public async Task<ArtworkResponse> FindByIdAndArtistIdAsync(long id, long artistId)
    {
        var existingArtwork = await _artworkRepository.FindByIdAndArtistIdAsync(id, artistId);

        if (existingArtwork.Equals(null))
            return new ArtworkResponse("Artwork not found.");

        return new ArtworkResponse(existingArtwork);
    }
    
    public async Task<ArtworkResponse> SaveAsync(long artistId, Artwork artwork)
    {
        try
        {
            var existingArtist = await _artistRepository.FindById(artistId);

            if (existingArtist.Equals(null))
                return new ArtworkResponse("Artist not found");

            artwork.Artist = existingArtist;
            await _artworkRepository.AddAsync(artwork);
            await _unitOfWork.CompleteAsync();

            return new ArtworkResponse(artwork);
        }
        catch (Exception ex)
        {
            return new ArtworkResponse($"An error occurred when saving the artwork: {ex.Message}");
        }
    }

    public async Task<ArtworkResponse> UpdateAsync(long id, long artistId, Artwork artwork)
    {
        var existingArtist = await _artistRepository.FindById(artistId);

        if (existingArtist.Equals(null))
            return new ArtworkResponse("Artist not found");
        var existingArtwork = await _artworkRepository.FindByIdAndArtistIdAsync(id, artistId);

        if (existingArtwork.Equals(null))
            return new ArtworkResponse("Artwork not found");
        
        existingArtwork.ArtDescription = artwork.ArtDescription;
        existingArtwork.ArtTitle = artwork.ArtTitle;
        existingArtwork.ArtCost = artwork.ArtCost;

        try
        {
            _artworkRepository.Update(existingArtwork);
            await _unitOfWork.CompleteAsync();

            return new ArtworkResponse(existingArtwork);
        }
        catch (Exception ex)
        {
            return new ArtworkResponse($"An error occurred when updating the artwork: {ex.Message}");
        }
    }

    public async Task<ArtworkResponse> DeleteAsync(long id, long artistId)
    {
        var existingArtwork = await _artworkRepository.FindByIdAndArtistIdAsync(id, artistId);

        if (existingArtwork.Equals(null))
            return new ArtworkResponse("Artwork not found");

        try
        {
            _artworkRepository.Remove(existingArtwork);
            await _unitOfWork.CompleteAsync();

            return new ArtworkResponse(existingArtwork);
        }
        catch (Exception ex)
        {
            return new ArtworkResponse($"An error occurred when deleting the artwork: {ex.Message}");
        }
    }

    public async Task<bool> IsSameTitle(string title, long artistId)
    {
        var existingArtwork = await _artworkRepository.IsSameTitle(title, artistId);

        if(existingArtwork.Equals(null))
            return false;

        return true;
    }

    public async Task<IEnumerable<Artwork>> ListByHobbyistAsync(long hobbyistId)
    {
        throw new NotImplementedException(); // Todavia no se implementa
    }
}