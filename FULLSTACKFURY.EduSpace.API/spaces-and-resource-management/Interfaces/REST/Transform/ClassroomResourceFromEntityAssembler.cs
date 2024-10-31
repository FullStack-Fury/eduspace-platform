using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform Classroom to ClassroomResource
/// </summary>
public class ClassroomResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Classroom to ClassroomResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Classroom"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="ClassroomResource"/> resource with the values from the entity
    /// </returns>
    public static ClassroomResource ToResourceFromEntity(Classroom entity)
    {
        return new ClassroomResource(entity.Id, entity.Name, entity.Description,
        TeacherResourceFromEntityAssembler.ToResourceFromEntity(entity.Teacher));
    }
}