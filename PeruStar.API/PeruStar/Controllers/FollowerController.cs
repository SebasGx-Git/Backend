using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.PeruStar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Creat, Read, Delete and Artists")]
    public class FollowerController:ControllerBase
    {
        private readonly IFollowerService _followerService;
        private readonly IMapper _mapper;

        public FollowerController(IFollowerService followerService, IMapper mapper)
        {
            _followerService = followerService;
            _mapper = mapper;
        }
        [SwaggerOperation(
         Summary = "List all Followers",
         Description = "List of all Followers",
         OperationId = "ListAllAFollower")]
        [SwaggerResponse(200, "List of Followers", typeof(IEnumerable<FollowerResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FollowerResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<ArtistResource>> GetAllAsync()
        {
            var follower = await _followerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Follower>, IEnumerable<ArtistResource>>(follower);
            return resources;
        }


        [SwaggerOperation(
         Summary = "List Followers By Artist Id",
         Description = "List Followers By Artist Id",
         OperationId = "ListFollowersByArtistId")]
        [SwaggerResponse(200, "List of Followers By Artist Id", typeof(IEnumerable<FollowerResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FollowerResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<FollowerResource>> GetAllByArtistIdAsync(long artistId)
        {
            var followers = await _followerService.ListByArtistIdAsync(artistId);
            var resources = _mapper.Map<IEnumerable<Follower>, IEnumerable<FollowerResource>>(followers);
            return resources;
        }

        [SwaggerOperation(
           Summary = "Assign Follower",
           Description = "Assign Follower",
           OperationId = "AssignFollower")]
        [SwaggerResponse(200, "Artist Assign Follower", typeof(ArtistResource))]

        [HttpPost("{hobbyistId}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> AssignFollower(int hobbyistId, int artistId)
        {
            var result = await _followerService.AssignFollowerAsync(hobbyistId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource.Artist);
            return Ok(artistResource);
        }

        [SwaggerOperation(
           Summary = "Unassign Follower",
           Description = "Unassign Follower",
           OperationId = "UnassignFollower")]
        [SwaggerResponse(200, "Artist Unassign Follower", typeof(ArtistResource))]

        [HttpDelete("{hobbyistId}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> UnassignFollower(int hobbyistId, int artistId)
        {
            var result = await _followerService.UnassignFollowerAsync(hobbyistId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource.Artist);
            return Ok(artistResource);
        }


    }
}
