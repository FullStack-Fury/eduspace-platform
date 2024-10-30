namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

/// <summary>
///  Represent a resource to create a teacher.
/// </summary>
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
public record CreateTeacherResource(string Name, string Email, string Phone, string Location);