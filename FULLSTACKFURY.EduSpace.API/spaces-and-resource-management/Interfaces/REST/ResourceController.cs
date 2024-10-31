using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Resource Endpoints")]
public class ResourceController(IResourceQueryService resourceQueryService, IResourceCommandService resourceCommandService): ControllerBase
{
    
    /// <summary>
    /// Get resource by id
    /// </summary>
    /// <param name="resourceId">
    /// The resource  id to get
    /// </param>
    /// <returns>
    /// The <see cref="ResourceResource"/> resource if found, otherwise returns <see cref="NotFoundResult"/>
    /// </returns>
    [HttpGet("{resourceId:int}")]
    [SwaggerOperation(
        Summary = "Get a resource by its ID",
        Description = "Get a resource by its ID",
        OperationId = "GetResourceById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The resource was successfully retrieved", typeof(ResourceResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The resource was not found")]
    public async Task<IActionResult> GetResourceById(int resourceId)
    {
        var getResourceByIdQuery = new GetResourceByIdQuery(resourceId);
        var resource = await resourceQueryService.Handle(getResourceByIdQuery);
        if (resource is null) return NotFound();
        var resourceResource = ResourceResourceFromEntityAssembler.ToResourceFromEntity(resource); 
        return Ok(resourceResource);
    }

    /// <summary>
    /// Create a resource
    /// </summary>
    /// <param name="createResource">
    /// The <see cref="CreateResourceResource"/> to create the resource from
    /// </param>
    /// <returns>
    /// The <see cref="ResourceResource"/> resource if created, otherwise returns <see cref="BadRequestResult"/>
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new resource",
        Description = "Create a new resource",
        OperationId = "CreateResource"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The resource was successfully created", typeof(ResourceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The resource was not created")]

    public async Task<IActionResult> CreateResource([FromBody] CreateResourceResource createResource)
    {
        var createResourceCommand = CreateResourceCommandFromResourceAssembler.ToCommandFromResource(createResource);
        var resource = await resourceCommandService.Handle(createResourceCommand);
        if (resource is null) return BadRequest();
        var resourceResource = ResourceResourceFromEntityAssembler.ToResourceFromEntity(resource);
        return CreatedAtAction(nameof(GetResourceById), new { resourceId = resource.Id }, resourceResource);
    }
    
    /// <summary>
    /// Get all resources 
    /// </summary>
    /// <returns>
    /// The list of <see cref="ResourceResource"/> resources
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all resources",
        Description = "Get all resources",
        OperationId = "GetAllResources"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The resources were successfully retrieved", typeof(IEnumerable<ResourceResource>))]
    public async Task<IActionResult> GetAllResources()
    {
        var getAllResourcesQuery = new GetAllResourcesQuery();
        var resources = await resourceQueryService.Handle(getAllResourcesQuery);
        var resourceResources = resources.Select(ResourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resourceResources);
    }
}