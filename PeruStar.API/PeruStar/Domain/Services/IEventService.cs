using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models.Status;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services;

public interface IEventService
{
    Task<IEnumerable<Event>> ListAsync();
    Task<IEnumerable<Event>> ListAsyncByArtistId(long artistId);
    Task<IEnumerable<Event>> ListAsyncByEventType(ETypeOfEvent eTypeOf);
    Task<EventResponse> GetByIdAndArtistIdAsync(long eventId, long artistId);
    Task<EventResponse> SaveAsync(long artistId, Event artistEvent);
    Task<EventResponse> UpdateAsync(long eventId, long artistId, Event artistEvent);
    Task<EventResponse> DeleteAsync(long eventId, long artistId);
    Task<bool> IsSameTitle(string title, long artistId);
}