using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.PeruStar.Controllers;

[ApiController]
[Route("api/hobbyists/{hobbyistId}/events")]
[Produces("application/json")]
[SwaggerTag("Hobbyist Events")]
public class EventAssistancesController : ControllerBase
{
     private readonly IEventAssistanceService _eventAssistanceService;
        private readonly IEventService _eventService;
        //private readonly IHobbyistService _hobbyistService;
        private readonly IMapper _mapper;

        public EventAssistancesController(IEventAssistanceService eventAssistanceService, IMapper mapper, IEventService eventService = null)
        {
            _eventAssistanceService = eventAssistanceService;
            _mapper = mapper;
            _eventService = eventService;
        }



        /*****************************************************************/
                    /*LIST OF ALL EVENTS BY HOBBYIST ID*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Get All Events By Hobbyist Id",
           Description = "Get All Events By Hobbyist Id",
           OperationId = "GetAllEventsByHobbyistId")]
        [SwaggerResponse(200, "Get All Events By Hobbyist Id", typeof(IEnumerable<EventResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<EventResource>> GetAllByHobbyistIdAsync(long hobbyistId)
        {
           // var events = await _eventService.ListByHobbyistAsync(hobbyistId);
            //var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            //return resources;
            return null;
        }



        /*****************************************************************/
                            /*ASSIGN EVENT ASSISTANCE*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Assign Event Assistance",
           Description = "Assign Event Assistance",
           OperationId = "Assign Event Assistance")]
        [SwaggerResponse(200, "Event Assigned", typeof(EventResource))]

        [HttpPost("{eventId}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> AssignEventAssistance(long hobbyistId, long eventId, [FromBody]SaveEventAssistanceResource resource) {
            var result = await _eventAssistanceService.AssignEventAssistanceAsync(hobbyistId, eventId, resource.AttendanceDay);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource.Event!);
            return Ok(eventResource);
        }



        /*****************************************************************/
                            /*UNASSIGN EVENT ASSISTANCE*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Unassign Event Assistance",
           Description = "Unassign Event Assistance",
           OperationId = "Unassign Event Assistance")]
        [SwaggerResponse(200, "Event Unassigned", typeof(EventResource))]
        [HttpDelete("{eventId}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> UnassignEventAssistance(long hobbyistId, long eventId) {
            var result = await _eventAssistanceService.UnassignEventAssistanceAsync(hobbyistId, eventId);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource.Event!);
            return Ok(eventResource);
        }
}