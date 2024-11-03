using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MeetingsController : ControllerBase
{
    private readonly IMeetingCommandService meetingCommandService;
    private readonly IMeetingQueryService meetingQueryService;

    public MeetingsController(IMeetingCommandService meetingCommandService, IMeetingQueryService meetingQueryService)
    {
        this.meetingCommandService = meetingCommandService;
        this.meetingQueryService = meetingQueryService;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all meetings",
        Description = "Retrieves a list of all meetings",
        OperationId = "GetAllMeetings"
    )]
    public async Task<IActionResult> GetAllMeetings()
    {
        var getAllMeetingsQuery = new GetAllMeetingsQuery();
        var meetings = await meetingQueryService.Handle(getAllMeetingsQuery);
        var resources = meetings.Select(MeetingResourceFromEntityAssembler.FromEntity);
        return Ok(resources);
    }

    [HttpGet("admin/{adminId:int}")]
    [SwaggerOperation(
        Summary = "Gets meetings by admin ID",
        Description = "Retrieves all meetings created by a specific admin",
        OperationId = "GetAllMeetingsByAdminId"
    )]
    public async Task<IActionResult> GetAllMeetingsByAdminId([FromRoute] int adminId)
    {
        var getAllMeetingByAdminIdQuery = new GetAllMeetingByAdminIdQuery(adminId);
        var meetings = await meetingQueryService.Handle(getAllMeetingByAdminIdQuery);
        var resources = meetings.Select(MeetingResourceFromEntityAssembler.FromEntity);
        return Ok(resources);
    }

    [HttpGet("teacher/{teacherId:int}")]
    [SwaggerOperation(
        Summary = "Gets meetings by teacher ID",
        Description = "Retrieves all meetings assigned to a specific teacher",
        OperationId = "GetAllMeetingsByTeacherId"
    )]
    public async Task<IActionResult> GetAllMeetingsByTeacherId([FromRoute] int teacherId)
    {
        var getAllMeetingByTeacherIdQuery = new GetAllMeetingByTeacherIdQuery(teacherId);
        var meetings = await meetingQueryService.Handle(getAllMeetingByTeacherIdQuery);
        var resources = meetings.Select(MeetingResourceFromEntityAssembler.FromEntity);
        return Ok(resources);
    }
    
}