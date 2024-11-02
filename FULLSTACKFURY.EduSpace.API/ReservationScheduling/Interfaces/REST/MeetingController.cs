using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Meeting Endpoints")]
public class MeetingsController(IMeetingQueryService meetingQueryService, IMeetingCommandService meetingCommandService) : ControllerBase
{
    /// <summary>
    /// Get a meeting by its ID
    /// </summary>
    /// <param name="meetingId">
    /// The meeting id to get
    /// </param>
    /// <returns>
    /// The <see cref="MeetingResource"/> meeting if found, otherwise returns <see cref="NotFoundResult"/>
    /// </returns>
    [HttpGet("{meetingId:int}")]
    [SwaggerOperation(
        Summary = "Get a meeting by its ID",
        Description = "Get a meeting by its ID",
        OperationId = "GetMeetingById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The meeting was successfully retrieved", typeof(MeetingResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The meeting was not found")]
    public async Task<IActionResult> GetMeetingById(Guid meetingId)
    {
        var getMeetingByIdQuery = new GetMeetingByIdQuery(meetingId);
        var meeting = await meetingQueryService.Handle(getMeetingByIdQuery);
        if (meeting is null) return NotFound();
        var meetingResource = MeetingResourceFromEntityAssembler.ToResourceFromEntity(meeting);
        return Ok(meetingResource);
    }

    /// <summary>
    /// Create a new meeting
    /// </summary>
    /// <param name="createMeeting">
    /// The <see cref="CreateMeetingResource"/> to create the meeting from
    /// </param>
    /// <returns>
    /// The <see cref="MeetingResource"/> meeting if created, otherwise returns <see cref="BadRequestResult"/>
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new meeting",
        Description = "Create a new meeting",
        OperationId = "CreateMeeting"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The meeting was successfully created", typeof(MeetingResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The meeting was not created")]
    public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingResource createMeeting)
    {
        var createMeetingCommand = CreateMeetingCommandFromResourceAssembler.ToCommandFromResource(createMeeting);
        var meeting = await meetingCommandService.Handle(createMeetingCommand);
    
        if (meeting is null) 
            return BadRequest();
        
        var meetingResource = MeetingResourceFromEntityAssembler.ToResourceFromEntity(meeting);
    
        // Cambia 'meeting.Id' por 'meeting.MeetingId'
        return CreatedAtAction(nameof(GetMeetingById), new { meetingId = meeting.MeetingId }, meetingResource);
    }

    /// <summary>
    /// Get all meetings
    /// </summary>
    /// <returns>
    /// The list of <see cref="MeetingResource"/> meetings
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all meetings",
        Description = "Get all meetings",
        OperationId = "GetAllMeetings"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The meetings were successfully retrieved", typeof(IEnumerable<MeetingResource>))]
    public async Task<IActionResult> GetAllMeetings()
    {
        var getAllMeetingsQuery = new GetAllMeetingsQuery();
        var meetings = await meetingQueryService.Handle(getAllMeetingsQuery);
        var meetingResources = meetings.Select(MeetingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(meetingResources);
    }
}