using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models.Status;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class EventService: IEventService
{
    private readonly IEventRepository _eventRepository;
    private IUnitOfWork _unitOfWork;

    public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Event>> ListAsync()
    {
        return await _eventRepository.ListAsync();  
    }

    public async Task<IEnumerable<Event>> ListAsyncByArtistId(long artistId)
    {
        return await _eventRepository.ListByArtistIdAsync(artistId);
    }

    public async Task<IEnumerable<Event>> ListAsyncByEventType(ETypeOfEvent eTypeOf)
    {
        return await _eventRepository.ListByEventTypeAsync(eTypeOf);
    }

    public async Task<EventResponse> GetByIdAndArtistIdAsync(long eventId, long artistId)
    {
        var existingEvent = await _eventRepository.GetByIdAndArtistIdAsync(eventId, artistId);

        if (existingEvent.Equals(null))
            return new EventResponse("Event not found.");

        return new EventResponse(existingEvent);
    }

    public async Task<EventResponse> SaveAsync(long artistId, Event artistEvent)
    {
        artistEvent.ArtistId = artistId;
        try
        {
            await _eventRepository.AddAsync(artistEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(artistEvent);
        }
        catch (Exception ex)
        {
            return new EventResponse($"An error occurred when saving the event: {ex.Message}");
        }
    }

    public async Task<EventResponse> UpdateAsync(long eventId, long artistId, Event artistEvent)
    {
        var existingEvent = await _eventRepository.GetByIdAndArtistIdAsync(eventId, artistId);

        if (existingEvent.Equals(null))
            return new EventResponse("Event not found.");

        existingEvent.DateEnd = artistEvent.DateEnd;
        existingEvent.DateStart = artistEvent.DateStart;
        existingEvent.EventTitle = artistEvent.EventTitle;
        existingEvent.EventType = artistEvent.EventType;
        existingEvent.EventAditionalInfo = artistEvent.EventAditionalInfo;

        try
        {
            _eventRepository.Update(existingEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(existingEvent);
        }
        catch (Exception ex)
        {
            return new EventResponse($"An error occurred when updating the event: {ex.Message}");
        }
    }

    public async Task<EventResponse> DeleteAsync(long eventId, long artistId)
    {
        var existingEvent = await _eventRepository.GetByIdAndArtistIdAsync(eventId, artistId);

        if (existingEvent.Equals(null))
            return new EventResponse("Event not found.");

        try
        {
            _eventRepository.Remove(existingEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(existingEvent);
        }
        catch (Exception ex)
        {
            return new EventResponse($"An error occurred when deleting the event: {ex.Message}");
        }
    }

    public async Task<bool> IsSameTitle(string title, long artistId)
    {
        return await _eventRepository.IsSameTitle(title, artistId);
    }
}