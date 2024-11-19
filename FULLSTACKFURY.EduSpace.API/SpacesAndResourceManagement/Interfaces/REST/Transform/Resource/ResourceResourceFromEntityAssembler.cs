using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting Resource entities to Resource resources.
/// </summary>
public class ResourceResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a <see cref="Resource"/> entity to a <see cref="ResourceResource"/> resource.
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Resource"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="ResourceResource"/> resource with the values from the entity
    /// </returns>
    public static ResourceResource ToResourceFromEntity(Resource entity)
    {
        return new ResourceResource(entity.Id, entity.Name, entity.KindOfResource,
            ClassroomResourceFromEntityAssembler.ToResourceFromEntity(entity.Classroom));
    }
}