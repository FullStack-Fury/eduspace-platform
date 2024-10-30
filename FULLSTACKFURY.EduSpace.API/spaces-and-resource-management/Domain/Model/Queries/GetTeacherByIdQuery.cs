namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a teacher by id in the EduSpace API. 
/// </summary>
/// <param name="TeacherId">
/// The id of the teacher to get
/// </param>
public record GetTeacherByIdQuery(int TeacherId);