using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models.Status;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> ListAsync();
    Task<IEnumerable<Event>> ListByArtistIdAsync(long artistId);
    Task<IEnumerable<Event>> ListByEventTypeAsync(ETypeOfEvent typeOfEvent);
    Task<Event> GetByIdAndArtistIdAsync(long eventId, long artistId);
    Task AddAsync(Event artisticEvent);
    Task<Event> FindById(long id);
    void Update(Event artisticEvent);
    void Remove(Event artisticEvent);
    Task<bool> IsSameTitle(string title, long artistId);
}