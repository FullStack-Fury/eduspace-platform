using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

/// <summary>
/// Represents the teacher command service in the EduSpace API. 
/// </summary>
public interface ITeacherCommandService
{
    /// <summary>
    /// Handles the create teacher command in the EduSpace API.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateTeacherCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Teacher"/> entity.
    /// </returns>
    public Task<Teacher?> Handle(CreateTeacherCommand command);
}