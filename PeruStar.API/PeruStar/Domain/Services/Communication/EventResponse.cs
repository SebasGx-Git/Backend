using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class EventResponse : BaseResponse<Event>
{
    public EventResponse(Event resource) : base(resource)
    {
    }

    public EventResponse(string message) : base(message)
    {
    }
}