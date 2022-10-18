using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class EventAssistanceResponse : BaseResponse<EventAssistance>
{
    public EventAssistanceResponse(EventAssistance resource) : base(resource)
    {
    }

    public EventAssistanceResponse(string message) : base(message)
    {
    }
}