using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform CreateClassroomResource to CreateClassroomCommand
/// </summary>
public class CreateResourceCommandFromResourceAssembler
{
    public static CreateResourceCommand ToCommandFromResource(CreateResourceResource resource)
    {
        return new CreateResourceCommand(resource.Name, resource.KindOfResource, resource.ClassroomId);
    }
}