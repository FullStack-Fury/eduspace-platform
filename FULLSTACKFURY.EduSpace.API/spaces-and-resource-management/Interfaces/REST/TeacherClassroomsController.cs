using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST;

/// <summary>
/// Controller for managing classrooms by teacher.
/// </summary>
/// <param name="classroomQueryService"></param>
[ApiController]
[Route("api/v1/teachers/{teacherId:int}/classrooms")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Teachers")]
public class TeacherClassroomsController(IClassroomQueryService classroomQueryService) : ControllerBase
{
    /// <summary>
    /// Get all classrooms by teacher
    /// </summary>
    /// <param name="teacherId">
    /// The teacher id to get classrooms for
    /// </param>
    /// <returns>
    /// The classrooms for the teacher
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all classrooms by teacher",
        Description = "Get all classrooms by teacher",
        OperationId = "GetClassroomsByTeacherId"
    )]
    [SwaggerResponse(200, "The classrooms were successfully retrieved", typeof(IEnumerable<ClassroomResource>))]
    public async Task<IActionResult> GetClassroomsByTeacherId(int teacherId)
    {
        var getAllClassroomsByTeacherIdQuery = new GetAllClassroomsByTeacherIdQuery(teacherId);
        var classrooms = await classroomQueryService.Handle(getAllClassroomsByTeacherIdQuery);
        var classroomResources = classrooms.Select(ClassroomResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(classroomResources);
    }
}