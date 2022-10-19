using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication
{
    public class SpecialtyResponse : BaseResponse<Specialty>
    {
        public SpecialtyResponse(Specialty resource) : base(resource)
        {
        }

        public SpecialtyResponse(string message) : base(message)
        {
        }
    }
}
