using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Classroom Endpoints")]
public class ClassroomsController(IClassroomQueryService classroomQueryService, IClassroomCommandService classroomCommandService) : ControllerBase
{
    /// <summary>
    /// Get classroom by id
    /// </summary>
    /// <param name="classroomId">
    /// The classroom id to get
    /// </param>
    /// <returns>
    /// The <see cref="ClassroomResource"/> classroom if found, otherwise returns <see cref="NotFoundResult"/>
    /// </returns>
    [HttpGet("{classroomId:int}")]
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
    
    /// <summary>
    /// Create a classroom
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateClassroomResource"/> to create the classroom from
    /// </param>
    /// <returns>
    /// The <see cref="ClassroomResource"/> classroom if created, otherwise returns <see cref="BadRequestResult"/>
    /// </returns>
    [HttpPost]
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

    /// <summary>
    /// Get all classrooms 
    /// </summary>
    /// <returns>
    /// The list of <see cref="ClassroomResource"/> classrooms
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all classrooms",
        Description = "Get all classrooms",
        OperationId = "GetAllClassrooms"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The classrooms were successfully retrieved",
        typeof(IEnumerable<ClassroomResource>))]
    public async Task<IActionResult> GetAllClassrooms()
    {
        var getAllClassroomsQuery = new GetAllClassroomsQuery();
        var classrooms = await classroomQueryService.Handle(getAllClassroomsQuery);
        var classroomResources = classrooms.Select(ClassroomResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(classroomResources);        
    }    
}