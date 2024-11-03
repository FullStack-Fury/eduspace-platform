namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;

/// <summary>
///  Represents a query to get all classrooms by teacher id in the EduSpace application.
/// </summary>
/// <param name="TeacherId">
/// The id of the teacher to get classrooms for 
/// </param>
public record GetAllClassroomsByTeacherIdQuery(int TeacherId);