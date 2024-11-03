namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

/// <summary>
/// Represents a teacher resource.
/// </summary>
/// <param name="Id">
/// The unique identifier for the teacher.
/// </param>
/// <param name="Name">
/// The name of the Teacher
/// </param>
/// <param name="Email">
/// The email of the Teacher
/// </param>
/// <param name="Phone">
/// The phone number of the Teacher
/// </param>
/// <param name="Location">
/// The localization of the Teacher
/// </param>
public record TeacherResource(int Id, string Name, string Email, string Phone, string Location); 