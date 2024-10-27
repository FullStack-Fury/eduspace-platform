namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_mangement.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a resource by id in the Platform. 
/// </summary>
/// <param name="ResourceId">
/// The id of the Classroom to get
/// </param>
public record GetResourceByIdQuery(int ResourceId);