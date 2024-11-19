using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Meeting Endpoints")]
public class MeetingsController(IMeetingQueryService meetingQueryService, IMeetingCommandService meetingCommandService) : ControllerBase
{
    
    /**
     * [HttpPost]
    [SwaggerOperation(
        Summary = "Create a classroom",
        Description = "Create a classroom",
        OperationId = "CreateClassroom"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The classroom was successfully created", typeof(ClassroomResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The classroom was not created")]
        
    public async Task<IActionResult> CreateClassroom([FromBody] CreateClassroomResource resource)
    {
        var createClassroomCommand = CreateClassroomCommandFromResourceAssembler.ToCommandFromResource(resource);
        var classroom = await classroomCommandService.Handle(createClassroomCommand);
        if (classroom is null) return BadRequest();
        var classroomResource = ClassroomResourceFromEntityAssembler.ToResourceFromEntity(classroom);
        return CreatedAtAction(nameof(GetClassroomById), new {classroomId = classroom.Id}, classroomResource);
    }
     */
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a meeting",
        Description = "Creates a new meeting",
        OperationId = "CreateMeeting"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The classroom was successfully created", typeof(MeetingResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The classroom was not created")]

    public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingResource resource)
    {
        
        var createMeetingCommand = CreateMeetingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var meeting = await meetingCommandService.Handle(createMeetingCommand);
        if (meeting is null) return BadRequest();
        var meetingResource = MeetingResourceFromEntityAssembler.ToResourceFromEntity(meeting);
        return CreatedAtAction(nameof(GetMeetingById), new {meetingId = meeting.Id}, meetingResource);
    }

    [HttpGet("{meetingId:int}")]
    [SwaggerOperation(
        Summary = "Get a meeting by id",
        Description = "Get a meeting by id",
        OperationId = "GetMeetingById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The meeting was successfully retrieved", typeof(MeetingResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The meeting was not found")]

    public async Task<IActionResult> GetMeetingById(int meetingId)
    {
        var getMeetingByIdQuery = new GetMeetingByIdQuery(meetingId);
        var meeting= await meetingQueryService.Handle(getMeetingByIdQuery);
        if (meeting is null) return NotFound();
        var meetingResource = MeetingResourceFromEntityAssembler.ToResourceFromEntity(meeting);
        return Ok(meetingResource);
    }
    
    /**
     * [HttpGet("{classroomId:int}")]
    [SwaggerOperation(
        Summary = "Get a classroom by id",
        Description = "Get a classroom by id",
        OperationId = "GetClassroomById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The classroom was successfully retrieved", typeof(ClassroomResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The classroom was not found")]
    public async Task<IActionResult> GetClassroomById(int classroomId)
    {
        var getClassroomByIdQuery = new GetClassroomByIdQuery(classroomId);
        var classroom = await classroomQueryService.Handle(getClassroomByIdQuery);
        if (classroom is null) return NotFound();
        var classroomResource = ClassroomResourceFromEntityAssembler.ToResourceFromEntity(classroom);
        return Ok(classroomResource);
    }
     */
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all meetings",
        Description = "Retrieves a list of all meetings",
        OperationId = "GetAllMeetings"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The meeting were successfully retrieved",
        typeof(IEnumerable<MeetingResource>))]
    public async Task<IActionResult> GetAllMeetings()
    {
        var getAllMeetingQuery = new GetAllMeetingsQuery();
        var meetings = await meetingQueryService.Handle(getAllMeetingQuery);
        var meetingResource = meetings.Select(MeetingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(meetingResource);
    }
}