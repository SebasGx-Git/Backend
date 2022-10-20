using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services
{
    public class FollowerService:IFollowerService
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public FollowerService(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CountFollowers(long ArtistId)
        {
            return await _followerRepository.CountFollower(ArtistId);
        }

        public async Task<IEnumerable<Follower>> ListAsync()
        {
            return await _followerRepository.ListAsync();
        }

        public async Task<IEnumerable<Follower>> ListByArtistIdAsync(long Id)
        {
            return await _followerRepository.ListByArtistIdAsync(Id);
        }

        public async Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long Id)
        {
            return await _followerRepository.ListByHobbyistIdAsync(Id);

        }

        public async Task<FollowerResponse> UnassignFollowerAsync(long HobbyistId, long ArtistId)
        {
            try
            {
                Follower follower = await _followerRepository.FindByHobbyistIdAndArtistId(HobbyistId, ArtistId);
                if (follower == null) throw new Exception();
                await _followerRepository.UnassignFollower(HobbyistId, ArtistId);
                await _unitOfWork.CompleteAsync();
                return new FollowerResponse(follower);
            }
            catch (Exception ex)
            {
                return new FollowerResponse($"An error ocurred while unassign Hobbyist to Artist: {ex.Message}");
            }
        }
        public async Task<FollowerResponse> AssignFollowerAsync(long HobbyistId, long ArtistId)
        {
            try
            {
                await _followerRepository.AssignFollower(HobbyistId, ArtistId);
                await _unitOfWork.CompleteAsync();
                Follower follower = await _followerRepository.FindByHobbyistIdAndArtistId(HobbyistId, ArtistId);
                return new FollowerResponse(follower);
            }
            catch (Exception ex)
            {
                return new FollowerResponse($"An error occurred assign Hobbyist to Artist: {ex.Message}");
            }
        }
    }
}
