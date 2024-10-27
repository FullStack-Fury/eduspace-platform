namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

/// <summary>
/// Command to create a classroom. 
/// </summary>
/// <param name="Name">
/// The name of the classroom to create.
/// </param>
/// <param name="Description">
/// The Description of the Classroom to create.
/// </param>
/// <param name="TeacherId">
/// The ID of the teacher for the classroom.
/// </param>
public record CreateClassroomCommand(string Name, string Description, int TeacherId);