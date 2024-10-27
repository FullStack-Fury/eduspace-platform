namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

/// <summary>
/// Command to create a resource. 
/// </summary>
/// <param name="Name">
/// The name of the resource to create.
/// </param>
/// <param name="Kind_of_resource">
/// The kind of resource of the resource  to create.
/// </param>
/// <param name="ClassroomId">
/// The ID of the Classroom for the resource.
/// </param>
public record CreateResourceCommand(string Name, string Kind_of_resource, int ClassroomId);