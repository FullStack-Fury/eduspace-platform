namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a resource by id in the EduSpace API.
/// </summary>
/// <param name="ResourceId">
/// The id of the resource to get
/// </param>
public record GetResourceByIdQuery(int ResourceId);