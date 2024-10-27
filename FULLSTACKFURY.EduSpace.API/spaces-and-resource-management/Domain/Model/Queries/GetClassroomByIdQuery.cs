namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_mangement.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a classroom by id in the Platform. 
/// </summary>
/// <param name="ClassroomId">
/// The id of the Classroom to get
/// </param>
public record GetClassroomByIdQuery(int ClassroomId);