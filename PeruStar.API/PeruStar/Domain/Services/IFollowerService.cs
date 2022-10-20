using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services
{
    public interface IFollowerService
    {
        Task<IEnumerable<Follower>> ListAsync();
        Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long Id); 

        Task<IEnumerable<Follower>> ListByArtistIdAsync(long Id);

        Task<int> CountFollowers(long ArtistId);

        Task<FollowerResponse> AssignFollowerAsync(long HobbyistId, long ArtistId);
        Task<FollowerResponse> UnassignFollowerAsync(long HobbyistId, long ArtistId);
    }
}
