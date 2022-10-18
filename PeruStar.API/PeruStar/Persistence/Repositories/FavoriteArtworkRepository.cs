using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class FavoriteArtworkRepository: BaseRepository, IFavoriteArtworkRepository
{
    public FavoriteArtworkRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FavoriteArtwork>> ListAsync()
    {
        return await _context.FavoriteArtworks.ToListAsync();
    }

    public async Task<IEnumerable<FavoriteArtwork>> ListByHobbyistIdAsync(long hobbyistId)
    {
        return await _context.FavoriteArtworks
            .Where(p => p.HobbyistId == hobbyistId)
            .Include(p => p.Artwork)
            .ToListAsync();
    }

    public async Task<IEnumerable<FavoriteArtwork>> ListByArtworkIdAsync(long artworkId)
    {
        return await _context.FavoriteArtworks
            .Where(p => p.ArtworkId == artworkId)
            .Include(p => p.Hobbyist)
            .ToListAsync();
    }

    public async Task<FavoriteArtwork> FindByHobbyistIdAndArtworkId(long hobbyistId, long artworkId)
    {
        return (await _context.FavoriteArtworks
            .Where(p => p.HobbyistId == hobbyistId && p.ArtworkId == artworkId)
            .FirstOrDefaultAsync())!;
    }

    public async Task AddAsync(FavoriteArtwork favoriteArtwork)
    {
        await _context.FavoriteArtworks.AddAsync(favoriteArtwork);
    }

    public void Remove(FavoriteArtwork favoriteArtwork)
    {
        _context.FavoriteArtworks.Remove(favoriteArtwork);
    }

    public async Task AssignFavoriteArtwork(long hobbyistId, long artworkId)
    {
        var favoriteArtwork = await FindByHobbyistIdAndArtworkId(hobbyistId, artworkId);

        if (!favoriteArtwork.Equals(null))
        {
            favoriteArtwork = new FavoriteArtwork { HobbyistId = hobbyistId, ArtworkId = artworkId };
            await AddAsync(favoriteArtwork);
        }
    }

    public async Task UnassignFavoriteArtwork(long hobbyistId, long artworkId)
    {
        var favoriteArtwork = await FindByHobbyistIdAndArtworkId(hobbyistId, artworkId);

        if (!favoriteArtwork.Equals(null))
        {
            Remove(favoriteArtwork);
        }
    }
}