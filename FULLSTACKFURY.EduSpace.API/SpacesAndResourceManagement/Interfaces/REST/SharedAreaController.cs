using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST.Resources.SharedArea;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST.Transform.SharedArea;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Shared Areas Endpoints")]
public class SharedAreaController(ISharedAreaQueryService sharedAreaQueryService, ISharedAreaCommandService sharedAreaCommandService) : ControllerBase
{
    [HttpGet("{sharedAreaId:int}")]
    [SwaggerOperation(
        Summary = "Get a shared area by id",
        Description = "Get a shared area by id",
        OperationId = "GetSharedAreaById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The shared area was successfully retrieved", typeof(SharedArea))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The shared area was not found")]
    public async Task<IActionResult> GetSharedAreaById(int sharedAreaId)
    {
        var getSharedAreaByIdQuery = new GetSharedAreaByIdQuery(sharedAreaId);
        var shareArea = await sharedAreaQueryService.Handle(getSharedAreaByIdQuery);
        if (shareArea is null) return NotFound();
        var sharedAreaResource = SharedAreaResourceFromEntityAssembler.ToResourceFromEntity(shareArea);
        return Ok(sharedAreaResource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a shared area",
        Description = "Create a shared area",
        OperationId = "CreateSharedArea"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The shared area was successfully created", typeof(SharedArea))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The shared area could not be created")]
    public async Task<IActionResult> CreateSharedArea([FromBody] CreateSharedAreaResource resource)
    {
        var createSharedAreaCommand = CreateSharedAreaCommandFromResourceAssembler.ToCommandFromResource(resource);
        var sharedArea = await sharedAreaCommandService.Handle(createSharedAreaCommand);
        if (sharedArea is null) return BadRequest();
        var sharedAreaResource = SharedAreaResourceFromEntityAssembler.ToResourceFromEntity(sharedArea);
        return CreatedAtAction(nameof(GetSharedAreaById), new { sharedAreaId = sharedArea.Id }, sharedAreaResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all shared areas",
        Description = "Get all shared areas",
        OperationId = "GetAllSharedAreas"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The shared areas were successfully retrieved", typeof(IEnumerable<SharedArea>))]
    public async Task<IActionResult> GetAllSharedAreas()
    {
        var getAllSharedAreasQuery = new GetAllSharedAreasQuery();
        var sharedAreas = await sharedAreaQueryService.Handle( getAllSharedAreasQuery);
        var sharedAreaResources = sharedAreas.Select(SharedAreaResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(sharedAreaResources);
    }
}