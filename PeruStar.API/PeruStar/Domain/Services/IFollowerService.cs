using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services
{
    public interface IFollowerService
    {
        Task<IEnumerable<Follower>> ListAsync();
        Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long id); 

        Task<IEnumerable<Follower>> ListByArtistIdAsync(long id);

        Task<int> CountFollowers(long artistId);

        Task<FollowerResponse> AssignFollowerAsync(long hobbyistId, long artistId);
        Task<FollowerResponse> UnassignFollowerAsync(long hobbyistId, long artistId);
    }
}
