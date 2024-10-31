using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")] // Route is the path to the controller
[Produces(MediaTypeNames.Application.Json)] // Produces is the content type that the controller will return
[SwaggerTag("Available Teachers Endpoints")] 
public class TeachersController(ITeacherCommandService teacherCommandService, ITeacherQueryService teacherQueryService) : ControllerBase
{
    [HttpGet("{teacherId:int}")]
    [SwaggerOperation(
        Summary = "Get Teacher by Id",
        Description = "Get a teacher by its unique identifier",
        OperationId = "GetTeacherById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The teacher was found", typeof(TeacherResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The teacher was not found")]
    public async Task<IActionResult> GetTeacherById(int teacherId)
    {
        var getTeacherByIdQuery = new GetTeacherByIdQuery(teacherId);
        var teacher = await teacherQueryService.Handle(getTeacherByIdQuery);
        if(teacher is null) return NotFound();
        var teacherResource = TeacherResourceFromEntityAssembler.ToResourceFromEntity(teacher);
        return Ok(teacherResource);        
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Teacher",
        Description = "Create a new teacher",
        OperationId = "CreateTeacher")]
    [SwaggerResponse(StatusCodes.Status201Created, "The teacher was created", typeof(TeacherResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The teacher was not created")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherResource resource)
    {
        var createTeacherCommand = CreateTeacherCommandFromResourceAssembler.ToCommandFromResource(resource);
        var teacher = await teacherCommandService.Handle(createTeacherCommand);
        if(teacher is null) return BadRequest();
        var teacherResource = TeacherResourceFromEntityAssembler.ToResourceFromEntity(teacher);
        return CreatedAtAction(nameof(GetTeacherById), new { teacherId = teacher.Id }, teacherResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Teachers",
        Description = "Get all teachers",
        OperationId = "GetAllTeachers")]
    [SwaggerResponse(StatusCodes.Status200OK, "The teachers were found", typeof(IEnumerable<TeacherResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The teachers were not found")]
    public async Task<IActionResult> GetAllTeachers()
    {
        var teachers = await teacherQueryService.Handle(new GetAllTeachersQuery());
        var teacherResources = teachers.Select(TeacherResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(teacherResources);
    }
}