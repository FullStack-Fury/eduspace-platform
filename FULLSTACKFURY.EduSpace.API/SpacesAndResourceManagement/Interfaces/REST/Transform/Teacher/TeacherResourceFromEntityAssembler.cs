using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;

public static class TeacherResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Category to CategoryResource 
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Teacher"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="TeacherResource"/> resource with the values from the entity
    /// </returns>
    public static TeacherResource ToResourceFromEntity(Teacher entity)
    {
        return new TeacherResource(entity.Id, entity.Name, entity.Email, entity.Phone, entity.Location);
    }
}