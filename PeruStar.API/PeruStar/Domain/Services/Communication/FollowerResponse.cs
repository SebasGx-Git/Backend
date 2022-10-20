using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services.Communication
{
    public class FollowerResponse: BaseResponse<Follower>
    {
        public FollowerResponse(Follower resource) : base(resource)
        {

        }
        public FollowerResponse(string message) : base(message)
        {

        }
    }
}
