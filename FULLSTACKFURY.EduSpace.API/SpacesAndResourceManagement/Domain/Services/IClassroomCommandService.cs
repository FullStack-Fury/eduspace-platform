using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

/// <summary>
/// Represents the classroom command service in the EduSpace API. 
/// </summary>
public interface IClassroomCommandService
{
    /// <summary>
    /// Handles the create classroom command in the EduSpace API.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateClassroomCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Classroom"/> entity.
    /// </returns>
    Task<Classroom?> Handle(CreateClassroomCommand command);
}