namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

/// <summary>
/// Represents the data exposed by the tutorial resource. 
/// </summary>
/// <param name="Id">
/// The unique identifier of the tutorial.
/// </param>
/// <param name="Name">
/// The name of the classroom.
/// </param>
/// <param name="Description">
/// The description of the classroom.
/// </param>
/// <param name="Teacher">
/// The <see cref="TeacherResource"/> teacher of the classroom.
/// </param>
public record ClassroomResource(int Id, string Name, string Description, TeacherResource Teacher); 