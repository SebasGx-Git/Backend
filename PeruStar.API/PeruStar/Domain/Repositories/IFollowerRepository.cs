using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<IEnumerable<Follower>> ListAsync();
        Task<Follower> FindById(long id);
        Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long hobbyistId);
        Task<IEnumerable<Follower>> ListByArtistIdAsync(long artistId);
        Task<Follower> FindByHobbyistIdAndArtistId(long hobbyistId, long artistId);
        Task AssignFollower(long hobbyistId, long ArtistId);
        Task UnassignFollower(long hobbyistId, long ArtistId);
        Task<int> CountFollower(long artistId);
    }
}
