namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_mangement.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a classroom by resource id  in the Platform. 
/// </summary>
/// <param name="ResourceId">
/// The id of the resource to get
/// </param>
public record GetAllClassroomByResourceIdQuery(int ResourceId);