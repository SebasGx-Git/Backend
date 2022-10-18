using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
    {
        _artistRepository = artistRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Artist>> ListAsync()
    {
        return await _artistRepository.ListAsync();
    }

    public Task<IEnumerable<Artist>> ListByHobbyistIdAsync(int hobbyistId)
    {
        throw new NotImplementedException(); // Falta Folower
    }

    public async Task<ArtistResponse> GetByIdAsync(long id)
    {
        return new ArtistResponse(await _artistRepository.FindById(id));
    }

    public async Task<ArtistResponse> SaveAsync(Artist artist)
    {
        try
        {
            await _artistRepository.AddAsync(artist);
            await _unitOfWork.CompleteAsync();

            return new ArtistResponse(artist);
        }
        catch (Exception ex)
        {
            return new ArtistResponse($"An error occurred when saving the artist: {ex.Message}");
        }
    }

    public async Task<ArtistResponse> UpdateAsync(long id, Artist artist)
    {
        var existingArtist = await _artistRepository.FindById(id);

        if (existingArtist.Equals(null))
            return new ArtistResponse("Artist not found.");

        existingArtist.BrandName = artist.BrandName;
        existingArtist.Description = artist.Description;
        existingArtist.Phrase = artist.Phrase;
        existingArtist.Firstname = artist.Firstname;
        existingArtist.Lastname = artist.Lastname;

        try
        {
            _artistRepository.Update(existingArtist);
            await _unitOfWork.CompleteAsync();

            return new ArtistResponse(existingArtist);
        }
        catch (Exception ex)
        {
            return new ArtistResponse($"An error occurred when updating the artist: {ex.Message}");
        }
    }

    public async Task<ArtistResponse> DeleteAsync(long id)
    {
        var existingArtist = await _artistRepository.FindById(id);
        if (existingArtist.Equals(null))
            return new ArtistResponse("Artist not found.");
        
        try
        {
            _artistRepository.Remove(existingArtist);
            await _unitOfWork.CompleteAsync();

            return new ArtistResponse(existingArtist);
        }
        catch (Exception ex)
        {
            return new ArtistResponse($"An error occurred when deleting the artist: {ex.Message}");
        }
    }

    public async Task<bool> IsSameBrandingName(string brandingName)
    {
        return await _artistRepository.IsSameBrandingName(brandingName);
    }
}