using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

/// <summary>
/// Represents the Classroom command service in the Platform. 
/// </summary>
public interface IClassroomCommandService
{
    /// <summary>
    /// Handles the create Classroom command in the Platform. 
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateClassroomCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Resource"/> entity.
    /// </returns>
    public Task<Classroom?> Handle(CreateClassroomCommand command);
}