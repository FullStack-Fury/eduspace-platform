using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST;

/// <summary>
/// Get all resources by classroom id
/// </summary>
/// <param name="classroomId">
/// The classroom id to get resources for
/// </param>
/// <returns>
/// The resources  for the classroom
/// </returns>
[ApiController]
[Route("api/v1/classrooms/{classroomId:int}/resources")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Classrooms")]
public class ClassroomResourcesController(IResourceQueryService resourceQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all resources for a classroom",
        Description = "Get all resources for a classroom",
        OperationId = "Get All ResourcesForClassroom"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Resources for classroom", typeof(IEnumerable<ResourceResource>))]
    public async Task<IActionResult> GetAllResourceByClassroomId(int classroomId)
    {
        var getAllResourcesByClassroomIdQuery = new GetAllResourcesByClassroomIdQuery(classroomId);
        var resources = await resourceQueryService.Handle(getAllResourcesByClassroomIdQuery);
        var resourceResources = resources.Select(ResourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resourceResources);
    }
}