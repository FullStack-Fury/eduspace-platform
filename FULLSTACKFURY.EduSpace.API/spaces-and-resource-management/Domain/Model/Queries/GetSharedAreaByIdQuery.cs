namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;

/// <summary>
/// Query to get a shared area by id. 
/// </summary>
/// <param name="SharedAreaId">
/// The id of the shared area to get.
/// </param>
public record GetSharedAreaByIdQuery(int SharedAreaId);