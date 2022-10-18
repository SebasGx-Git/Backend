using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models.Status;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class EventRepository: BaseRepository, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Event>> ListAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<IEnumerable<Event>> ListByArtistIdAsync(long artistId)
    {
        return await _context.Events
            .Where(p => p.ArtistId == artistId)
            .Include(p => p.Artist)
            .ToListAsync();
    }

    public async Task<IEnumerable<Event>> ListByEventTypeAsync(ETypeOfEvent typeOfEvent)
    {
        return await _context.Events
            .Where(p => p.EventType == typeOfEvent)
            .Include(p => p.Artist)
            .ToListAsync();
    }

    public async Task<Event> GetByIdAndArtistIdAsync(long eventId, long artistId)
    {
        return (await _context.Events
            .Where(p => p.EventId == eventId && p.ArtistId == artistId)
            .Include(p => p.Artist)
            .FirstOrDefaultAsync())!;
    }


    public async Task AddAsync(Event artisticEvent)
    {
        await _context.Events.AddAsync(artisticEvent);
    }

    public async Task<Event> FindById(long id)
    {
        return (await _context.Events.FindAsync(id))!;
    }

    public void Update(Event artisticEvent)
    {
        _context.Events.Update(artisticEvent);
    }

    public void Remove(Event artisticEvent)
    {
        _context.Events.Remove(artisticEvent);
    }

    public async Task<bool> IsSameTitle(string title, long artistId)
    {
        return await _context.Events.AnyAsync(p => p.EventTitle == title && p.ArtistId == artistId);
    }
}