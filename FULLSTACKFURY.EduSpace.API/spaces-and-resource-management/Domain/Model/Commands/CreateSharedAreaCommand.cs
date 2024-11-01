namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

/// <summary>
/// Command to create a new shared area.
/// </summary>
/// <param name="Name">
///   The name of the shared area to create.
/// </param>
/// <param name="Capacity">
///  The capacity of shared area.
/// </param>
/// <param name="Description">
///  The description of the shared area to create.
/// </param>
public record CreateSharedAreaCommand(string Name, int Capacity, string Description);