using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.PeruStar.Controllers;

[ApiController]
[Route("api/artists/{artistId}/reports")]
[Produces("application/json")]
[SwaggerTag("Endpoints to manage reports")]
public class ArtistReportsController : ControllerBase
{
    private readonly IClaimTicketService _claimTicketService;
    private readonly IMapper _mapper;

    public ArtistReportsController(IClaimTicketService claimTicketService, IMapper mapper)
    {
        _claimTicketService = claimTicketService;
        _mapper = mapper;
    }


    [SwaggerOperation(
        Summary = "Get All Reports By Artist Id",
        Description = "Get All Reports By Artist Id",
        OperationId = "GetAllReportsByArtistId")]
    [SwaggerResponse(200, "Get All Reports By Artist Id", typeof(IEnumerable<ArtistResource>))]

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClaimTicketResource>), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IEnumerable<ClaimTicketResource>> GetAllReportsByArtistIdAsync(long artistId)
    {
        var claimTicket = await _claimTicketService.ListAsyncByReportedPersonId(artistId);
        var resources = _mapper.Map<IEnumerable<ClaimTicket>, IEnumerable<ClaimTicketResource>>(claimTicket);
        return resources;
    }
}