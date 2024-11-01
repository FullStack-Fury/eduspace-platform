namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a classroom by id in the EduSpace API. 
/// </summary>
/// <param name="ClassroomId">
/// The id of the classroom to get
/// </param>
public record GetClassroomByIdQuery(int ClassroomId);