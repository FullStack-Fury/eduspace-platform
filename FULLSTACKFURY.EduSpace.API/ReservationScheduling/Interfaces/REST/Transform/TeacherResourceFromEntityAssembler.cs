using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Transform;

public class TeacherResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Teacher to TeachersResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Teacher"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="TeachersResource"/> resource with the values from the entity
    /// </returns>
    public static TeachersResource ToResourceFromEntity(Teacher entity)
    {
        return new TeachersResource(
            entity.Id, 
            entity.Name,
            entity.Email, 
            entity.Phone, 
            entity.Location 
        );
    }
}