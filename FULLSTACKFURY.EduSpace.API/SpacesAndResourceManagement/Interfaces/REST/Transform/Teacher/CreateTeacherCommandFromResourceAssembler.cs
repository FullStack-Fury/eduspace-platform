using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform CreateTeacherResource to CreateTeacherCommand 
/// </summary>
public class CreateTeacherCommandFromResourceAssembler
{
    /// <summary>
    /// Transform CreateTeacherResource to CreateTeacherCommand 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateTeacherResource"/> resource to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="CreateTeacherCommand"/> command with the values from the resource
    /// </returns>
    public static CreateTeacherCommand ToCommandFromResource(CreateTeacherResource resource)
    {
        return new CreateTeacherCommand(resource.Name, resource.Email, resource.Phone, resource.Location);
    }
}