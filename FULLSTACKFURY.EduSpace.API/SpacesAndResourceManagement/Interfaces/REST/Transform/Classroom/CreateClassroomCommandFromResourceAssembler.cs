using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform CreateClassroomResource to CreateClassroomCommand
/// </summary>
public class CreateClassroomCommandFromResourceAssembler
{
    /// <summary>
    /// Transform CreateClassroomResource to CreateClassroomCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateClassroomResource"/> resource to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="CreateClassroomCommand"/> command with the values from the resource
    /// </returns>
    public static CreateClassroomCommand ToCommandFromResource(CreateClassroomResource resource)
    {
        return new CreateClassroomCommand(resource.Name, resource.Description, resource.TeacherId);
    }
}