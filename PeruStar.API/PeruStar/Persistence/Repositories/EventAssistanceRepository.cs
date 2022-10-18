using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class EventAssistanceRepository: BaseRepository, IEventAssistanceRepository
{
    public EventAssistanceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EventAssistance>> ListAsync()
    {
        return await _context.EventAssistances.ToListAsync();
    }

    public async Task AddAsync(EventAssistance eventAssistance)
    {
        await _context.EventAssistances.AddAsync(eventAssistance);
    }

    public async Task<IEnumerable<EventAssistance>> ListByEventIdAsync(long eventId)
    {
        return await _context.EventAssistances
            .Where(p => p.EventId == eventId)
            .Include(p => p.Event)
            .Include(p => p.Hobbyist)
            .ToListAsync();
    }

    public async Task<IEnumerable<EventAssistance>> ListByHobbyistIdAsync(long hobbyistId)
    {
        return await _context.EventAssistances
            .Where(p => p.HobbyistId == hobbyistId)
            .Include(p => p.Event)
            .Include(p => p.Hobbyist)
            .ToListAsync();
    }

    public async Task<EventAssistance> FindByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId)
    {
        return (await _context.EventAssistances
            .Where(p => p.HobbyistId == hobbyistId && p.EventId == eventId)
            .Include(p => p.Event)
            .Include(p => p.Hobbyist)
            .FirstOrDefaultAsync())!;
    }

    public async Task AssignEventAssistance(long hobbyistId, long eventId, DateTime attendance)
    {
        EventAssistance eventAssistance = await FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
        if (eventAssistance == null)
        {
            eventAssistance = new EventAssistance { HobbyistId = hobbyistId, EventId = eventId  , AttendanceDay = attendance};
            await AddAsync(eventAssistance);
        }
    }

    public async Task UnassignEventAssistance(long hobbyistId, long eventId)
    {
        EventAssistance eventAssistance = await FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
        if (!eventAssistance.Equals(null))
            Remove(eventAssistance);
    }

    public void Remove(EventAssistance eventAssistance)
    {
        _context.EventAssistances.Remove(eventAssistance);
    }
}