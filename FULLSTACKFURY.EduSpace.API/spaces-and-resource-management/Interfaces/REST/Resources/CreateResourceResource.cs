namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

/// <summary>
/// The resource to create a new resource
/// </summary>
/// <param name="Name">
/// The name of the resource
/// </param>
/// <param name="KindOfResource">
/// The kind of resource
/// </param>
/// <param name="ClassroomId">
/// The id of the Classroom
/// </param>
public record CreateResourceResource(string Name, string KindOfResource, int ClassroomId);