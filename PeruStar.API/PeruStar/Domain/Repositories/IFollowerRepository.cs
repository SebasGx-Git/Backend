using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<IEnumerable<Follower>> ListAsync();
        Task AddAsync(Follower follower);
        void Update(Follower follower);
        void Remove(Follower follower);
        Task<Follower> FindById(long id);
        Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long hobbyistId);
        Task<IEnumerable<Follower>> ListByArtistIdAsync(long artistId);
        Task<Follower> FindByHobbyistIdAndArtistId(long hobbyistId, long artistId);
        Task AssignFollower(long HobbyistId, long ArtistId);
        Task UnassignFollower(long HobbyistId, long ArtistId);
        Task<int> CountFollower(long ArtistId);
    }
}
