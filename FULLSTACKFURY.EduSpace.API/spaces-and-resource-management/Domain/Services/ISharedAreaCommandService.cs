using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

/// <summary>
/// Represents the shared area command service in the EduSpace API. 
/// </summary>
public interface ISharedAreaCommandService
{
    /// <summary>
    /// Handles the create shared area command in the EduSpace API.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateSharedAreaCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="sharedArea"/> entity.
    /// </returns>
    Task<sharedArea?> Handle(CreateSharedAreaCommand command);
}