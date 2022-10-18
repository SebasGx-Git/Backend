using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication;

public class ClaimTicketResponse : BaseResponse<ClaimTicket>
{
    public ClaimTicketResponse(ClaimTicket resource) : base(resource)
    {
    }

    public ClaimTicketResponse(string message) : base(message)
    {
    }
}