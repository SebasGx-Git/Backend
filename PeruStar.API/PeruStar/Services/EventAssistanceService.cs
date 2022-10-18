using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class EventAssistanceService: IEventAssistanceService
{
    
    private readonly IEventAssistanceRepository _eventAssistanceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EventAssistanceService(IEventAssistanceRepository eventAssistanceRepository, IUnitOfWork unitOfWork)
    {
        _eventAssistanceRepository = eventAssistanceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EventAssistance>> ListAsync()
    {
        return await _eventAssistanceRepository.ListAsync();
    }

    public async Task<IEnumerable<EventAssistance>> ListAsyncByHobbyistId(long id)
    {
        return await _eventAssistanceRepository.ListByHobbyistIdAsync(id);
    }

    public async Task<EventAssistanceResponse> AssignEventAssistanceAsync(long hobbyistId, long eventId, DateTime attendance)
    {
        try
        {
            await _eventAssistanceRepository.AssignEventAssistance(hobbyistId, eventId, attendance);
            await _unitOfWork.CompleteAsync();

            EventAssistance eventAssistance = await _eventAssistanceRepository.FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
            return new EventAssistanceResponse(eventAssistance);
        }
        catch (Exception ex)
        {
            return new EventAssistanceResponse($"An error ocurred while assigning event assistance: {ex.Message}");
        }
    }

    public async Task<EventAssistanceResponse> UnassignEventAssistanceAsync(long hobbyistId, long eventId)
    {
        try
        {
            EventAssistance eventAssistance = await _eventAssistanceRepository.FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
            _eventAssistanceRepository.Remove(eventAssistance);
            await _unitOfWork.CompleteAsync();

            return new EventAssistanceResponse(eventAssistance);
        }
        catch (Exception ex)
        {
            return new EventAssistanceResponse($"An error ocurred while unassigning event assistance: {ex.Message}");
        }
    }
}