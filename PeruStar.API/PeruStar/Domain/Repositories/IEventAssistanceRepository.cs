using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IEventAssistanceRepository
{
    Task<IEnumerable<EventAssistance>> ListAsync();
    Task AddAsync(EventAssistance eventAssistance);
    Task<IEnumerable<EventAssistance>> ListByEventIdAsync(long eventId);
    Task<IEnumerable<EventAssistance>> ListByHobbyistIdAsync(long hobbyistId);
    Task<EventAssistance> FindByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId);
    Task AssignEventAssistance(long hobbyistId, long eventId, DateTime attendance);
    Task UnassignEventAssistance(long hobbyistId, long eventId);
    void Remove(EventAssistance eventAssistance);
}